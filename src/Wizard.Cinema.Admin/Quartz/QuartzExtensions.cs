using System;
using System.Linq;
using System.Reflection;
using Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Wizard.Cinema.Admin.Quartz
{
    public static class QuartzExtensions
    {
        public static void AddQuartz(this IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton(provider =>
            {
                var sf = new StdSchedulerFactory();
                var scheduler = sf.GetScheduler().Result;
                scheduler.JobFactory = provider.GetService<IJobFactory>();
                return scheduler;
            });
            services.AddHostedService<QuartzService>();

            foreach (Type jobType in TypeScanner.AllTypes.Where(x => x.GetCustomAttribute<JobAttribute>() != null))
            {
                services.AddSingleton(jobType, jobType);
            }
        }

        public static void UseQuartz(this IApplicationBuilder app)
        {
            IScheduler scheduler = app.ApplicationServices.GetService<IScheduler>();
            ILogger<IApplicationBuilder> logger = app.ApplicationServices.GetService<ILogger<IApplicationBuilder>>();

            foreach (Type jobType in TypeScanner.AllTypes.Where(x => x.GetCustomAttribute<JobAttribute>() != null))
            {
                JobAttribute attribute = jobType.GetCustomAttribute<JobAttribute>();

                string jobName = attribute?.JobName ?? jobType.FullName;
                string cron = attribute?.Cron ?? "0/1 * * * * ? ";

                IJobDetail job = JobBuilder.Create(jobType)
                    .WithIdentity(jobType.FullName)
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity($"{jobType.FullName}.trigger")
                    .StartNow()
                     .WithCronSchedule(cron)
                    .Build();

                scheduler.ScheduleJob(job, trigger);
            }
        }
    }
}
