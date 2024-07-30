using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MicroShop.Utility.Serialize.Json;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 修改菜单请求
    /// </summary>
    [Serializable]
    public class ModifyMenuReqDTO : CreateMenuReqDTO
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        [Required(ErrorMessage = "菜单编号不能为空")]
        [Range(1, long.MaxValue, ErrorMessage = "菜单编号格式错误")]
        [JsonConverter(typeof(LongToStringConverter))]
        public long MenuId { get; set; } = 0L;
    }
}
