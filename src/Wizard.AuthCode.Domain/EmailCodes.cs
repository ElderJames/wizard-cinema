using System;
using Wizard.AuthCode.Domain.EnumTypess;
using Wizard.Infrastructures.Exceptions;

namespace Wizard.AuthCode.Domain
{
    public class EmailCodes
    {
        public long CodeId { get; private set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// 验证码类型
        /// </summary>
        public CodeType CodeType { get; private set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VCode { get; private set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireTime { get; private set; }

        /// <summary>
        /// 使用状态
        /// </summary>
        public UsageState UsageState { get; private set; }

        /// <summary>
        /// 生成客户端IP
        /// </summary>
        public string ClientIP { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        public EmailCodes(long codeId, string email, CodeType codeType, string vcode, int indateMinutes, string clientIp)
        {
            if (indateMinutes <= 0)
                throw new DomainException("有效期少于0秒了");

            var now = DateTime.Now;

            this.CodeId = codeId;
            this.Email = email;
            this.CodeType = codeType;
            this.VCode = vcode;
            this.ExpireTime = now.AddMilliseconds(indateMinutes);
            this.CreateTime = now;
            this.UsageState = UsageState.未使用;
            this.ClientIP = clientIp;
        }

        public void Destroy()
        {
            this.UsageState = UsageState.已使用;
        }
    }
}
