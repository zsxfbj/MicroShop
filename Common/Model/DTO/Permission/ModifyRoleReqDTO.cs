using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MicroShop.Common.Model.Serialize.Json;

namespace MicroShop.Common.Model.DTO.Permission
{
    /// <summary>
    /// 修改角色信息请求
    /// </summary>
    [Serializable]
    public class ModifyRoleReqDTO : CreateRoleReqDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Required(ErrorMessage = "角色编号不能为空")]
        [Range(1, long.MaxValue, ErrorMessage = "角色编号数据错误")]
        [JsonConverter(typeof(LongToStringConverter))]
        public long RoleId { get; set; }
    }
}
