using System;
using System.ComponentModel.DataAnnotations;
using MicroShop.Common.Enum.Permission;

namespace MicroShop.Common.Model.DTO.Permission
{
    /// <summary>
    /// 创建菜单请求
    /// </summary>
    [Serializable]
    public class CreateMenuReqDTO
    {
        /// <summary>
        /// 菜单类型
        /// </summary>
        [Required(ErrorMessage = "请选择菜单类型")]
        public MenuTypes MenuType { get; set; } = MenuTypes.Text;

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
        [StringLength(200, ErrorMessage = "菜单地址最多200个字符")]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// 图表样式
        /// </summary>
        [StringLength(200, ErrorMessage = "图表样式最多200个字符")]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 组件名称
        /// </summary>
        [StringLength(64, ErrorMessage = "组件名称最多60个字符")]
        public string ComponentName { get; set; } = string.Empty;

        /// <summary>
        /// 组件配置内容
        /// </summary>
        [StringLength(250, ErrorMessage = "组件配置最多250个字符")]
        public string ComponentConfig { get; set; } = string.Empty;

        /// <summary>
        /// 权限
        /// </summary>
        [StringLength(250, ErrorMessage = "权限最多250个字符")]
        public string Permission { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        [Required(ErrorMessage = "必须选择是否启用")]
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 是否隐藏
        /// </summary>
        [Required(ErrorMessage = "必须选择是否隐藏")]
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// 排序值（升序）
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "排序值必须大于等于0")]
        public int OrderValue { get; set; } = 1;

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(250, ErrorMessage = "备注最多250个字")]
        public string Note { get; set; } = string.Empty;
    }
}
