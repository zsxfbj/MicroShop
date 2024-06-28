using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        [JsonConverter(typeof(Utility.Serialize.Json.LongToStringConverter))]
        [Description("产品SKU编号")]
        [DefaultValue(0L)]
        public long SpecDetailId { get; set; }

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
