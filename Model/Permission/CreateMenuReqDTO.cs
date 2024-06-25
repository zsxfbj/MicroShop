using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 创建菜单请求
    /// </summary>
    [Serializable]
    public class CreateMenuReqDTO
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单必须填写")]
        [StringLength(20, ErrorMessage = "菜单名称最多20个字")]
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 上级菜单
        /// </summary>
        [Required(ErrorMessage = "必须指定上级菜单")]
        [Range(0, int.MaxValue, ErrorMessage = "上级菜单编号格式错误")]
        public int ParentId { get; set; } = 0;

        /// <summary>
        /// 菜单地址
        /// </summary>
        [StringLength(200, ErrorMessage = "菜单地址最多200个字")]
        public string MenuUrl { get; set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderValue { get; set; } = 1;

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200, ErrorMessage = "备注最多200个字")]
        public string Note { get; set; } = string.Empty;       
    }
}
