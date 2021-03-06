using System;
using System.Collections.Generic;

namespace MicroShop.Permission.Model.Response
{
    /// <summary>
    /// 系统用户登录结果
    /// </summary>
    [Serializable]
    public class LoginResultDTO
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; } = string.Empty;

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>      
        public int LoginCount { get; set; } = 0;              

        /// <summary>
        /// 更新时间
        /// </summary>        
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 用户菜单
        /// </summary>
        public List<RoleMenuDTO> RoleMenus { get; set; }
    }
}
