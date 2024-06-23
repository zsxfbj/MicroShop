using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.Product.Entity
{
    /// <summary>
    /// 品牌表
    /// </summary>
    [Table("brand")]
    [Serializable]
    public class BrandPO
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        [Key]
        [Column("brand_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 BrandId { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [Column("brand_name")]        
        [MaxLength(32)]
        public String BrandName { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>
        [Column("prefix")]
        [MaxLength(1)]
        public String Prefix { get; set; }

        /// <summary>
        /// 品牌描述
        /// </summary>
        [Column("description")]
        [MaxLength(256)]
        public string Description { get; set; }

        /// <summary>
        /// 品牌英文名
        /// </summary>
        [Column("brand_english_name")]
        [MaxLength(64)]
        public String BrandEnglishName { get; set; }

        /// <summary>
        /// 品牌Logo地址
        /// </summary>
        [Column("logo_url")]
        [MaxLength(256, ErrorMessage = "logo图片地址长度不能超过250个字符")]
        public String LogoUrl { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        [Column("is_recommend")]       
        public Boolean IsRecommend { get; set; }

        /// <summary>
		/// 创建时间
		/// </summary>
		[Column("created_at")]      
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at")]        
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public BrandPO()
        {
            BrandId = 0;
            BrandName = "";
            Prefix = "";
            BrandEnglishName = "";
            Description = "";
            LogoUrl = "";
            IsRecommend = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}
