using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Entity.Permission
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
        [Column("role_id", TypeName = "int")]
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Key]
        [Column("menu_id", TypeName = "int")]
        public int MenuId { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleMenuRelation()
        {
            RoleId = 0;
            MenuId = 0;
            CreatedAt = DateTime.Now;
        }
    }
}
