using System;
using Wizard.Cinema.Domain.Cinema.EnumTypes;
using Wizard.Cinema.Domain.Wizard;

namespace Wizard.Cinema.Domain.Cinema
{
    /// <summary>
    /// 选座任务
    /// </summary>
    public class SelectSeatTask
    {
        /// <summary>
        /// 任务Id
        /// </summary>
        public long TaskId { get; set; }

        /// <summary>
        /// 场次Id
        /// </summary>
        public long SessionId { get; set; }

        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; set; }

        /// <summary>
        /// 巫师名
        /// </summary>
        public string WizardName { get; set; }

        /// <summary>
        /// 序号，按序号排队选座，过号重入需要等两位
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public SelectTaskStatus Status { get; set; }

        /// <summary>
        /// 座位编号
        /// </summary>
        public string SeatNo { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public SelectSeatTask(long taskId, long sessionId, WizardProfiles wizard, int serialNo)
        {
            this.TaskId = taskId;
            this.SessionId = sessionId;
            this.WizardId = wizard.WizardId;
            this.WizardName = wizard.NickName;
            this.SerialNo = serialNo;
            this.Status = SelectTaskStatus.待开始;
            this.CreateTime = DateTime.Now;
        }

        public void Action()
        {
            this.Status = SelectTaskStatus.进行中;
            this.BeginTime = DateTime.Now;
        }

        public void Select(string seatNo)
        {
            this.Status = SelectTaskStatus.已完成;
            this.SeatNo = seatNo;
            this.EndTime = DateTime.Now;
        }

        public void Timedout()
        {
            this.Status = SelectTaskStatus.超时并结束;
            this.EndTime = DateTime.Now;
        }
    }
}
