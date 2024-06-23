using System;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 创建菜单请求
    /// </summary>
    [Serializable]
    public class CreateMenuDTO
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单必须填写")]
        [StringLength(20, ErrorMessage = "菜单名称最多20个字")]
        public string MenuName { get; set; }

        /// <summary>
        /// 上级菜单
        /// </summary>
        [Required(ErrorMessage = "必须指定上级菜单")]
        [Range(0, int.MaxValue, ErrorMessage = "上级菜单编号格式错误")]
        public int ParentId { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        [StringLength(200, ErrorMessage = "菜单地址最多200个字")]
        public string? MenuUrl { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderValue { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200, ErrorMessage = "备注最多200个字")]
        public string? Note { get; set; }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            MenuName = MenuName == null ? "" : MenuName.Trim();
            if (string.IsNullOrEmpty(MenuUrl))
            {
                MenuUrl = string.Empty;
            }
            else
            {
                MenuUrl = MenuUrl.Trim();
            }

            if(string.IsNullOrEmpty(Note))
            {
                Note = string.Empty;    
            }
            else
            {
                Note = Note.Trim();
            }
        }
    }
}
