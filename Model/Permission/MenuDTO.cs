using System;
using MicroShop.Utility.Serialize.Json;
using System.Text.Json.Serialization;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 菜单数据视图
    /// </summary>
    [Serializable]
    public class MenuDTO
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 上级菜单编号
        /// </summary>
        public int ParentId { get; set; } = 0;

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string MenuUrl { get; set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderValue { get; set; } = 1;

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
