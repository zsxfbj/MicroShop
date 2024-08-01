using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MicroShop.Utility.Serialize.Json;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 角色菜单对应关系
    /// </summary>
    [Serializable]
    public class SetRoleMenuRelationReqDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Required(ErrorMessage = "角色编号不能为空")]
        [Range(1, long.MaxValue, ErrorMessage = "角色编号格式错误")]
        [JsonConverter(typeof(LongToStringConverter))]
        public long RoleId { get; set; } = 0;

        /// <summary>
        /// 菜单编号
        /// </summary>   
        [JsonConverter(typeof(LongArrayToStringArrayConverter))]
        public List<long> MenuIds { get; set; } = new List<long>();
    }
}
