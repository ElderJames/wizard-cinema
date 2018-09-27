using System;
using Infrastructures.Exceptions;

namespace Wizard.Cinema.Domain.Cinema
{
    /// <summary>
    /// 座位
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// 座位Id
        /// </summary>
        public long SeatId { get; private set; }

        /// <summary>
        /// 场次Id
        /// </summary>
        public long SessionId { get; private set; }

        /// <summary>
        /// 影院提供的座位编号
        /// </summary>
        public string SeatNo { get; private set; }

        /// <summary>
        /// 位置，n排m号
        /// </summary>
        public int[] Position { get; private set; }

        /// <summary>
        /// 是否已选
        /// </summary>
        public bool Selected { get; private set; }

        /// <summary>
        /// 选座巫师Id
        /// </summary>
        public long? WizardId { get; private set; }

        /// <summary>
        /// 选座时间
        /// </summary>
        public DateTime? SelectTime { get; private set; }

        /// <summary>
        /// 创建座位
        /// </summary>
        /// <param name="seatId"></param>
        /// <param name="sessionId"></param>
        /// <param name="seatNo"></param>
        /// <param name="location"></param>
        public Seat(long seatId, long sessionId, string seatNo, int[] position)
        {
            if (position.Length != 2)
                throw new DomainException("座位数据是长度为2的数组");

            this.SeatId = seatId;
            this.SessionId = sessionId;
            this.SeatNo = seatNo;
            this.Position = position;
        }

        /// <summary>
        /// 选择此座位
        /// </summary>
        /// <param name="wizard"></param>
        public void Choose(long wizard)
        {
            this.WizardId = wizard;
            this.Selected = true;
            this.SelectTime = DateTime.Now;
        }
    }
}
