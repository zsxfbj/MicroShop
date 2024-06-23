using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.Product.Entity
{
    /// <summary>
    /// 产品具体规格信息表
    /// </summary>
    [Serializable]
    [Table("product_spec_detail")]
    public class ProductSpecDetailPO
    {
        /// <summary>
        /// 单元编号
        /// </summary>
        [Key]
        [Column("spec_detail_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SpecDetailId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        [Column("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// SKU具体详情
        /// </summary>        
        [Column("spec_detail")]     
        public string SpecDetail { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        [Column("bar_code")]
        public string BarCode { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        [Column("custom_code")]
        public string CustomCode { get; set; }       

        /// <summary>
        /// 市场价
        /// </summary>
        [Column("market_price")]
        public decimal MarketPrice { get; set; }

        /// <summary>
        /// 销售价格
        /// </summary>
        [Column("selling_price")]
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        [Column("cost_price")]
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 库存量
        /// </summary>
        [Column("stock")]
        public int Stock { get; set; }

        /// <summary>
        /// 销售量
        /// </summary>
        [Column("sales_amount")]
        public int SalesAmount { get; set; }

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
        public ProductSpecDetailPO()
        {
            SpecDetailId = 0L;
            ProductId = 0;
            SpecDetail = "";
            BarCode = "";
            CustomCode = "";
            MarketPrice = decimal.Zero;
            SellingPrice = decimal.Zero;
            CostPrice = decimal.Zero;
            Stock = 0;
            SalesAmount = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
