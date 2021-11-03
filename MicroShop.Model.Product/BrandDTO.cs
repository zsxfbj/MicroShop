using System;
using System.ComponentModel;

namespace MicroShop.Model.Product
{
    /// <summary>
    /// 品牌视图
    /// </summary>
    [Serializable]
    public class BrandDTO
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        [Description("品牌编号，自增编号")]
        [DisplayName("品牌编号")]
        public Int32 BrandId { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [Description("品牌名称，最多30个字")]
        [DisplayName("品牌名称")]
        public String BrandName { get; set; }

        /// <summary>
        /// 品牌英文名
        /// </summary>
        [Description("品牌英文或者拼音名称，最多64个字")]
        [DisplayName("品牌英文名")]
        public String BrandEnglishName { get; set; }

        /// <summary>
        /// 品牌Logo
        /// </summary>
        [Description("品牌Logo图片地址，最多256个字")]
        [DisplayName("品牌Logo")]
        public String LogoUrl { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        [Description("是否推荐，true：是；false：否")]
        [DisplayName("是否推荐")]
        public Boolean IsRecommend { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>
        [Description("前缀，品牌英文单词（或者拼音）首字母")]
        [DisplayName("前缀")]
        public String PreFix { get; set; }

    }
}
