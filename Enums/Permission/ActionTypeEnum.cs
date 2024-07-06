using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Permission
{
    /// <summary>
    /// 操作类型枚举
    /// </summary>
    [Serializable]
    public enum ActionTypeEnum
    {
        /// <summary>
        /// 浏览
        /// </summary>
        [Description("浏览")]
        [EnumMember(Value = "0")]
        View = 0,

        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        [EnumMember(Value = "100")]
        Login = 100,

        /// <summary>
        /// 创建
        /// </summary>
        [Description("创建")]
        [EnumMember(Value = "200")]
        Create = 200,

        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        [EnumMember(Value = "300")]
        Modify = 300,

        /// <summary>
        /// 修改密码
        /// </summary>         
        [Description("修改密码")]
        [EnumMember(Value = "301")]
        ModifyPassword = 301,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        [EnumMember(Value = "400")]
        Delete = 400
    }
}
