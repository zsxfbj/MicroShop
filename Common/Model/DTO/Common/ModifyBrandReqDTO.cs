using System;
using System.ComponentModel.DataAnnotations;


namespace MicroShop.Model.DTO.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ModifyBrandReqDTO : CreateBrandReqDTO
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        [Required(ErrorMessage = "品牌编号不能为空")]
        [Range(1, int.MaxValue, ErrorMessage = "编号不能小于0")]
        public int BrandId { get; set; }

    }
}
