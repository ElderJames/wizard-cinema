using Wizard.AuthCode.Application.Services.DTOs;
using Wizard.Infrastructures;

namespace Wizard.AuthCode.Application.Services
{
    public interface IValidateCodeService
    {
        /// <summary>
        /// 创建邮箱验证码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ApiResult<bool> CreateEmailValidateCode(CreateEmailValidateCodeReqs request);

        /// <summary>
        /// 校验邮箱验证码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ApiResult<bool> CheckEmailValidateCode(CheckEmailValidateCodeReqs request);
    }
}
