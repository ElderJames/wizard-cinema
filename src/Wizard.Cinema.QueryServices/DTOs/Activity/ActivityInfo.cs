using System;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.QueryServices.DTOs.Activity
{
    public class ActivityInfo
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 举办分部Id
        /// </summary>
        public long DivisionId { get; set; }

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
        /// 类型
        /// </summary>
        public ActivityTypes Type { get; set; }

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
