using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Product
{
    /// <summary>
    /// 产品规格值
    /// </summary>
    [Serializable]
    [Table("product_spec_option")]
    public class ProductSpecOption
    {
        /// <summary>
        /// 单位值编号
        /// </summary>
        [Key]
        [Column("spec_option_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SpecOptionId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        [Column("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// sku名称编号
        /// </summary>
        [Key]
        [Column("spec_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SpecId { get; set; }

        /// <summary>
        /// 产品规格选项名称
        /// </summary>
        [Column("spec_option_name")]
        public string SpecOptionName { get; set; }

        /// <summary>
        /// 产品规格图片地址
        /// </summary>
        [Column("spec_option_image")]
        public string SpecOptionImage { get; set; }

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
        public ProductSpecOption()
        {
            SpecOptionId = 0L;
            SpecId = 0L;
            ProductId = 0;
            SpecOptionName = "";
            SpecOptionImage = "";
            OrderValue = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
