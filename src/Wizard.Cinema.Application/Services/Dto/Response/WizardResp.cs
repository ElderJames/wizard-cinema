using System;
using Wizard.Cinema.Application.Services.Dto.EnumTypes;

namespace Wizard.Cinema.Application.Services.Dto.Response
{
    public class WizardResp
    {
        public int Id { get; set; }

        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 帐户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 头像Url
        /// </summary>
        public string PortraitUrl { get; set; }

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

        /// <summary>
        /// 注册时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string LastLoginTime { get; set; }
    }
}
