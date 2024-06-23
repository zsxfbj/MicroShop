using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 创建角色请求
    /// </summary>
    [Serializable]
    public class CreateRoleDTO
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称必须填写")]
        [StringLength(30, ErrorMessage = "角色名称最多30个字", MinimumLength = 2)]
        [DefaultValue("测试")]
        public string RoleName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DefaultValue(true)]
        public bool IsEnable { get; set; }
               
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255, ErrorMessage = "备注最多255个字")]
        [DefaultValue("")]
        public string Note { get; set; }

    }
}
