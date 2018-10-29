using System;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Response
{
    public class ApplicantResp
    {
        /// <summary>
        /// 报名者Id
        /// </summary>
        public long ApplicantId { get; set; }

        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; set; }

        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 微信名
        /// </summary>
        public string WechatName { get; set; }

        /// <summary>
        /// 报名人数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 报名者状态
        /// </summary>
        public ApplicantStatus Status { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyTime { get; set; }
    }
}
