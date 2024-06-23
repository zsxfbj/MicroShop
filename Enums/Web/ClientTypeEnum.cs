using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Web
{
    /// <summary>
    /// 客户端类型
    /// </summary>
    [Serializable]
    public enum ClientTypeEnum
    {
        /// <summary>
        /// PC网页端
        /// </summary>
        [Description("PC网页端")]
        [EnumMember(Value = "100")]
        PCWeb = 100,

        /// <summary>
        /// 手机网页端
        /// </summary>
        [Description("手机网页端")]
        [EnumMember(Value = "200")]
        MobileWeb = 200,

        /// <summary>
        /// 微信小程序
        /// </summary>
        [Description("微信小程序")]
        [EnumMember(Value = "210")]
        WxMinApp = 210,

        /// <summary>
        /// 安卓端
        /// </summary>
        [Description("安卓端")]
        [EnumMember(Value = "300")]
        Android = 300,

        /// <summary>
        /// 苹果端
        /// </summary>
        [Description("苹果端")]
        [EnumMember(Value = "400")]
        IOS = 400
    }
}
