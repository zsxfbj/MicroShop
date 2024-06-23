using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 设置分类的排序值
    /// </summary>
    [Serializable]
    public class SetProductCategoryOrderValueDTO
    {
        /// <summary>
        /// 分类编号
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "分类编号格式错误")]
        [Required(ErrorMessage = "分类编号必须指定")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Required(ErrorMessage = "请填写排序值")]
        public int OrderValue { get; set; }
    }
}
