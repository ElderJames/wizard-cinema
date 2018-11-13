using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Microsoft.Extensions.Logging;
using Quartz;
using Wizard.Cinema.Application.DTOs.EnumTypes;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;

namespace Wizard.Cinema.Admin.Quartz.Jobs
{
    [Job(Cron = "0/2 * * * * ? ", JobName = "定时检查超时选座任务，每两秒执行一次")]
    public class TaskOverdueCheckJob : IJob
    {
        private readonly ILogger _logger;
        private readonly ISelectSeatTaskService _selectSeatTaskService;
        private readonly ISessionService _sessionService;
        private static readonly object locker = new object();

        public TaskOverdueCheckJob(ILogger<TaskOverdueCheckJob> logger,
            ISelectSeatTaskService selectSeatTaskService,
            ISessionService sessionService)
        {
            this._logger = logger;
            this._selectSeatTaskService = selectSeatTaskService;
            this._sessionService = sessionService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            lock (locker)
            {
                try
                {
                    ApiResult<IEnumerable<SessionResp>> sessions = _sessionService.GetSessions(SessionStatus.进行中);
                    if (sessions.Status != ResultStatus.SUCCESS || sessions.Result.IsNullOrEmpty())
                        return Task.CompletedTask;

                    ApiResult<IEnumerable<SelectSeatTaskResp>> overdueTasks = _selectSeatTaskService.GetOverdueTask(sessions.Result.Select(x => x.SessionId), DateTime.Now.AddMinutes(-10));
                    if (overdueTasks.Status != ResultStatus.SUCCESS || overdueTasks.Result.IsNullOrEmpty())
                        return Task.CompletedTask;

                    foreach (SelectSeatTaskResp task in overdueTasks.Result)
                    {
                        _selectSeatTaskService.SetOverdue(task.SessionId, task.TaskId);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("检查超时定时任务异常", ex);
                }
            }

            return Task.CompletedTask;
        }
    }
}
