using MicroShop.Enum.Permission;
using MicroShop.Enum;
using MicroShop.Model.Serialize.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System;

namespace MicroShop.Model.VO.Permission
{
    /// <summary>
    /// 系统用户视图
    /// </summary>
    [Serializable]
    public class SystemUserVO
    {
        /// <summary>
        /// 系统用户编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long UserId { get; set; } = 0;

        /// <summary>
        /// 角色编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long RoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 登录名
        /// </summary>         
        public string LoginName { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>     
        [Description("用户名")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 是否管理员
        /// </summary> 
        [Description("是否管理员")]
        public bool IsAdmin { get; set; } = false;

        /// <summary>
        /// 登录状态
        /// </summary>       
        [Description("登录状态")]      
        public LoginStatuses LoginStatus { get; set; } = LoginStatuses.Forbidden;

        /// <summary>
        /// 登录状态名称
        /// </summary>
        [Description("登录状态名称")]
        public string LoginStatusName
        {
            get
            {
                return LoginStatus.GetDescription();
            }
        }

        /// <summary>
        /// 登录次数
        /// </summary>        
        [Description("登录次数")]
        public int LoginCount { get; set; } = 0;

        /// <summary>
        /// 密钥加的盐，Json序列化不输出
        /// </summary>
        [Description("密钥加的盐")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Salt { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码
        /// </summary>
        [Description("登录密码")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string LoginPassword { get; set; } = string.Empty;

        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Description("电子邮箱")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Erp对应的编码
        /// </summary>
        [Description("Erp对应的编码")]
        public string ErpCode { get; set; } = string.Empty;

        /// <summary>
        /// Erp对应的名称
        /// </summary>
        [Description("Erp对应的名称")]
        public string ErpName { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        [Description("创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        [Description("更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 最近登录时间
        /// </summary>
        [Description("最近登录时间")]
        public string LastLogin { get; set; } = string.Empty;

    }
}
