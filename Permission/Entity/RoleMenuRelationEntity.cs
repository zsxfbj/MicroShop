using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.Permission.Entity
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    [Serializable]
    [Table("role_menu_relation")]
    public class RoleMenuRelationEntity
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Key]
        [Column("role_id", TypeName = "int")]
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Key]
        [Column("menu_id", TypeName = "int")]
        public int MenuId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleMenuRelationEntity()
        {
            RoleId = 0;
            MenuId = 0;
            CreatedAt = DateTime.Now;
        }
    }
}
