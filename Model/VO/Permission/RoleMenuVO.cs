namespace MicroShop.Model.VO.Permission
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    [Serializable]
    public class RoleMenuVO
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuId { get; set; } = 0;

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 上级菜单编号
        /// </summary>
        public int ParentId { get; set; } = 0;

        /// <summary>
        /// 下级菜单
        /// </summary>
        public List<RoleMenuVO> SubMenus { get; set; } = new List<RoleMenuVO>();
    }
}
