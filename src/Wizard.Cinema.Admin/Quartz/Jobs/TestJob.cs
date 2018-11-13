using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Wizard.Cinema.Admin.Quartz.Jobs
{
    [Job(Cron = "0/2 * * * * ? ", JobName = "测试作业")]
    public class TestJob : IJob
    {
        private readonly ILogger _logger;

        public TestJob(ILogger<TestJob> logger)

        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)

        {
            _logger.LogInformation(string.Format("[{0:yyyy-MM-dd hh:mm:ss:ffffff}]任务执行！", DateTime.Now));

            return Task.CompletedTask;
        }
    }
}
