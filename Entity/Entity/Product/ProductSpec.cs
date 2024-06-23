using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Entity.Product
{
    /// <summary>
    /// 产品规格名称
    /// </summary>
    [Serializable]
    [Table("product_spec")]
    public class ProductSpec
    {
        /// <summary>
        /// 单位名称编号
        /// </summary>
        [Key]
        [Column("spec_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SpecId { get; set; } = default(long);

        /// <summary>
        /// 商品编号
        /// </summary>
        [Column("product_id")]
        public int ProductId { get; set; } = 0;

        /// <summary>
        /// 单位名称
        /// </summary>
        [Column("spec_name")]
        public string SpecName { get; set; } = string.Empty;

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
        public ProductSpec()
        {
            SpecId = 0L;
            SpecName = "";
            OrderValue = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}
