namespace Wizard.Cinema.Application.DTOs.EnumTypes
{
    public enum ApplicantStatus
    {
        /// <summary>
        /// 已报名，未付款
        /// </summary>
        未付款 = 0,

        /// <summary>
        /// 已付款，未选座
        /// </summary>
        已付款 = 5,

        /// <summary>
        /// 已选座
        /// </summary>
        已选座 = 10
    }
}
