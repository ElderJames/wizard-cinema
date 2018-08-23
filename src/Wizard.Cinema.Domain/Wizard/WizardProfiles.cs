using System;
using System.Collections.Generic;
using System.Text;
using Wizard.Cinema.Domain.Wizard.EnumTypes;

namespace Wizard.Cinema.Domain.Wizard
{
    /// <summary>
    /// 巫师档案
    /// </summary>
    public class WizardProfiles
    {
        public long WizardId { get; private set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NickName { get; private set; }

        /// <summary>
        /// 头像Url
        /// </summary>
        public string PortraitUrl { get; private set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; private set; }

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

        internal WizardProfiles(long wizardId)
        {
            this.WizardId = wizardId;
        }

        public void Change(string nickName, string portraitUrl, string mobile, Gender gender, DateTime birthday, string slogan, Houses house)
        {
            this.NickName = nickName;
            this.PortraitUrl = portraitUrl;
            this.Mobile = mobile;
            this.Gender = gender;
            this.Birthday = birthday;
            this.Slogan = slogan;
            this.House = house;
        }
    }
}
