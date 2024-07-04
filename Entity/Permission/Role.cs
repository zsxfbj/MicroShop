using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Permission
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
        [Column("role_id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("role_name", TypeName = "nvarchar(30)")]
        [MaxLength(30, ErrorMessage = "角色名称最多30个字"), Required(ErrorMessage = "角色名称必须填写")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        [Column("is_enable", TypeName = "bit")]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note", TypeName = "nvarchar(255)")]
        [MaxLength(255, ErrorMessage = "备注不能超过255个字")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at", TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Role()
        {
            RoleId = 0;
            RoleName = string.Empty;
            IsEnable = false;
            Note = string.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
