﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 修改菜单请求
    /// </summary>
    [Serializable]
    public class ModifyMenuReqDTO : CreateMenuReqDTO
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        [Required(ErrorMessage = "菜单编号不能为空")]
        [Range(1, int.MaxValue, ErrorMessage = "菜单编号格式错误")]
        public int MenuId { get; set; } = 0;
    }
}
