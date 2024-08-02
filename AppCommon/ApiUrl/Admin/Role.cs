namespace MicroShop.AppCommon.ApiUrl.Admin
{
    /// <summary>
    /// 角色相关地址
    /// </summary>
    public sealed class Role
    {
        /// <summary>
        /// 创建角色信息
        /// </summary>
        public const string Create = "/admin/permission/role/create";

        /// <summary>
        /// 修改角色信息
        /// </summary>
        public const string Modify = "/admin/permission/role/modify";

        /// <summary>
        /// 删除角色信息
        /// </summary>
        public const string Delete = "/admin/permission/role/delete/";

        /// <summary>
        /// 显示角色详情
        /// </summary>
        public const string Detail = "/admin/permission/role/detail/";

        /// <summary>
        /// 分页查询
        /// </summary>
        public const string Page = "/admin/permission/role/page";

        /// <summary>
        /// 列表查询
        /// </summary>
        public const string List = "/admin/permission/role/list";

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        public const string SetMenus = "/admin/permission/role/set-menus";
    }
}
