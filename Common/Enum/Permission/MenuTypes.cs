using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Common.Enum.Permission
{
    /// <summary>
    /// 菜单类型
    /// </summary>  
    public enum MenuTypes
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Description("文本")]
        [EnumMember(Value = "0")]
        Text = 0,

        /// <summary>
        /// 内部地址
        /// </summary>
        [Description("内部地址")]
        [EnumMember(Value = "1")]
        InnerLink = 1,

        /// <summary>
        /// 功能
        /// </summary>
        [Description("功能")]
        [EnumMember(Value = "2")]
        Function = 2,

        /// <summary>
        /// 外部链接
        /// </summary>
        [Description("外部链接")]
        [EnumMember(Value = "3")]
        ExternalLink = 3
    }
}
