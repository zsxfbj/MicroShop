using System;
using System.ComponentModel;
using MicroShop.Product.Enums;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 产品详细视图
    /// </summary>
    [Serializable]
    public class ProductDetailDTO
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        [DefaultValue(0)]
        [Description("产品编号")]
        public int ProductId { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DefaultValue(ProductTypeEnum.PhysicalProduct)]
        [Description("产品类型")]
        public ProductTypeEnum ProductType { get; set; }

        /// <summary>
        /// 产品类型名称
        /// </summary>
        [DefaultValue("实物产品")]
        [Description("产品类型名称")]
        public string ProductTypeName { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DefaultValue("")]
        [Description("产品名称")]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        [DefaultValue("")]
        [Description("产品描述")]
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [DefaultValue("2020-01-01 00:00:00")]
        [System.Text.Json.Serialization.JsonConverter(typeof(Utility.Serialize.Json.DefaultDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        [DefaultValue("2020-01-01 00:00:00")]
        [System.Text.Json.Serialization.JsonConverter(typeof(Utility.Serialize.Json.DefaultDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}
