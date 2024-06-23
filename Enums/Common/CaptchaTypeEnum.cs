using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Common
{
    /// <summary>
    /// 验证码类型
    /// </summary>
    [Serializable]
    public enum CaptchaTypeEnum
    {
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        [EnumMember(Value = "0")]
        Login  = 0,

        /// <summary>
        /// 重置密码密码
        /// </summary>
        [Description("重置密码密码")]
        [EnumMember(Value = "100")]
        ResetPassoword = 100
    }
}
