using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.Entity.Permission
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    [Serializable]
    [Table("role_menu_relation")]
    public class RoleMenuRelation
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Key]
        [Column("role_id")]
        public long RoleId { get; set; } = 0L;

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Key]
        [Column("menu_id")]
        public long MenuId { get; set; } = 0L;

        /// <summary>
        /// 权限
        /// </summary>
        [Column("permission")]       
        public string Permission { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
