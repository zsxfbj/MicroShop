using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Common
{
    /// <summary>
    /// 品牌表
    /// </summary>
    [Table("brand")]
    [Serializable]
    public class Brand
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        [Key]
        [Column("brand_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; } = 0;

        /// <summary>
        /// 品牌名称
        /// </summary>
        [Column("brand_name")]
        [MaxLength(32)]
        public string BrandName { get; set; } = string.Empty;

        /// <summary>
        /// 前缀
        /// </summary>
        [Column("prefix")]
        [MaxLength(1)]
        public string Prefix { get; set; } = string.Empty;

        /// <summary>
        /// 品牌描述
        /// </summary>
        [Column("description")]
        [MaxLength(256)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 品牌英文名
        /// </summary>
        [Column("brand_english_name")]
        [MaxLength(64)]
        public string BrandEnglishName { get; set; } = string.Empty;

        /// <summary>
        /// 品牌Logo地址
        /// </summary>
        [Column("logo_url")]
        [MaxLength(256, ErrorMessage = "logo图片地址长度不能超过250个字符")]
        public string LogoUrl { get; set; } = string.Empty;

        /// <summary>
        /// 是否推荐
        /// </summary>
        [Column("is_recommend")]
        public bool IsRecommend { get; set; } = false;

        /// <summary>
		/// 创建时间
		/// </summary>
		[Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public Brand()
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
