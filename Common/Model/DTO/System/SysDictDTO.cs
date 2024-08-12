using System.Text.Json.Serialization;
using MicroShop.Common.Model.Serialize.Json;

namespace MicroShop.Common.Model.DTO.System
{
    /// <summary>
    /// 系统字典
    /// </summary>
    public class SysDictDTO
    {
        /// <summary>
        /// 自增Id
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long Id { get; set; } = 0L;

        /// <summary>
        /// 分类编码
        /// </summary>
        public string TypeCode { get; set; } = string.Empty;

        /// <summary>
        /// 键名
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// 键值
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Note {  get; set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        public int SortValue { get; set; } = 1;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; } = true;
    }
}
