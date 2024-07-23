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
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>      
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否可用
        /// </summary>      
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; } = string.Empty;
    }
}
