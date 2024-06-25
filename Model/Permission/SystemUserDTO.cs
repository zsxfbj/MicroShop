using System;
using MicroShop.Enums.Permission;
using MicroShop.Utility.Common;
using MicroShop.Utility.Serialize.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 系统用户视图
    /// </summary>
    [Serializable]
    public class SystemUserDTO
    {
        /// <summary>
        /// 系统用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>         
        public string LoginName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>     
        [Description("用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary> 
        [Description("是否管理员")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 登录状态
        /// </summary>       
        [Description("登录状态")]
        public LoginStatusEnum LoginStatus { get; set; } = LoginStatusEnum.Forbidden;

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
        public int LoginCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        [Description("创建时间")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        [Description("更新时间")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemUserDTO()
        {
            UserId = 0;
            UserName = "";
            RoleName = "";
            RoleId = 0;
            LoginName = "";
            UserName = "";
            IsAdmin = false;
            LoginStatus = LoginStatusEnum.Forbidden;
            LoginCount = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}
