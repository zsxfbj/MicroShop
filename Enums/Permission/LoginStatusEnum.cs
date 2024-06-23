using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Permission
{
    /// <summary>
    /// 登录状态
    /// </summary>
    [Serializable]
    public enum LoginStatusEnum
    {
        /// <summary>
        /// 禁止的
        /// </summary>
        [Description("禁止")]
        [EnumMember(Value = "0")]
        Forbidden = 0,

        /// <summary>
        /// 允许的
        /// </summary>
        [Description("允许")]
        [EnumMember( Value ="1")]
        Allowable = 1
    }
}
