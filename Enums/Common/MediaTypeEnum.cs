using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Common
{
    /// <summary>
    /// 媒体类型
    /// </summary>
    [Serializable]
    public enum MediaTypeEnum
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Description("文本")]
        [EnumMember(Value = "1")]
        Text = 1,

        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        [EnumMember(Value = "100")]
        Image = 100,

        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        [EnumMember(Value = "200")]
        Video = 200

    }
}
