using System;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.QueryServices.DTOs.Cinema
{
    public class SelectSeatTaskInfo
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
        public string WechatName { get; set; }

        /// <summary>
        /// 序号，按序号排队选座，过号重入需要等两位
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// 可选座位数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public SelectTaskStatus Status { get; set; }

        /// <summary>
        /// 座位编号
        /// </summary>
        public string[] SeatNos { get; set; }

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
    }
}
