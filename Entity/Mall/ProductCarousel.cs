using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MicroShop.Enum.Common;

namespace MicroShop.Entity.Mall
{
    /// <summary>
    /// 商品轮播图表
    /// </summary>
    [Serializable]
    [Table("product_carousel")]
    public class ProductCarousel
    {
        /// <summary>
        /// 轮播图编号
        /// </summary>
        [Key]
        [Column("carousel_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CarouselId { get; set; } = 0;

        /// <summary>
        /// 商品编号
        /// </summary>
        [Column("product_id")]
        public int ProductId { get; set; } = 0;

        /// <summary>
        /// 媒体类型：1-图片；2-视频
        /// </summary>
        [Column("media_type")]
        public MediaTypes MediaType { get; set; } = MediaTypes.Image;

        /// <summary>
        /// 媒体访 nnnnnn问地址
        /// </summary>
        [Column("media_url")]
        public string MediaUrl { get; set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        [Column("order_value")]
        public int OrderValue { get; set; } = 1;

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
        /// 产品轮播表
        /// </summary>
        public ProductCarousel()
        {
            CarouselId = 0;
            ProductId = 0;
            MediaType = MediaTypes.Image;
            MediaUrl = "";
            OrderValue = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
