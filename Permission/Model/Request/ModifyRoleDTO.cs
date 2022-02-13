using System;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Permission.Model.Request
{
    /// <summary>
    /// 修改角色信息请求
    /// </summary>
    [Serializable]
    public class ModifyRoleDTO : CreateRoleDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Required(ErrorMessage = "角色编号不能为空")]
        [Range(1, int.MaxValue, ErrorMessage ="角色编号格式错误")]
        public int RoleId { get; set; }
    }
}
