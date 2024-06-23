using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Entity.Common
{
    /// <summary>
    /// 商品目录表
    /// </summary>
    [Serializable]
    [Table("category")]
    public class Category
    {
        /// <summary>
        /// 目录编号
        /// </summary>
        [Key]
        [Column("category_id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } = 0;

        /// <summary>
        /// 分类名称
        /// </summary>
        [Column("category_name", TypeName = "nvarchar(32)")]
        [Required(ErrorMessage = "分类名称不能为空")]
        [MaxLength(32)]
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// 分类类型：1-商品
        /// </summary>
        [Column("category_type", TypeName = "int")]
        public int CategoryType { get; set; } = 1;

        /// <summary>
        /// 上级编号
        /// </summary>
        [Column("parent_id", TypeName = "int")]
        public int ParentId { get; set; } = 0;

        /// <summary>
        /// 级别全路径
        /// </summary>
        [Column("full_path")]
        public string FullPath { get; set; } = string.Empty;

        /// <summary>
        /// 分类图片路径
        /// </summary>
        [Column("image_url")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Icon图片路径
        /// </summary>
        [Column("icon_url")]
        public string IconUrl { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        [Column("order_value")]
        public int OrderValue { get; set; } = 1;

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
        public Category()
        {
            CategoryId = 0;
            CategoryName = "";
            ParentId = 0;
            FullPath = "";
            ImageUrl = "";
            IconUrl = "";
            Note = "";
            OrderValue = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
