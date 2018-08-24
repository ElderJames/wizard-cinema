using Wizard.AuthCode.Application.Services.EnumTypess;

namespace Wizard.AuthCode.Application.Services.DTOs
{
    /// <summary>
    /// 创建邮箱验证码
    /// </summary>
    public class CreateEmailValidateCodeReqs
    {
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 验证码类型
        /// </summary>
        public CodeType CodeType { get; set; }

        /// <summary>
        /// 验证码长度
        /// </summary>
        public int CodeLength { get; set; }

        /// <summary>
        /// 生成客户端IP
        /// </summary>
        public string ClientIP { get; set; }
    }
}
