using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MicroShop.Model.Serialize.Json;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 批量删除日志
    /// </summary>
    [Serializable]
    public class BatchDeleteLogReqDTO
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        [JsonConverter(typeof(LongArrayToStringArrayConverter))]
        public List<long>? LogIds { get; set; }
    }
}
