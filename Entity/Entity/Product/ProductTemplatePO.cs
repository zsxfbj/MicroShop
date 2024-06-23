using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Entity.Product
{
    /// <summary>
    /// 商品信息模板表(相当于商品模板信息)
    /// </summary>
    [Serializable]
    [Table("product_template")]
    public class ProductTemplatePO
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        [Key]
        [Column("product_template_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTemplateId { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        [Column("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 商品模板名称
        /// </summary>
        [Column("product_template_nanme")]
        public string ProductTemplateName { get; set; }

        /// <summary>
        /// 所属品牌编号
        /// </summary>
        [Column("brand_id")]
        public int BrandId { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [Column("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// 商品简单描述
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        [Column("detail")]
        public string Detail { get; set; }

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
        public ProductTemplatePO()
        {
            ProductTemplateId = 0;
            ProductTemplateName = "";
            BrandId = 0;
            Description = "";
            Detail = "";
            ThumbnailUrl = "";
            CategoryId = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}
