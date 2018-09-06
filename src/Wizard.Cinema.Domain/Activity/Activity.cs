using System;
using Wizard.Cinema.Domain.Activity.EnumTypes;

namespace Wizard.Cinema.Domain.Activity
{
    /// <summary>
    /// 活动
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 活动详情
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 活动地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 活动状态
        /// </summary>
        public ActivityStatus Status { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// 报名开始时间
        /// </summary>
        public DateTime RegistrationBeginTime { get; set; }

        /// <summary>
        /// 报名截止时间
        /// </summary>
        public DateTime RegistrationFinishTime { get; set; }

        /// <summary>
        /// 报名费用
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 创建者id
        /// </summary>
        public long CreatorId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
