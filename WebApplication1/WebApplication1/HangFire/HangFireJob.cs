using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.HangFire
{
    public class HangFireJob
    {
        public static void InitJob()
        {
            //RecurringJob.AddOrUpdate<ITimerClass>("任务触发工具", e => e.TryNewTasks(), "*/5 * * * * ?", TimeZoneInfo.Utc);
            //RecurringJob.AddOrUpdate<ITimerClass>("任务触发工具", e => e.TryNewTasks(), Cron.Minutely(), TimeZoneInfo.Utc);
        }
    }
}
