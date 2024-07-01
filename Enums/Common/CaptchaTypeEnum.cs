using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Common
{
    /// <summary>
    /// 验证码类型枚举
    /// </summary>
    [Serializable]
    public enum CaptchaTypeEnum
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
