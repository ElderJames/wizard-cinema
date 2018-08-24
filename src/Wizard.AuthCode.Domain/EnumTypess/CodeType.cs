using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.AuthCode.Domain.EnumTypess
{
    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum CodeType
    {
        注册 = 1,

        登录 = 2,

        找回登录密码 = 3,

        找回交易密码 = 4,

        修改手机号码 = 5,

        邮箱认证 = 6,

        邮箱解绑 = 7,

        其他类型 = 999
    }
}
