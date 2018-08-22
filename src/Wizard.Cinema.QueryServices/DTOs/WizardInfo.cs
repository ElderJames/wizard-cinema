using System;
using Wizard.Cinema.Application.Services.Dto.EnumTypes;

namespace Wizard.Cinema.QueryServices.DTOs
{
    public class WizardInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// 帐户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; set; }
    }
}
