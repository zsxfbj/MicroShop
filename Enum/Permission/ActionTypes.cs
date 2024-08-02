using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enum.Permission
{
    /// <summary>
    /// 操作类型枚举
    /// </summary>   
    public enum ActionTypes
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        [EnumMember(Value = "0")]
        None = 0,

        /// <summary>
        /// 浏览
        /// </summary>
        [Description("浏览")]
        [EnumMember(Value = "1")]
        View = 1,

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
        [EnumMember(Value = "10")]
        Create = 10,

        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        [EnumMember(Value = "20")]
        Modify = 20,

        /// <summary>
        /// 修改密码
        /// </summary>         
        [Description("修改密码")]
        [EnumMember(Value = "21")]
        ModifyPassword = 21,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        [EnumMember(Value = "30")]
        Delete = 30
    }
}
