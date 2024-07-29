using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.Entity.Permission
{
    /// <summary>
    /// 系统管理库的角色表
    /// </summary>
    [Serializable]
    [Table("role")]
    public class Role
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Key]
        [Column("role_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("role_name")]
        [MaxLength(30, ErrorMessage = "角色名称最多30个字"), Required(ErrorMessage = "角色名称必须填写")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        [Column("is_enable")]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note")]
        [MaxLength(255, ErrorMessage = "备注不能超过255个字")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
               
    }
}
