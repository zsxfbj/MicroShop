using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 创建产品品牌数据体
    /// </summary>
    [Serializable]
    public class CreateProductBrandDTO
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Description("品牌名称")]
        [Required(ErrorMessage = "品牌名称必须填写")]
        [StringLength(30, ErrorMessage = "品牌名称最多30个字")]
        [DefaultValue("可口可乐")]
        public string BrandName { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>         
        [Description("前缀，品牌英文单词（或者拼音）首字母")]
        [Required(ErrorMessage = "前缀必须填写")]
        [StringLength(1, ErrorMessage = "品牌名称为1个字母")]
        [DefaultValue("C")]
        public string Prefix { get; set; }


        /// <summary>
        /// 品牌简介
        /// </summary>
        [Description("品牌简介")]
        [DefaultValue("")]
        [StringLength(200, ErrorMessage = "品牌简介最多200个字")]
        public string Description { get; set; }

        /// <summary>
        /// 品牌英文名
        /// </summary>
        [Description("品牌英文或者拼音名称，最多60个字")]
        [StringLength(60, ErrorMessage = "品牌英文名称最多60个字")]
        [DefaultValue("Coca-Cola")]
        public string BrandEnglishName { get; set; }

        /// <summary>
        /// 品牌Logo
        /// </summary>
        [Description("品牌Logo图片地址，最多256个字")]
        [DefaultValue("")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        [Description("是否推荐，1：是；0：否")]
        [DefaultValue(0)]
        [Range(0,1, ErrorMessage = "推荐的值格式错误")]
        public int IsRecommend { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CreateProductBrandDTO()
        {
            BrandEnglishName = "";
            BrandName = "";
            Prefix = "";
            Description = "";
            LogoUrl = "";
            IsRecommend = 0;
        }

        #region public void InitData()
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (!string.IsNullOrEmpty(BrandName))
            {
                BrandName = BrandName.Trim();
            }

            if (!string.IsNullOrEmpty(BrandEnglishName))
            {
                BrandEnglishName = BrandEnglishName.Trim();
            }

            if (!string.IsNullOrEmpty(Prefix))
            {
                Prefix = Prefix.Trim();
            }

            if (!string.IsNullOrEmpty(Description))
            {
                Description = Description.Trim();
            }

            if (!string.IsNullOrEmpty(LogoUrl))
            {
                LogoUrl = LogoUrl.Trim();
            }
        }
        #endregion public void InitData()
   
    }
}
