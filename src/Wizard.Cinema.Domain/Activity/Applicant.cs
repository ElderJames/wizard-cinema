using System;
using Infrastructures.Exceptions;
using Wizard.Cinema.Domain.Activity.EnumTypes;

namespace Wizard.Cinema.Domain.Activity
{
    /// <summary>
    /// 报名者
    /// </summary>
    public class Applicant
    {
        /// <summary>
        /// 报名者Id
        /// </summary>
        public long ApplicantId { get; private set; }

        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; private set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; private set; }

        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; private set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; private set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; private set; }

        /// <summary>
        /// 报名者状态
        /// </summary>
        public ApplicantStatus Status { get; private set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyTime { get; private set; }

        public Applicant(long applicantId, long wizardId, Activity activity, string realName, string mobile)
        {
            if (activity == null)
                throw new DomainException("活动不存在，请选择正确的活动");

            if (activity.Status != ActivityStatus.报名中 || activity.RegistrationFinishTime < DateTime.Now)
                throw new DomainException("不在报名时间内");

            this.ApplicantId = applicantId;
            this.WizardId = wizardId;
            this.ActivityId = activity.ActivityId;
            this.DivisionId = activity.DivisionId;
            this.RealName = realName;
            this.Mobile = mobile;
            this.Status = ApplicantStatus.未付款;
            this.ApplyTime = DateTime.Now;
        }

        public void Pay()
        {
            this.Status = ApplicantStatus.已付款;
        }

        public void ChooseSeat()
        {
            this.Status = ApplicantStatus.已选座;
        }
    }
}
