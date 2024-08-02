using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enum.Permission
{
    /// <summary>
    /// 登录状态
    /// </summary>  
    public enum LoginStatuses
    {
        /// <summary>
        /// 禁止的
        /// </summary>
        [Description("禁止登录")]
        [EnumMember(Value = "0")]
        Forbidden = 0,

        /// <summary>
        /// 允许的
        /// </summary>
        [Description("允许登录")]
        [EnumMember( Value ="1")]
        Allowable = 1
    }
}
