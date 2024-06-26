﻿using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 角色菜单对应关系
    /// </summary>
    [Serializable]
    public class SetRoleMenuRelationReqDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Required(ErrorMessage = "角色编号不能为空")]
        [Range(1, int.MaxValue, ErrorMessage = "角色编号格式错误")]
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 菜单编号
        /// </summary>     
        public List<int> MenuIds { get; set; } = new List<int>();
    }
}
