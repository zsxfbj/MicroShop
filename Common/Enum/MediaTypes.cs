using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Common.Enum
{
    /// <summary>
    /// 媒体类型枚举
    /// </summary>   
    public enum MediaTypes
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Description("文本")]
        [EnumMember(Value = "100")]
        Text = 100,

        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        [EnumMember(Value = "200")]
        Image = 200,

        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        [EnumMember(Value = "300")]
        Video = 300

    }
}
