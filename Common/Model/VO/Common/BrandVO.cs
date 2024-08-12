using System;
using System.ComponentModel;

namespace MicroShop.Common.Model.VO.Common
{
    /// <summary>
    /// 品牌视图
    /// </summary>
    [Serializable]
    public class BrandVO
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        [Description("品牌编号，自增编号")]
        [DefaultValue(0)]
        public int BrandId { get; set; } = 0;

        /// <summary>
        /// 品牌名称
        /// </summary>
        [Description("品牌名称，最多30个字")]
        [DefaultValue("")]
        public string BrandName { get; set; } = string.Empty;

        /// <summary>
        /// 前缀
        /// </summary>
        [DefaultValue("")]
        [Description("前缀，品牌英文单词（或者拼音）首字母")]
        public string Prefix { get; set; } = string.Empty;

        /// <summary>
        /// 品牌英文名
        /// </summary>
        [Description("品牌英文或者拼音名称，最多64个字")]
        [DefaultValue("")]
        public string BrandEnglishName { get; set; } = string.Empty;

        /// <summary>
        /// 品牌简介
        /// </summary>
        [Description("品牌简介")]
        [DefaultValue("")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 品牌Logo
        /// </summary>
        [Description("品牌Logo图片地址，最多256个字")]
        public string LogoUrl { get; set; } = string.Empty;

        /// <summary>
        /// 是否推荐
        /// </summary>
        [Description("是否推荐，true：是；false：否")]
        public bool IsRecommend { get; set; } = false;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [DefaultValue("2020-01-01 00:00:00")]
        [System.Text.Json.Serialization.JsonConverter(typeof(Serialize.Json.DefaultDateTimeConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        [DefaultValue("2020-01-01 00:00:00")]
        [System.Text.Json.Serialization.JsonConverter(typeof(Serialize.Json.DefaultDateTimeConverter))]
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;

         
    }
}
