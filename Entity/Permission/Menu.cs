using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enums.Permission;

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
        [Column("menu_name", TypeName = "nvarchar(32)")]
        [Required(ErrorMessage = "菜单名称必须填写"), MaxLength(30, ErrorMessage = "菜单名称不能超过30个字")]
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 菜单类型
        /// </summary>
        [Column("menu_type", TypeName = "int")]
        public MenuTypeEnum MenuType { get; set; } = MenuTypeEnum.Text;

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Column("path", TypeName = "varchar(256)")]
        [MaxLength(255, ErrorMessage = "菜单地址不能超过255个字符")]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Icon配置
        /// </summary>
        [Column("icon", TypeName = "varchar(256)")]
        [MaxLength(255, ErrorMessage = "Icon配置不能超过255个字符")]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 组件名称
        /// </summary>
        [Column("component_name", TypeName = "varchar(64)")]
        [StringLength(64, ErrorMessage = "组件名称最多60个字符")]
        public string ComponentName { get; set; } = string.Empty;

        /// <summary>
        /// 组件配置内容
        /// </summary>
        [Column("component_config", TypeName = "varchar(256)")]
        [StringLength(250, ErrorMessage = "组件配置最多250个字符")]
        public string ComponentConfig { get; set; } = string.Empty;

        /// <summary>
        /// 权限
        /// </summary>
        [Column("permission", TypeName = "varchar(256)")]
        [StringLength(200, ErrorMessage = "权限最多200个字符")]
        public string Permission { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        [Column("is_enable", TypeName = "bit")]
        [Required(ErrorMessage = "必须选择是否启用")]
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 排序值
        /// </summary>
        [Column("order_value", TypeName = "int")]
        public int OrderValue { get; set; } = 1;

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note", TypeName = "nvarchar(256)")]
        [MaxLength(256, ErrorMessage = "备注不能超过250个字")]
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
    }
}
