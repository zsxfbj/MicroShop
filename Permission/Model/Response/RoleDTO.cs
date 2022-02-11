using System;
using System.ComponentModel;

namespace MicroShop.Permission.Model.Response
{
    /// <summary>
    /// 角色数据视图
    /// </summary>
    [Serializable]
    public class RoleDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Description("角色编号")]
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public string RoleName { get; set; }



    }
}
