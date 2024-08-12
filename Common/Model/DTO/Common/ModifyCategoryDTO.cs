using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MicroShop.Common.Model.Serialize.Json;

namespace MicroShop.Common.Model.DTO.Common
{
    /// <summary>
    /// 修改分类请求
    /// </summary>
    [Serializable]
    public class ModifyCategoryReqDTO : CreateCategoryReqDTO
    {
        /// <summary>
        /// 分类编号
        /// </summary>
        [Required(ErrorMessage = "分类编号必须填写")]
        [Range(1, long.MaxValue, ErrorMessage = "分类编号格式错误")]
        [JsonConverter(typeof(LongToStringConverter))]
        public long CategoryId { get; set; } = 0L;
    }
}
