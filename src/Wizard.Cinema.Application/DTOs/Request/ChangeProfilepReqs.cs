using System;
using Wizard.Cinema.Application.Services.Dto.EnumTypes;

namespace Wizard.Cinema.Application.Services.Dto.Request
{
    public class ChangeProfilepReqs
    {
        public long WizardId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像Url
        /// </summary>
        public string PortraitUrl { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string Slogan { get; set; }

        /// <summary>
        /// 学院
        /// </summary>
        public Houses House { get; set; }
    }
}
