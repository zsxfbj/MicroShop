using System.ComponentModel;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 角色数据转对象类
    /// </summary>
    [Serializable]
    public class RoleDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Description("角色编号")]
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否可用
        /// </summary>
        [Description("是否可用")]
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Note { get; set; } = string.Empty;
    }
}
