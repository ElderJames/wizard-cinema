namespace Wizard.Cinema.Application.DTOs.EnumTypes
{
    public enum SelectTaskStatus
    {
        /// <summary>
        /// 初始状态
        /// </summary>
        未排队 = 0,

        /// <summary>
        /// 开始选座后，用户未排队
        /// </summary>
        //未排队 = 5,

        /// <summary>
        /// 开始选座时换成排队中状态，或者超时之后重新排队
        /// </summary>
        排队中 = 10,

        /// <summary>
        /// 选座状态
        /// </summary>
        进行中 = 15,

        /// <summary>
        /// 选座完成
        /// </summary>
        已完成 = 20,

        /// <summary>
        /// 超时了
        /// </summary>
        超时未重排 = 25,

        /// <summary>
        /// 超时之后已经重新排
        /// </summary>
        超时已重排 = 30
    }
}
