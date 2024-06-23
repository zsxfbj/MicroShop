﻿using System.Text.Json.Serialization;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 批量删除日志
    /// </summary>
    [Serializable]
    public class BatchDeleteSystemUserActionLogsDTO
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        [JsonConverter(typeof(Utility.Serialize.Json.LongArrayToStringArrayConverter))]
        public List<long>? LogIds { get; set; }
    }
}
