using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Permission
{
    /// <summary>
    /// 管理后台菜单表
    /// </summary>
    [Serializable]
    [Table("menu")]
    public class Menu
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        [Key]
        [Column("menu_id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; } = 0;

        /// <summary>
        /// 上级菜单编号
        /// </summary>
        [Column("parent_id", TypeName = "int")]
        [Range(0, int.MaxValue, ErrorMessage = "上级菜单编号格式错误")]
        public int ParentId { get; set; } = 0;

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("menu_name", TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "菜单名称必须填写"), MaxLength(30, ErrorMessage = "菜单名称不能超过30个字")]
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Column("menu_url", TypeName = "varchar(255)")]
        [MaxLength(255, ErrorMessage = "菜单地址不能超过255个字")]
        public string MenuUrl { get; set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        [Column("order_value", TypeName = "int")]
        public int OrderValue { get; set; } = 1;

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note", TypeName = "nvarchar(255)")]
        [MaxLength(255, ErrorMessage = "备注不能超过255个字")]
        public string Note { get; set; } = string.Empty;

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

        /// <summary>
        /// 构造函数
        /// </summary>
        public Menu()
        {
            MenuId = 0;
            ParentId = 0;
            MenuName = string.Empty;
            MenuUrl = string.Empty;
            Note = string.Empty;
            OrderValue = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
