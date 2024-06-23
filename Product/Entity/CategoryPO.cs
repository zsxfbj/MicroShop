using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.Product.Entity
{
    /// <summary>
    /// 商品目录表
    /// </summary>
    [Serializable]
    [Table("category")]
    public class CategoryPO
    {
        /// <summary>
        /// 目录编号
        /// </summary>
        [Key]
        [Column("category_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        /// <summary>
        /// 目录名称
        /// </summary>
        [Column("category_name")]
        [MaxLength(32)]
        public string CategoryName { get; set; }

        /// <summary>
        /// 上级编号
        /// </summary>
        [Column("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// 级别全路径
        /// </summary>
        [Column("full_path")]
        public string FullPath { get; set; }

        /// <summary>
        /// 分类图片路径
        /// </summary>
        [Column("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Icon图片路径
        /// </summary>
        [Column("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note")]
        public string Note { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Column("order_value")]
        public int OrderValue { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CategoryPO()
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
