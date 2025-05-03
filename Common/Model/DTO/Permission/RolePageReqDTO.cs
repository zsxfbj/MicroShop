using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MicroShop.Model.Base;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 查询角色
    /// </summary>
    public class RolePageReqDTO : PageRequest
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [StringLength(30, ErrorMessage = "角色名称最多30个字")]
        [DefaultValue("")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsEnable { get; set; } = default;

        #region public override void InitData()
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void InitData()
        {
            base.InitData();

            RoleName = string.IsNullOrEmpty(RoleName) ? "" : RoleName.Trim();
        }
        #endregion public override void InitData()
    }
}
