using System;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 修改产品品牌信息
    /// </summary>
    [Serializable]
    public class ModifyProductBrandDTO : CreateProductBrandDTO
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        [Required(ErrorMessage = "品牌编号不能为空")]
        [Range(1, int.MaxValue, ErrorMessage = "编号不能小于0")]
        public int BrandId { get; set; }         
    }
}
