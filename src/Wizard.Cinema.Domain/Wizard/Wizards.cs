using System;
using Wizard.Cinema.Domain.Wizard.EnumTypes;
using Wizard.Cinema.Infrastructures.Encrypt.Extensions;
using Wizard.Cinema.Infrastructures.Exceptions;

namespace Wizard.Cinema.Domain.Wizard
{
    public class Wizards
    {
        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; private set; }

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
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; private set; }

        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIpAddress { get; private set; }

        public Wizards(long wizardId, string mobile, string account, string password)
        {
            this.WizardId = wizardId;
            this.Mobile = mobile;
            this.Account = account;
            this.Password = password.ToMd5();
            this.CreateTime = DateTime.Now;
        }

        public void ChangePassward(string oldPassward, string newPassward)
        {
            string passwardMd5 = Password.ToMd5();
            if (oldPassward != passwardMd5)
                throw new DomainException("旧密码匹配失败，请填写正确的密码");
        }

        public void ChangeInfo(string name, string portraitUrl, Gender gender, DateTime birthday, string slogan,
            Houses house)
        {
            this.Name = name;
            this.PortraitUrl = portraitUrl;
            this.Gender = gender;
            this.Birthday = birthday;
            this.Slogan = slogan;
            this.House = house;
        }
    }
}
