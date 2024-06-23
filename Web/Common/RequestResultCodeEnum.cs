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
        /// 资源不存在
        /// </summary>
        [EnumMember(Value = "404")]
        [Description("资源不存在")]
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
        /// 角色名重复
        /// </summary>
        [EnumMember(Value = "10000")]
        [Description("角色名重复")]
        RoleNameIsExist = 10000,

        /// <summary>
        /// 登录名重复
        /// </summary>
        [EnumMember(Value = "10001")]
        [Description("登录名重复")]
        LoginNameIsExist = 10001,

        /// <summary>
        /// 用户重复
        /// </summary>
        [EnumMember(Value = "10002")]
        [Description("用户名重复")]
        UserNameIsExist = 10002,

        /// <summary>
        /// 品牌名重复
        /// </summary>
        [EnumMember(Value = "10003")]
        [Description("品牌名重复")]
        BrandNameIsExist = 10003,

        /// <summary>
        /// 产品分类名重复
        /// </summary>
        [EnumMember(Value = "10004")]
        [Description("产品分类名重复")]
        CategoryNameIsExist = 10004,

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
        SystemUserNotExist = 10200,


        /// <summary>
        /// 存在子分类
        /// </summary>
        [EnumMember(Value = "10300")]
        [Description("存在子分类")]
        HasSubCategories = 10300



    }
}
