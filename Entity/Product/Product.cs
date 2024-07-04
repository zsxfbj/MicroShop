using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enums.Payment;
using MicroShop.Enums.Product;

namespace MicroShop.SQLServerDAL.Product
{
    /// <summary>
    /// 产品表
    /// </summary>
    [Serializable]
    [Table("product")]
    public class Product
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [Key]
        [Column("product_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        [Column("product_type")]
        public ProductTypeEnum ProductType { get; set; }

        /// <summary>
        /// 产品标题
        /// </summary>
        [Column("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品单描述
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// 产品镖旗
        /// </summary>
        [Column("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// 所属品牌编号
        /// </summary>
        [Column("brand_id")]
        public int BrandId { get; set; }

        /// <summary>
        /// 是否品牌精选
        /// </summary>
        [Column("superior_brand")]
        public bool SuperiorBrand { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        [Column("hot_flag")]
        public bool HotFlag { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [Column("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        [Column("currency_type")]
        public CurrencyTypeEnum CurrencyType { get; set; } = CurrencyTypeEnum.RMB;

        /// <summary>
        /// 市场价(范围价格)
        /// </summary>
        [Column("market_price")]
        public string MarketPrice { get; set; } = string.Empty;

        /// <summary>
        /// 销售价格(范围价格)
        /// </summary>
        [Column("selling_price")]
        public string SellingPrice { get; set; } = string.Empty;

        /// <summary>
        /// 是否包邮
        /// </summary>
        [Column("free_shipment")]
        public bool FreeShipment { get; set; } = false;

        /// <summary>
        /// 服务承诺
        /// </summary>
        [Column("service_commitment")]
        public string ServiceCommitment { get; set; } = string.Empty;

        /// <summary>
        /// 供应商编号
        /// </summary>
        [Column("supplier_id")]
        public int SupplierId { get; set; } = 0;

        /// <summary>
        /// 运费模板编号
        /// </summary>
        [Column("shipment_template_id")]
        public int ShipmentTemplateId { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        [Column("product_status")]
        public ProductStatusEnum ProductStatus { get; set; }

        /// <summary>
        /// 文本详情
        /// </summary>
        [Column("text_detail")]
        public string TextDetail { get; set; }

        /// <summary>
        /// 商品图片详情
        /// </summary>
        [Column("image_detail")]
        public string ImageDetail { get; set; }

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
        /// 
        /// </summary>
        public Product()
        {
            ProductId = 0;
            ProductType = ProductTypeEnum.PhysicalProduct;
            ProductName = string.Empty;
            Description = string.Empty;
            Tags = string.Empty;
            BrandId = 0;
            SuperiorBrand = false;
            HotFlag = false;
            ThumbnailUrl = string.Empty;
            CurrencyType = CurrencyTypeEnum.RMB;
            MarketPrice = string.Empty;
            SellingPrice = string.Empty;
            FreeShipment = false;
            ServiceCommitment = string.Empty;
            SupplierId = 0;
            ShipmentTemplateId = 0;
            ProductStatus = ProductStatusEnum.Draft;
            TextDetail = string.Empty;
            ImageDetail = string.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
