using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Entity.Product
{
    /// <summary>
    /// 运费模板
    /// </summary>
    [Serializable]
    [Table("shipment_template")]
    public class ShipmentTemplate
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        [Key]
        [Column("template_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateId { get; set; }

        /// <summary>
        /// 运费模板
        /// </summary>
        [Column("template_name")]
        public string TemplateName { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [Column("supplier_id")]
        public int SupplierId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("note")]
        public string Note { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        [Column("is_default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

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
        public ShipmentTemplate()
        {
            TemplateId = 0;
            TemplateName = "";
            SupplierId = 0;
            Note = "";
            IsDefault = false;
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
