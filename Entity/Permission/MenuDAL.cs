﻿using MicroShop.Enums.Web;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.SQLServerDAL.Entity;

namespace MicroShop.SQLServerDAL.Permission
{
    /// <summary>
    /// Menu表基于SQLServer的增删改查实现
    /// </summary>
    public class MenuDAL : IMenu
    {
        #region Private Methods

        #region private static void ToEntity(CreateMenuReqDTO req, Menu menu)
        /// <summary>
        /// 请求数据和表数据对应
        /// </summary>
        /// <param name="menu">需要保存菜单的数据</param>
        /// <param name="entity">菜单数据表对象</param>
        private static void ToEntity(MenuDTO menu, Menu entity)
        {
            entity.MenuId = menu.MenuId;
            entity.MenuType = menu.MenuType;
            entity.MenuName = menu.MenuName.Trim();
            entity.ParentId = menu.ParentId;
            entity.Path = menu.Path.Trim();
            entity.Note = menu.Note.Trim();
            entity.Icon = menu.Icon;
            entity.ComponentConfig = menu.ComponentConfig;
            entity.ComponentName = menu.ComponentName;
            entity.Permission = menu.Permission;
            entity.IsEnable = menu.IsEnable;
            entity.Hidden = menu.Hidden;
            entity.OrderValue = menu.OrderValue;
        }
        #endregion private static void ToEntity(CreateMenuReqDTO req, Menu menu)

        #region private static MenuDTO GetMenuDTO(MenuEntity entity)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException">服务异常错误</exception>
        private static MenuVO ToVO(Menu entity)
        {
            if (entity == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "菜单记录为null" };
            }

            return new MenuVO
            {                
                MenuId = entity.MenuId,
                ParentId = entity.ParentId,
                MenuName = entity.MenuName,
                MenuType = entity.MenuType,
                Path = entity.Path,
                Icon = entity.Icon,
                IsEnable = entity.IsEnable,
                Hidden = entity.Hidden,
                ComponentName = entity.ComponentName,
                ComponentConfig = entity.ComponentConfig,
                Permission = entity.Permission,
                Note = entity.Note,
                OrderValue = entity.OrderValue,              
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
        #endregion private static MenuDTO GetMenuDTO(MenuEntity entity)

        #endregion Private Methods

        #region Public Methods

        #region public MenuVO Save(MenuDTO menu)
        /// <summary>
        /// 创建菜单的方法
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MenuVO Save(MenuDTO menu)
        {
            using (var context = new MicroShopContext())
            {
                Menu? entity = null;
                if(menu.MenuId > 0)
                {
                    entity = context.Menus.FirstOrDefault(x => x.MenuId == menu.MenuId);
                }
                if (entity == null) 
                {
                    entity = new Menu
                    {
                         MenuId = 0,
                         CreatedAt = DateTime.Now,
                         IsDeleted = false
                    };
                }

                ToEntity(menu, entity);
                entity.UpdatedAt = DateTime.Now;

                if(entity.MenuId == 0)
                {
                    context.Menus.Add(entity);
                }
                else
                {
                    context.Menus.Update(entity);
                }              
                context.SaveChanges();

                return ToVO(entity);
            }
        }
        #endregion public MenuVO Save(MenuDTO menu)

        #region public void Delete(int menuId)
        /// <summary>
        /// 根据菜单Id删除记录，同时删除角色菜单表对应的记录
        /// </summary>
        /// <param name="menuId">菜单Id</param>
        /// <exception cref="ServiceException">服务异常错误</exception>
        public void Delete(int menuId)
        {
            using (var context = new MicroShopContext())
            {
                Menu? entity = context.Menus.FirstOrDefault(x => x.MenuId == menuId);
                if (entity == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
                }

                if (context.Menus.Count(x => x.ParentId == menuId) > 0)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.HasSubRecords, ErrorMessage = "该菜单下还有子菜单，无法删除" };
                }

                //更新标记位
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                
                //更新为主
                context.Menus.Update(entity);
                context.SaveChanges();
            }
        }
        #endregion public void Delete(int menuId)

        #region public MenuVO GetMenu(int menuId)
        /// <summary>
        /// 根据菜单Id获取菜单记录
        /// </summary>
        /// <param name="menuId">菜单Id</param>
        /// <returns>MicroShop.Model.VO.Permission.MenuVO</returns>
        /// <exception cref="ServiceException">服务异常错误</exception>
        public MenuVO GetMenu(int menuId)
        {
            using (var context = new MicroShopContext())
            {
                Menu? entity = context.Menus.FirstOrDefault(x => x.MenuId == menuId);
                if (entity == null || entity.IsDeleted == false)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在或已删除！" };
                }
                return ToVO(entity);
            }
        }
        #endregion public MenuVO GetMenu(int menuId)

        #region public List<MenuVO> GetMenus(int parentId = 0)
        /// <summary>
        /// 根据上级编号获取菜单列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException">服务异常错误</exception>
        public List<MenuVO> GetMenus(int parentId)
        {
            using (var context = new MicroShopContext())
            {
                return context.Menus.Where(x => x.ParentId == parentId && x.IsDeleted == false).OrderBy(x => x.OrderValue).Select(entity => ToVO(entity)).ToList();
            }
        }
        #endregion public List<MenuVO> GetMenus(int parentId = 0)

        #endregion Public Methods

    }
}
