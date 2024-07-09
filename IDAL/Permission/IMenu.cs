﻿using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// 系统菜单接口类
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// 保存菜单记录
        /// </summary>
        /// <param name="menu">菜单数据对象</param>
        /// <returns>a value of MicroShop.Model.Permission.MenuDTO or null</returns>
        MenuVO Save(MenuDTO menu);

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
        MenuVO GetMenu(int menuId);

        /// <summary>
        /// 根据父级菜单Id获取菜单列表，0为根级别
        /// </summary>
        /// <param name="parentId">父级菜单Id</param>
        /// <returns></returns>
        List<MenuVO> GetMenus(int parentId);

    }
}
