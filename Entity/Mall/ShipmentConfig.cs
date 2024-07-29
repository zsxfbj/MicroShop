using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enums.Product;

namespace MicroShop.Entity.Mall
{
    /// <summary>
    /// 运费设置
    /// </summary>
    [Serializable]
    [Table("shipment_config")]
    public class ShipmentConfig
    {
        /// <summary>
        /// 配置编号
        /// </summary>
        [Key]
        [Column("config_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ConfigId { get; set; }

        /// <summary>
        /// 模板编号
        /// </summary>      
        [Column("template_id")]
        public int TemplateId { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [Column("province")]
        public string Province { get; set; }  = string.Empty;

        /// <summary>
        /// 城市
        /// </summary>
        [Column("city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// 支持配送
        /// </summary>
        [Column("support_shipment")]
        public bool SupportShipment { get; set; }

        /// <summary>
        /// 运费计费类型
        /// </summary>
        [Column("shipment_fee_type")]
        public ShipmentFeeTypeEnum ShipmentFeeType { get; set; }

        /// <summary>
        /// 首重费用
        /// </summary>
        [Column("init_fee")]
        public decimal InitFee { get; set; }

        /// <summary>
        /// 起付体积/体积
        /// </summary>
        [Column("init_value")]
        public decimal InitValue { get; set; }

        /// <summary>
        /// 续费费用
        /// </summary>
        [Column("init_fee")]
        public decimal RenewalFee { get; set; }

        /// <summary>
        /// 续费重量/体积
        /// </summary>
        [Column("init_value")]
        public decimal RenewalValue { get; set; }

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
