using System;
using System.Collections.Generic;

namespace MicroShop.Permission.Model
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    [Serializable]
    public class RoleMenuDTO
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 上级菜单编号
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 下级菜单
        /// </summary>
        public List<RoleMenuDTO> SubMenus { get; set; }
    }
}
