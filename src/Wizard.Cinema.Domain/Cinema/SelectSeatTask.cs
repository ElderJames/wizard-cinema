﻿using System;
using Infrastructures.Exceptions;
using Wizard.Cinema.Domain.Activity;
using Wizard.Cinema.Domain.Cinema.EnumTypes;

namespace Wizard.Cinema.Domain.Cinema
{
    /// <summary>
    /// 选座任务
    /// </summary>
    public class SelectSeatTask
    {
        /// <summary>
        /// 任务Id
        /// </summary>
        public long TaskId { get; private set; }

        /// <summary>
        /// 场次Id
        /// </summary>
        public long SessionId { get; private set; }

        /// <summary>
        /// 巫师Id
        /// </summary>
        public long WizardId { get; private set; }

        /// <summary>
        /// 巫师名
        /// </summary>
        public string WechatName { get; private set; }

        /// <summary>
        /// 序号，按序号排队选座，过号重入需要等两位
        /// </summary>
        public int SerialNo { get; private set; }

        /// <summary>
        /// 可选座位数
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        /// 状态
        /// </summary>
        public SelectTaskStatus Status { get; private set; }

        /// <summary>
        /// 座位编号
        /// </summary>
        public string[] SeatNos { get; private set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; private set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        private SelectSeatTask()
        {
        }

        /// <summary>
        /// 创建一个选座任务
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <param name="sessionId">场次id</param>
        /// <param name="applicant">报名者</param>
        /// <param name="serialNo">序号</param>
        /// <param name="total">可选座位数</param>
        public SelectSeatTask(long taskId, long sessionId, Applicant applicant, int serialNo)
        {
            this.TaskId = taskId;
            this.SessionId = sessionId;
            this.WizardId = applicant.WizardId;
            this.WechatName = applicant.WechatName;
            this.SerialNo = serialNo;
            this.Total = applicant.Count;
            this.Status = SelectTaskStatus.待开始;
            this.CreateTime = DateTime.Now;
        }

        public void Begin()
        {
            if (this.Status != SelectTaskStatus.排队中)
                throw new DomainException("此用户未在队列中");

            this.Status = SelectTaskStatus.进行中;
            this.BeginTime = DateTime.Now;
        }

        public void Select(string[] seatNos)
        {
            if (this.Status != SelectTaskStatus.进行中)
                throw new DomainException("此用户不在选座状态");

            this.Status = SelectTaskStatus.已完成;
            this.SeatNos = seatNos;
            this.EndTime = DateTime.Now;
        }

        public void Timedout()
        {
            if (this.Status != SelectTaskStatus.进行中)
                throw new DomainException("此用户未未在选座状态");

            this.Status = SelectTaskStatus.超时并结束;
            this.EndTime = DateTime.Now;
        }
    }
}
