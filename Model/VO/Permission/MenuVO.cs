using MicroShop.Enums.Permission;
using MicroShop.Utility.Serialize.Json;
using System.Text.Json.Serialization;

namespace MicroShop.Model.VO.Permission
{
    /// <summary>
    /// 菜单数据视图
    /// </summary>
    [Serializable]
    public class MenuVO
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long MenuId { get; set; }

        /// <summary>
        /// 上级菜单编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long ParentId { get; set; } = 0;

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuTypeEnum MenuType { get; set; } = MenuTypeEnum.Text;

        /// <summary>
        /// 地址
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon {  get; set; } = string.Empty;   

        /// <summary>
        /// 组件名称
        /// </summary>
        public string ComponentName {  get; set; } = string.Empty;

        /// <summary>
        /// 组件配置内容
        /// </summary>
        public string ComponentConfig { get; set; } = string.Empty;

        /// <summary>
        /// 权限
        /// </summary>
        public string Permission { get; set; } = string.Empty; 

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hidden { get; set; } = false;

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
