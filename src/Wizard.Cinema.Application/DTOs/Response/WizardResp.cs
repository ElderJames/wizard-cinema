using System;

namespace Wizard.Cinema.Application.Services.Dto.Response
{
    public class WizardResp
    {
        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; private set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// 帐户
        /// </summary>
        public string Account { get; private set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; private set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; private set; }

        /// <summary>
        /// 创建者id
        /// </summary>
        public long CreatorId { get; private set; }
    }
}
