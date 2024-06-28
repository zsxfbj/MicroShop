using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.DTO.Common
{
    /// <summary>
    /// 修改分类请求
    /// </summary>
    [Serializable]
    public class ModifyCategoryReqDTO : CreateCategoryReqDTO
    {
        /// <summary>
        /// 分类编号
        /// </summary>
        [Required(ErrorMessage = "分类编号必须填写")]
        [Range(1, int.MaxValue, ErrorMessage = "分类编号格式错误")]
        public int CategoryId { get; set; } = 0;
    }
}
