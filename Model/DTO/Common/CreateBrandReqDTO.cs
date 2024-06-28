using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MicroShop.Model.DTO.Common
{
    /// <summary>
    /// 创建品牌信息的请求
    /// </summary>
    [Serializable]
    public class CreateBrandReqDTO
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Description("品牌名称")]
        [Required(ErrorMessage = "品牌名称必须填写")]
        [StringLength(30, ErrorMessage = "品牌名称最多30个字")]      
        public string BrandName { get; set; } = string.Empty;

        /// <summary>
        /// 前缀
        /// </summary>         
        [Description("前缀，品牌英文单词（或者拼音）首字母")]
        [Required(ErrorMessage = "前缀必须填写")]
        [StringLength(1, ErrorMessage = "品牌名称为1个字母")]       
        public string Prefix { get; set; } = string.Empty;


        /// <summary>
        /// 品牌简介
        /// </summary>
        [Description("品牌简介")]       
        [StringLength(200, ErrorMessage = "品牌简介最多200个字")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 品牌英文名
        /// </summary>
        [Description("品牌英文或者拼音名称，最多60个字")]
        [StringLength(60, ErrorMessage = "品牌英文名称最多60个字")]        
        public string BrandEnglishName { get; set; } = string.Empty;

        /// <summary>
        /// 品牌Logo
        /// </summary>
        [Description("品牌Logo图片地址，最多256个字")]       
        public string LogoUrl { get; set; } = string.Empty;

        /// <summary>
        /// 是否推荐
        /// </summary>
        [Description("是否推荐，1：是；0：否")]     
        public bool IsRecommend { get; set; } = false;

       
    }
}
