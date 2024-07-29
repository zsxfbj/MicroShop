using System.ComponentModel;
using System.Text.Json.Serialization;
using MicroShop.Utility.Serialize.Json;

namespace MicroShop.Model.DTO.Product
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
        [JsonConverter(typeof(LongToStringConverter))]
        [Description("规格编号")]       
        public long SpecId { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        [Description("规格名称")]      
        public string SpecName { get; set; } = string.Empty;

        /// <summary>
        /// 规格选项编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        [Description("规格选项编号")]
        public long SpecOptionId { get; set; } = 0L;

        /// <summary>
        /// 规格选择名称
        /// </summary>
        [Description("规格选择名称")]
        public string SpecOptionName { get; set; } = string.Empty;

        /// <summary>
        /// 规格选择图片
        /// </summary>
        [Description("规格选择图片")]
        public string SpecOptionImage { get; set; } = string.Empty;

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
