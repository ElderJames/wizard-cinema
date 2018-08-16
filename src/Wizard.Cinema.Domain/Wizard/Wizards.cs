using System;
using Wizard.Cinema.Domain.Wizard.EnumTypes;

namespace Wizard.Cinema.Domain.Wizard
{
    public class Wizards
    {
        /// <summary>
        /// 巫师Id
        /// </summary>
        public Guid WizardId { get; private set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; private set; }

        /// <summary>
        /// 帐户
        /// </summary>
        public string Account { get; private set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 头像Url
        /// </summary>
        public string PortraitUrl { get; private set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; private set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; private set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string Slogan { get; private set; }

        /// <summary>
        /// 学院
        /// </summary>
        public Houses House { get; private set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public string CreateTime { get; private set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string LastLoginTime { get; private set; }
    }
}