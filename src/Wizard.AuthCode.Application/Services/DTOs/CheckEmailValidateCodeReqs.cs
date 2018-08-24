using Wizard.AuthCode.Application.Services.EnumTypess;

namespace Wizard.AuthCode.Application.Services.DTOs
{
    /// <summary>
    /// 校验邮箱验证码
    /// </summary>
    public class CheckEmailValidateCodeReqs
    {
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VCode { get; set; }

        /// <summary>
        /// 验证码类型
        /// </summary>
        public CodeType CodeType { get; set; }
    }
}
