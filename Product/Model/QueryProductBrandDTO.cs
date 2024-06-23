using System.ComponentModel.DataAnnotations;
using MicroShop.Web.Common;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 查询品牌
    /// </summary>
    public class QueryProductBrandDTO : PageRequestDTO
    {
        /// <summary>
        /// 查询的关键词
        /// </summary>
        [StringLength(30, ErrorMessage = "关键词最多30个字")]
        public string Keyword { get; set; }

        /// <summary>
        /// 首字符
        /// </summary>
        [StringLength(1, ErrorMessage = "首字符就一个字符")]
        public string Prefix { get; set; }

        /// <summary>
        /// 是否推荐：0-否；1-是
        /// </summary>
        public int? IsRecommend { get; set; }
    }
}
