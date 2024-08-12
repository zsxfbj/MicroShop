using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MicroShop.Common.Model.Serialize.Json;

namespace MicroShop.Common.Model.DTO.Permission
{
    /// <summary>
    /// 修改系统用户请求
    /// </summary>
    [Serializable]
    public class ModifySystemUserReqDTO : CreateSystemUserReqDTO
    {
        /// <summary>
        /// 系统用户编号
        /// </summary>
        [Required(ErrorMessage = "系统用户编号不能为空")]
        [Range(1, long.MaxValue, ErrorMessage = "请指定要修改的系统用户")]
        [JsonConverter(typeof(LongToStringConverter))]
        public long UserId { get; set; } = 0L;

    }
}
