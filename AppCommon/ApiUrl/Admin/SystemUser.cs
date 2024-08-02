namespace MicroShop.AppCommon.ApiUrl.Admin
{
    /// <summary>
    /// 系统服务接口
    /// </summary>
    public sealed class SystemUser
    {
        /// <summary>
        /// 创建系统用户信息
        /// </summary>
        public const string Create = "/admin/permission/system-user/create";

        /// <summary>
        /// 修改系统用户信息
        /// </summary>
        public const string Modify = "/admin/permission/system-user/modify";

        /// <summary>
        /// 显示系统用户详情
        /// </summary>
        public const string Detail = "/admin/permission/system-user/detail/";

        /// <summary>
        /// 删除系统用户
        /// </summary>
        public const string Delete = "/admin/permission/system-user/delete/";

        /// <summary>
        /// 设置登录状态
        /// </summary>
        public const string SetLoginStatus = "/admin/permission/system-user/login-status/";

        /// <summary>
        /// 分页查询
        /// </summary>
        public const string Page = "/admin/permission/system-user/page";

    }
}
