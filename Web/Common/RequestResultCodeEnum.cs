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
        /// 角色名称重复
        /// </summary>
        [EnumMember(Value = "1000")]
        [Description("角色名称重复")]       
        RoleNameIsExist = 1000




    }
}
