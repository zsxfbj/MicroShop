using System;
using System.ComponentModel;
using MicroShop.Enum.Product;

namespace MicroShop.Model.VO.Product
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductDetailVO
    {
        /// <summary>
        /// 产品编号
        /// </summary>      
        [Description("产品编号")]
        public int ProductId { get; set; } = 0;

        /// <summary>
        /// 产品类型
        /// </summary>     
        [Description("产品类型")]
        public ProductTypes ProductType { get; set; } = ProductTypes.PhysicalProduct;

        /// <summary>
        /// 产品类型名称
        /// </summary>       
        [Description("产品类型名称")]
        public string ProductTypeName { get; set; } = string.Empty;

        /// <summary>
        /// 产品名称
        /// </summary>        
        [Description("产品名称")]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// 产品描述
        /// </summary>
        [DefaultValue("")]
        [Description("产品描述")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [DefaultValue("2020-01-01 00:00:00")]
        [System.Text.Json.Serialization.JsonConverter(typeof(Serialize.Json.DefaultDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        [DefaultValue("2020-01-01 00:00:00")]
        [System.Text.Json.Serialization.JsonConverter(typeof(Serialize.Json.DefaultDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

    }
}
