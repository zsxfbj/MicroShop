using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Web.Common
{
    /// <summary>
    /// 请求结果枚举
    /// </summary>
    public enum RequestResultCodeEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        [EnumMember(Value = "200")]
        Success = 200,

        [EnumMember(Value = "400")]
        [Description("请求参数错误")]
        RequestParameterError = 400,

        [EnumMember(Value = "404")]
        [Description("记录不存在")]
        NotFound = 404,

    }
}
