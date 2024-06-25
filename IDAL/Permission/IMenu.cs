using MicroShop.Model.Permission;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// 系统菜单接口类
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="createMenu">创建菜单请求</param>
        /// <returns>MicroShop.Model.Permission.MenuDTO or null</returns>
        MenuDTO Create(CreateMenuReqDTO createMenu);

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="modifyMenu"></param>
        MenuDTO Modify(ModifyMenuReqDTO modifyMenu);

        /// <summary>
        /// 根据菜单id删除
        /// </summary>
        /// <param name="menuId"></param>
        void Delete(int menuId);

        /// <summary>
        /// 根据菜单id获取菜单信息
        /// </summary>
        /// <param name="menuId">菜单Id</param>
        /// <returns></returns>
        MenuDTO GetMenuDTO(int menuId);

        /// <summary>
        /// 根据父级菜单Id获取菜单列表，0为根级别
        /// </summary>
        /// <param name="parentId">父级菜单Id</param>
        /// <returns></returns>
        List<MenuDTO> GetMenus(int parentId = 0);

    }
}
