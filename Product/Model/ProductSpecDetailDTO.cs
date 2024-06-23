using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 产品SKU视图
    /// </summary>
    [Serializable]
    public class ProductSpecDetailDTO
    {
        /// <summary>
        /// 产品SKU编号
        /// </summary>
        [JsonConverter(typeof(Utility.Serialize.Json.LongToStringConverter))]
        [Description("产品SKU编号")]
        [DefaultValue(0L)]
        public long SpecDetailId { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        [DefaultValue(0)]
        [Description("产品编号")]
        public int ProductId { get; set; }

        /// <summary>
        /// 产品SKU编码
        /// </summary>
        [DefaultValue("")]
        [Description("产品SKU编码")]
        public string ProductSpecDetailCode { get; set; }


    }
}
