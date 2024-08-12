using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MicroShop.Common.Model.DTO.Permission
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
        [JsonConverter(typeof(Serialize.Json.LongArrayToStringArrayConverter))]
        public List<long>? LogIds { get; set; }
    }
}
