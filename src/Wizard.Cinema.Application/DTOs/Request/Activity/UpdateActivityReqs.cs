using System;
using System.Collections.Generic;
using System.Text;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Request.Activity
{
    public class UpdateActivityReqs
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
    }
}
