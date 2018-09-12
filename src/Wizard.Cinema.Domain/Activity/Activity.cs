﻿using Infrastructures.Exceptions;
using System;
using Wizard.Cinema.Domain.Activity.EnumTypes;

namespace Wizard.Cinema.Domain.Activity
{
    /// <summary>
    /// 活动
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; private set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 活动详情
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 活动地址
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// 类型
        /// </summary>
        public ActivityTypes Type { get; private set; }

        /// <summary>
        /// 活动状态
        /// </summary>
        public ActivityStatus Status { get; private set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; private set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime FinishTime { get; private set; }

        /// <summary>
        /// 报名开始时间
        /// </summary>
        public DateTime RegistrationBeginTime { get; private set; }

        /// <summary>
        /// 报名截止时间
        /// </summary>
        public DateTime RegistrationFinishTime { get; private set; }

        /// <summary>
        /// 报名费用
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// 创建者id
        /// </summary>
        public long CreatorId { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        private Activity()
        {
        }

        public Activity(long activityId, string name, string description, string address,
            DateTime beginTime, DateTime finishTime, DateTime registrationBeginTime, DateTime registrationFinishTime,
            decimal price, long creatorId, DateTime createTime)
        {
            this.ActivityId = activityId;
            this.Name = name;
            this.Description = description;
            this.Address = address;
            this.BeginTime = beginTime;
            this.FinishTime = finishTime;
            this.RegistrationBeginTime = registrationBeginTime;
            this.RegistrationFinishTime = registrationFinishTime;
            this.Price = price;
            this.CreatorId = creatorId;
            this.CreateTime = createTime;
            this.Status = ActivityStatus.未启动;
        }

        public void Change(string name, string description, string address,
            DateTime beginTime, DateTime finishTime, DateTime registrationBeginTime, DateTime registrationFinishTime,
            decimal price, long creatorId, DateTime createTime)
        {
            if (this.Status != ActivityStatus.未启动)
                throw new DomainException("进行中不能修改");

            this.Name = name;
            this.Description = description;
            this.Address = address;
            this.BeginTime = beginTime;
            this.FinishTime = finishTime;
            this.RegistrationBeginTime = registrationBeginTime;
            this.RegistrationFinishTime = registrationFinishTime;
            this.Price = price;
            this.CreatorId = creatorId;
            this.CreateTime = createTime;
            this.Status = ActivityStatus.未启动;
        }
    }
}
