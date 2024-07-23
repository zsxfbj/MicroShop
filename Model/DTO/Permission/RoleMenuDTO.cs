namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 角色菜单关系对象
    /// </summary>
    public class RoleMenuDTO
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId { get; set; } = 0;

        /// <summary>
        /// 权限编码
        /// </summary>
        public string Permission { get; set; } = string.Empty;
    }
}
