using MicroShop.Enums.Web;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.SQLServerDAL.Entity;
using MicroShop.SQLServerDAL.Entity.Permission;

namespace MicroShop.SQLServerDAL.DAL.Permission
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
        /// <param name="req">创建菜单的请求内容</param>
        /// <param name="menu">菜单数据表对象</param>
        private static void ToEntity(CreateMenuReqDTO req, Menu menu)
        {
            menu.OrderValue = req.OrderValue;
            menu.MenuUrl = string.IsNullOrEmpty(req.MenuUrl) ? "" : req.MenuUrl.Trim();
            menu.MenuName = string.IsNullOrEmpty(req.MenuName) ? "" : req.MenuName.Trim();
            menu.Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim();
            menu.ParentId = req.ParentId;
        }
        #endregion private static void ToEntity(CreateMenuReqDTO req, Menu menu)

        #region private static MenuDTO GetMenuDTO(MenuEntity entity)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常错误</exception>
        private static MenuVO ToVO(Menu entity)
        {
            if (entity == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "菜单记录为null" };
            }

            return new MenuVO
            {
                CreatedAt = entity.CreatedAt,
                MenuId = entity.MenuId,
                MenuName = entity.MenuName,
                MenuUrl = entity.MenuUrl,
                Note = entity.Note,
                OrderValue = entity.OrderValue,
                ParentId = entity.ParentId,
                UpdatedAt = entity.UpdatedAt
            };
        }
        #endregion private static MenuDTO GetMenuDTO(MenuEntity entity)

        #endregion Private Methods

        #region Public Methods

        #region public MenuVO Create(CreateMenuReqDTO req)
        /// <summary>
        /// 创建菜单的方法
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MenuVO Create(CreateMenuReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Menu entity = new Menu();
                ToEntity(req, entity);
                context.Menus.Add(entity);
                context.SaveChanges();
                return ToVO(entity);
            }           
        }
        #endregion public MenuVO Create(CreateMenuReqDTO req)

        #region public void Delete(int menuId)
        /// <summary>
        /// 根据菜单Id删除记录，同时删除角色菜单表对应的记录
        /// </summary>
        /// <param name="menuId">菜单Id</param>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常错误</exception>
        public void Delete(int menuId)
        {
            using (var context = new MicroShopContext())
            {
                Menu? menu = context.Menus.FirstOrDefault(x => x.MenuId == menuId);
                if (menu == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
                }

                if (context.Menus.Count(x => x.ParentId == menuId) > 0)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.HasSubRecords, ErrorMessage = "该菜单下还有子菜单，无法删除" };
                }

                //删除关联记录
                List<RoleMenuRelation> roleMenuRelations = context.RoleMenuRelations.Where(x => x.MenuId == menuId).ToList();
                if (roleMenuRelations.Count > 0)
                {
                    context.RoleMenuRelations.RemoveRange(roleMenuRelations);
                }

                context.Menus.Remove(menu);
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
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常错误</exception>
        public MenuVO GetMenu(int menuId)
        {
            using (var context = new MicroShopContext())
            {
                Menu? menu = context.Menus.FirstOrDefault(x=>x.MenuId == menuId);
                if (menu == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
                }
                return ToVO(menu);
            }        
        }
        #endregion public MenuVO GetMenu(int menuId)

        #region public List<MenuVO> GetMenus(int parentId = 0)
        /// <summary>
        /// 根据上级编号获取菜单列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常错误</exception>
        public List<MenuVO> GetMenus(int parentId = 0)
        {
            using (var context = new MicroShopContext())
            {
                return context.Menus.Where(x => x.ParentId == parentId).OrderBy(x => x.OrderValue).Select(entity => ToVO(entity)).ToList();
            }
        }
        #endregion public List<MenuVO> GetMenus(int parentId = 0)

        #region public MenuVO Modify(ModifyMenuReqDTO req)
        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="req">修改菜单的请求</param>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常错误</exception>
        public MenuVO Modify(ModifyMenuReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Menu? menu = context.Menus.FirstOrDefault(x => x.MenuId == req.MenuId);
                if (menu == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
                }

                ToEntity(req, menu);
                menu.UpdatedAt = DateTime.Now;
                context.Menus.Update(menu);
                context.SaveChanges();
                return ToVO(menu);
            }
        }
        #endregion public MenuVO Modify(ModifyMenuReqDTO req)

        #endregion Public Methods

    }
}
