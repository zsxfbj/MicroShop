using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using MicroShop.Model.Serialize.Json;

namespace MicroShop.Model.VO.Common
{
    /// <summary>
    /// 分类视图
    /// </summary>
    [Serializable]
    public class CategoryVO
    {
        /// <summary>
        /// 目录编号
        /// </summary>
        [DefaultValue(0)]
        [Description("目录编号")]
        public int CategoryId { get; set; } = 0;

        /// <summary>
        /// 目录名称
        /// </summary>
        [DefaultValue("食品")]
        [Description("目录名称")]
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// 分类类型
        /// </summary>
        [Description("分类类型")]
        [DefaultValue(1)]
        public int CategoryType { get; set; } = 1;

        /// <summary>
        /// 分类类型名称
        /// </summary>
        [Description("分类类型名称")]
        [DefaultValue("商品")]
        public string CategoryTypeName { get; set; } = string.Empty;

        /// <summary>
        /// 上级编号
        /// </summary>        
        [Description("上级编号")]
        public int ParentId { get; set; } = 0;

        /// <summary>
        /// 级别全路径
        /// </summary>
        [Description("级别全路径")]
        public string FullPath { get; set; } = string.Empty;

        /// <summary>
        /// 缩略图地址
        /// </summary>
        [Description("缩略图地址")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// ICON图地址
        /// </summary>
        [Description("ICON图地址")]
        public string IconUrl { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        [Description("排序值")]
        [DefaultValue(1)]
        public int OrderValue { get; set; } = 1;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CategoryVO()
        {
            CategoryId = 0;
            CategoryName = "";
            ParentId = 0;
            FullPath = "";
            ImageUrl = "";
            IconUrl = "";
            Note = "";
            OrderValue = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}
