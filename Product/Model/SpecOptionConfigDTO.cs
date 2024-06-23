using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 规格选项组
    /// </summary>
    [Serializable]
    public class SpecOptionConfigDTO
    {
        /// <summary>
        /// SKU名称编号
        /// </summary>
        [JsonConverter(typeof(Utility.Serialize.Json.LongToStringConverter))]
        [Description("规格编号")]
        [DefaultValue(0L)]
        public long SpecId { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        [Description("规格名称")]
        [DefaultValue("")]
        public string SpecName { get; set; }

        /// <summary>
        /// 规格选项编号
        /// </summary>
        [JsonConverter(typeof(Utility.Serialize.Json.LongToStringConverter))]
        [Description("规格选项编号")]
        [DefaultValue(0L)]
        public long SpecOptionId { get; set; }

        /// <summary>
        /// 规格选择名称
        /// </summary>
        [Description("规格选择名称")]
        [DefaultValue("")]
        public string SpecOptionName { get; set; }

        /// <summary>
        /// 规格选择图片
        /// </summary>
        [Description("规格选择图片")]
        [DefaultValue("")]
        public string SpecOptionImage { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SpecOptionConfigDTO()
        {
            SpecId = 0L;
            SpecOptionId = 0L;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="specId">规格编号</param>
        /// <param name="specOptionId">规格选项编号</param>
        public SpecOptionConfigDTO(long specId, long specOptionId)
        {
            SpecId = specId;
            SpecOptionId = specOptionId;
        }
    }
}
