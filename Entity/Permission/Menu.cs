using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enum.Permission;


namespace MicroShop.Entity.Permission
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
        [Column("menu_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MenuId { get; set; } = 0L;

        /// <summary>
        /// 上级菜单编号
        /// </summary>
        [Column("parent_id")]     
        public long ParentId { get; set; } = 0L;

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("menu_name")]    
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 菜单类型
        /// </summary>
        [Column("menu_type")]
        public MenuTypes MenuType { get; set; } = MenuTypes.Text;

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Column("path")]       
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Icon配置
        /// </summary>
        [Column("icon")]       
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 组件名称
        /// </summary>
        [Column("component_name")]       
        public string ComponentName { get; set; } = string.Empty;

        /// <summary>
        /// 组件配置内容
        /// </summary>
        [Column("component_config")]       
        public string ComponentConfig { get; set; } = string.Empty;

        /// <summary>
        /// 权限
        /// </summary>
        [Column("permission")]     
        public string Permission { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        [Column("is_enable")]      
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 是否隐藏
        /// </summary>
        [Column("hidden")]
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 排序值
        /// </summary>
        [Column("order_value")]
        public int OrderValue { get; set; } = 1;

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note")]       
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
