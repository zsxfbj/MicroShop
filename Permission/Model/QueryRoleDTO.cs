using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MicroShop.Web.Common;

namespace MicroShop.Permission.Model
{
    /// <summary>
    /// 查询角色
    /// </summary>
    public class QueryRoleDTO : PageRequestDTO
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [StringLength(30, ErrorMessage = "角色名称最多30个字")]
        [DefaultValue("")]
        public string RoleName { get; set; }
    }
}
