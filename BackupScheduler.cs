using Quartz;
using Quartz.Impl;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbBackup
{
    public class BackupScheduler
    {
        static IScheduler scheduler;

        /// <summary>
        /// start backup schduler for monogdb databases
        /// </summary>
        /// <param name="days">SUN,MON,TUE,WED,THU,FRI,SAT</param>
        /// <param name="hour">1-24</param>
        /// <param name="minute">0-59</param>
        /// <returns></returns>
        public static async Task Start(string days, string hour, string minute)
        {
            try
            {
                scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await scheduler.Start();

                IJobDetail job = JobBuilder.Create<BackupJob>().Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("BackupJob", "Backup")
                    .WithCronSchedule($"0 {minute} {hour} ? * {days}")
                    .StartAt(DateTime.UtcNow)
                    .Build();

                await scheduler.ScheduleJob(job, trigger);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task Stop()
        {
            try
            {
                await scheduler.Shutdown();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class BackupJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ProcessBackup();
            return Task.FromResult(true);
        }

        private void ProcessBackup()
        {
            Config.Instance.Databases.ForEach(db =>
            {
                BackupHelper.ExecuteMongoDump(db, FMain.instance.Log);
            });
        }
    }
}
