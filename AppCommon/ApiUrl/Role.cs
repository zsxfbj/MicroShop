namespace MicroShop.AppCommon.ApiUrl
{
    /// <summary>
    /// 角色相关地址
    /// </summary>
    public sealed class Role
    {
        /// <summary>
        /// 创建角色信息
        /// </summary>
        public const string Create = "/permission/role/create";

        /// <summary>
        /// 修改角色信息
        /// </summary>
        public const string Modify = "/permission/role/modify";

        /// <summary>
        /// 删除角色信息
        /// </summary>
        public const string Delete = "/permission/role/delete/";

        /// <summary>
        /// 显示角色详情
        /// </summary>
        public const string Detail = "/permission/role/detail/";

        /// <summary>
        /// 分页查询
        /// </summary>
        public const string Page = "/permission/role/page";

        /// <summary>
        /// 列表查询
        /// </summary>
        public const string List = "/permission/role/list";

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        public const string SetMenus = "/permission/role/set-menus";
    }
}
