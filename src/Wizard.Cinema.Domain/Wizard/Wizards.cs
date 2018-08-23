using System;
using Wizard.Cinema.Domain.Wizard.EnumTypes;
using Wizard.Cinema.Infrastructures.Encrypt.Extensions;
using Wizard.Cinema.Infrastructures.Exceptions;

namespace Wizard.Cinema.Domain.Wizard
{
    /// <summary>
    /// 巫师
    /// </summary>
    public class Wizards
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
        /// 密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 巫师档案
        /// </summary>
        public WizardProfiles Profile { get; private set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; private set; }

        /// <summary>
        /// 创建巫师
        /// </summary>
        /// <param name="wizardId"></param>
        /// <param name="account"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Wizards(long wizardId, string account, string email, string password)
        {
            this.WizardId = wizardId;
            this.Account = account;
            this.Password = password.ToMd5();
            this.Email = email;
            this.CreateTime = DateTime.Now;
            this.Profile = new WizardProfiles(wizardId);
            this.DivisionId = 0;
        }

        /// <summary>
        /// 设置或转移分部
        /// </summary>
        /// <param name="divisionId"></param>
        public void ChangeDivision(long divisionId)
        {
            this.DivisionId = divisionId;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPassward"></param>
        /// <param name="newPassward"></param>
        public void ChangePassward(string oldPassward, string newPassward)
        {
            string passwardMd5 = Password.ToMd5();
            if (oldPassward != passwardMd5)
                throw new DomainException("旧密码匹配失败，请填写正确的密码");
        }

        /// <summary>
        /// 修改档案
        /// </summary>
        /// <param name="nickName"></param>
        /// <param name="portraitUrl"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        /// <param name="slogan"></param>
        /// <param name="house"></param>
        public void ChangeInfo(string nickName, string portraitUrl, string mobile, Gender gender, DateTime birthday, string slogan, Houses house)
        {
            this.Profile.Change(nickName, portraitUrl, mobile, gender, birthday, slogan, house);
        }
    }
}
