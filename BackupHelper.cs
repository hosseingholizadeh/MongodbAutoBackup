using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MongoDbBackup
{
    internal class BackupHelper
    {
        internal static void ExecuteMongoDump(string db,Action<string> log)
        {
            StringBuilder command = new StringBuilder("mongodump");
            command.Append($" --db={db} ");
            command.Append($" --out=\"{Config.Instance.BackupDir}\\{DateTime.Now.ToString("yyyy-MM-dd")}\"");

            try
            {
                Stopwatch sp = new Stopwatch();
                sp.Start();
                ExecuteCommandAsync(command.ToString());
                sp.Stop();
                var message = $"{command} executed in {sp.ElapsedMilliseconds} milliseconds";
                log.Invoke(message);
            }
            catch (Exception ex)
            {
                var message = $"there was an error on executing command: {command.ToString()} => {ex}";
                log.Invoke(message);
            }
        }

        internal static void RunCommad(string command)
        {
            Process pr = new Process();
            pr.StartInfo.WorkingDirectory = Config.Instance.MongoInstallationDir;
            //pr.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            pr.StartInfo.FileName = $@"{Environment.SystemDirectory}\cmd.exe";
            pr.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            pr.StartInfo.CreateNoWindow = true;
            pr.StartInfo.UseShellExecute = false;
            pr.StartInfo.Arguments = $"/c {command}";

            try
            {
                pr.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            pr.Dispose();
        }
        /// <span class="code-SummaryComment"><summary></span>
        /// Executes a shell command synchronously.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="command">string command</param></span>
        /// <span class="code-SummaryComment"><returns>string, as output of the command.</returns></span>
        public static void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo($@"{Environment.SystemDirectory}\cmd.exe", "/c " + command);

                procStartInfo.WorkingDirectory = Config.Instance.MongoInstallationDir;

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // log result here
            }
            catch (Exception objException)
            {
                throw objException;
            }
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Execute the command Asynchronously.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="command">string command.</param></span>
        public static void ExecuteCommandAsync(string command)
        {
            try
            {
                //Asynchronously start the Thread to process the Execute command request.
                Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
                //Make the thread as background thread.
                objThread.IsBackground = true;
                //Set the Priority of the thread.
                objThread.Priority = ThreadPriority.AboveNormal;
                //Start the thread.
                objThread.Start(command);
            }
            catch (ThreadStartException objException)
            {
                throw objException;
            }
            catch (ThreadAbortException objException)
            {
                throw objException;
            }
            catch (Exception objException)
            {
                throw objException;
            }
        }
    }
}
