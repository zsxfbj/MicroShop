using System.Text.Json.Serialization;
using MicroShop.Utility.Serialize.Json;

namespace MicroShop.Model.VO.Permission
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    [Serializable]
    public class RoleMenuVO
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long RoleId { get; set; } = 0L;

        /// <summary>
        /// 菜单编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long MenuId { get; set; } = 0L;

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 上级菜单编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long ParentId { get; set; } = 0;

        /// <summary>
        /// 下级菜单
        /// </summary>
        public List<RoleMenuVO> SubMenus { get; set; } = new List<RoleMenuVO>();
    }
}
