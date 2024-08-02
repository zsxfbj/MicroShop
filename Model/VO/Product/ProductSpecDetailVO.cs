using System.ComponentModel;
using System.Text.Json.Serialization;
using MicroShop.Model.Serialize.Json;

namespace MicroShop.Model.VO.Product
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductSpecDetailVO
    {
        /// <summary>
        /// 产品SKU编号
        /// </summary>
        [Description("产品SKU编号"), DefaultValue(0), JsonConverter(typeof(LongToStringConverter))]
        public long SpecDetailId { get; set; } = 0L;

        /// <summary>
        /// 产品编号
        /// </summary>     
        [Description("产品编号")]
        public int ProductId { get; set; } = 0;

        /// <summary>
        /// 产品SKU编码
        /// </summary>     
        [Description("产品SKU编码")]
        public string ProductSpecDetailCode { get; set; } = string.Empty;

    }
}
