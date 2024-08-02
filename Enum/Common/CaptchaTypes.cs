using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enum.Common
{
    /// <summary>
    /// 验证码类型枚举
    /// </summary>    
    public enum CaptchaTypes
    {
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        [EnumMember(Value = "1")]
        Login  = 1,

        /// <summary>
        /// 重置密码密码
        /// </summary>
        [Description("重置密码密码")]
        [EnumMember(Value = "10")]
        ResetPassoword = 10
    }
}
