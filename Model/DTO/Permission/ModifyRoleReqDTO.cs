﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 修改角色信息请求
    /// </summary>
    [Serializable]
    public class ModifyRoleReqDTO : CreateRoleReqDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Required(ErrorMessage = "角色编号不能为空")]
        [Range(1, int.MaxValue, ErrorMessage = "角色编号数据错误")]
        public int RoleId { get; set; }
    }
}
