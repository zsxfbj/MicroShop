using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Permission.Enums
{
    /// <summary>
    /// 操作类型枚举
    /// </summary>
    public enum ActionTypeEnum
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        [EnumMember(Value = "0")]
        None = 0,

        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        [EnumMember(Value = "1")]
        Login = 1,

        /// <summary>
        /// 修改密码
        /// </summary>         
        [Description("修改密码")]
        [EnumMember(Value = "2")]
        ModifyPassword = 2,

        /// <summary>
        /// 创建
        /// </summary>
        [Description("创建")]
        [EnumMember(Value = "100")]
        Create = 100,

        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        [EnumMember(Value = "200")]
        Modify = 200,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        [EnumMember(Value = "300")]
        Delete = 300
    }
}
