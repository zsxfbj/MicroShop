using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Product.Enums;

namespace MicroShop.Product.Entity
{
    /// <summary>
    /// 产品表
    /// </summary>
    [Serializable]
    [Table("product")]
    public class ProductPO
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
        public CurrencyTypeEnum CurrencyType { get; set; }

        /// <summary>
        /// 市场价(范围价格)
        /// </summary>
        [Column("market_price")]
        public string MarketPrice { get; set; }

        /// <summary>
        /// 销售价格(范围价格)
        /// </summary>
        [Column("selling_price")]        
        public string SellingPrice { get; set; }

        /// <summary>
        /// 是否包邮
        /// </summary>
        [Column("free_shipment")]
        public bool FreeShipment { get; set; }

        /// <summary>
        /// 服务承诺
        /// </summary>
        [Column("service_commitment")]
        public string ServiceCommitment { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [Column("supplier_id")]
        public int SupplierId { get; set; }

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
    }
}
