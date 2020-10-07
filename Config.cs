using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace MongoDbBackup
{
    delegate bool FileMonitor(FileSystemEventArgs e);
    /// <summary>
    /// ConfigMonitor helps to handle on the fly configuration
    /// notify's on file change and file delete
    /// </summary>
    class ConfigMonitor
    {
        public ConfigMonitor(string fullpathfilename, FileMonitor callbackchange, FileMonitor callbackdelete)
        {
            if (fullpathfilename == null || callbackchange == null /*call back delete can be null*/)
                throw new ArgumentNullException();

            if (fullpathfilename.Length == 0)
                throw new ArgumentOutOfRangeException();

            if (!System.IO.File.Exists(fullpathfilename))
                throw new FileNotFoundException();

            this.callbackchange = callbackchange;
            this.callbackdelete = callbackdelete;
            watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            watcher.Path = Path.GetDirectoryName(fullpathfilename);
            watcher.Filter = Path.GetFileName(fullpathfilename);
            watcher.Changed += new FileSystemEventHandler(this.OnChanged);
            watcher.Deleted += new FileSystemEventHandler(this.OnChanged);
            watcher.EnableRaisingEvents = true;
        }


        public void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                ((System.IO.FileSystemWatcher)source).EnableRaisingEvents = false;
                //pC: 1.5 second break to allow the notepad.exe to close the file 
                // other wise we will get the file not accessible error 
                System.Threading.Thread.Sleep(1500);

                if (e.ChangeType == WatcherChangeTypes.Changed && callbackchange != null)
                    callbackchange(e);
                if (e.ChangeType == WatcherChangeTypes.Deleted && callbackdelete != null)
                    callbackdelete(e);
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                ((System.IO.FileSystemWatcher)source).EnableRaisingEvents = true;
            }
        }

        private System.IO.FileSystemWatcher watcher;
        private FileMonitor callbackchange;
        private FileMonitor callbackdelete;
    }


    public class Config
    {
        public List<string> Databases { get; set; }
        public string BackupDir { get; set; }
        public string MongoInstallationDir { get; set; }

        private Config()
        {
            theDefaults = new SortedList<string, string>();
            guard = new ReaderWriterLock();
            AssureDefaultConfig(false);
            monitor = new ConfigMonitor(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, OnConfigAppChanged, OnConfigAppDeleted);
            ResetConfigs();
        }

        private void ResetConfigs()
        {
            MongoInstallationDir = Read<string>("MongoInstallationDir") ?? "c:\\Program Files\\MongoDB\\bin\\mongodump";
            BackupDir = Read<string>("BackupDir") ?? "C:\\backups";
            var databases = Read<string>("Databases");
            if (!string.IsNullOrWhiteSpace(databases))
            {
                Databases = databases.Split(',').ToList();
            }
        }

        /// <summary>
        /// Read an item from the config
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Read<T>(string name)
        {            
            try
            {
                guard.AcquireReaderLock(-1);
                string value = System.Configuration.ConfigurationManager.AppSettings[name];
                if (value == null)
                    value = theDefaults[name];
                if (typeof(T).IsEnum)
                    return (T)Enum.Parse(typeof(T), value, true);

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                guard.ReleaseReaderLock();
            }
        }

        public void Write<T>(string name, T value)
        {                
            try
            {
                guard.AcquireWriterLock(-1);
                ConfigurationManager.AppSettings[name] = value.ToString();
                UpdateAppSettings(name, value.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                guard.ReleaseWriterLock();
                ConfigurationManager.RefreshSection("appSettings");
            } 
        }

        private bool OnConfigAppDeleted(FileSystemEventArgs e)
        {        
            AssureDefaultConfig(true);
            return true;
        }

        private bool OnConfigAppChanged(FileSystemEventArgs e)
        {
            ConfigurationManager.RefreshSection("appSettings");
            ResetConfigs();
            return true;
        }

        private void AssureDefaultConfig(bool filedeleted)
        {
            if (!System.IO.File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
            {
                if (!filedeleted)
                    ConfigurationManager.RefreshSection("appSettings");

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                foreach (string key in theDefaults.Keys)
                    config.AppSettings.Settings.Add(key, theDefaults[key]);

                SectionInformation csruntime = config.GetSection("runtime").SectionInformation;
                if (csruntime != null && !csruntime.IsDeclared)
                    csruntime.SetRawXml("<runtime><gcConcurrent enabled=\"true\"/></runtime>");

                config.Save();
            }
            else
            {
                ConfigurationManager.RefreshSection("appSettings");
                //ConfigurationManager.RefreshSection("system.net");
            }
        }

        public void UpdateAppSettings(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private         ReaderWriterLock            guard;
        private         SortedList<string, string>  theDefaults;
        private         ConfigMonitor               monitor;
        private static  Config                      theSingleton;
        public  static  Config Instance
        {
            get
            {
                if (theSingleton == null)
                    theSingleton = new Config();
                return theSingleton;
            }
        }
    }
}
