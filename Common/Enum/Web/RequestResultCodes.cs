using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Common.Enum.Web
{
    /// <summary>
    /// 请求结果枚举
    /// </summary>
    public enum RequestResultCodes
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        [EnumMember(Value = "200")]
        Success = 200,

        /// <summary>
        /// 请求参数错误
        /// </summary>
        [EnumMember(Value = "400")]
        [Description("请求参数错误")]
        RequestParameterError = 400,

        /// <summary>
        /// 禁止匿名用户访问
        /// </summary>
        [Description("禁止匿名用户访问")]
        [EnumMember(Value = "401")]
        NotAllowAnonymous = 401,

        /// <summary>
        /// 禁止访问
        /// </summary>
        [Description("禁止访问")]
        [EnumMember(Value = "403")]
        NotAllowAccess = 403,

        /// <summary>
        /// 访问的记录不存在
        /// </summary>
        [EnumMember(Value = "404")]
        [Description("访问的记录不存在")]
        NotFound = 404,

        /// <summary>
        /// 未知错误
        /// </summary>
        [EnumMember(Value = "500")]
        [Description("未知错误")]
        UnkownError = 500,

        /// <summary>
        /// 数据访问错误
        /// </summary>
        [EnumMember(Value = "501")]
        [Description("数据访问错误")]
        DatabaseAccessError = 501,

        /// <summary>
        /// 名称重复
        /// </summary>
        [EnumMember(Value = "10000")]
        [Description("名称重复")]
        NameIsExist = 10000,

        /// <summary>  
        /// 键名重复
        /// </summary>
        [EnumMember(Value = "10001")]
        [Description("键名重复")]        
        KeyIsExist = 10001,

        /// <summary>
        /// 登录名重复
        /// </summary>
        [EnumMember(Value = "10002")]
        [Description("登录名重复")]
        LoginNameIsExist = 10002,

        /// <summary>
        /// 存在下级记录
        /// </summary>
        [EnumMember(Value = "10003")]
        [Description("存在下级记录")]
        HasSubRecords = 10003,

        /// <summary>
        /// 验证码已失效
        /// </summary>
        [EnumMember(Value = "10100")]
        [Description ("验证码已失效")]
        CaptchaCodeIsExpired = 10100,

        /// <summary>
        /// 验证码已失效
        /// </summary>
        [EnumMember(Value = "10101")]
        [Description("验证码不一致")]
        CaptchaCodeNotSame = 10101,

        /// <summary>
        /// 系统用户记录不存在
        /// </summary>
        [EnumMember(Value = "10200")]
        [Description("系统用户记录不存在")]
        SystemUserNotExist = 10200

    }
}
