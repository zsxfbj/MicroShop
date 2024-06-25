using MicroShop.Enums.Web;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.Permission;
using MicroShop.SQLServerDAL.Entity;
using MicroShop.SQLServerDAL.Entity.Permission;

namespace MicroShop.SQLServerDAL.DAL.Permission
{
    /// <summary>
    /// Menu表基于SQLServer的增删改查实现
    /// </summary>
    public class MenuDAL : IMenu
    {
        /// <summary>
        /// 创建菜单的方法
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MenuDTO Create(CreateMenuReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Menu entity = new Menu();
                ToEntity(req, entity);
                context.Menus.Add(entity);
                context.SaveChanges();
                return GetMenuDTO(entity);
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <exception cref="ServiceException"></exception>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public MenuDTO GetMenuDTO(int menuId)
        {
            using (var context = new MicroShopContext())
            {
                Menu? menu = context.Menus.FirstOrDefault(x=>x.MenuId == menuId);
                if (menu == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
                }
                return GetMenuDTO(menu);
            }        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<MenuDTO> GetMenus(int parentId = 0)
        {
            using (var context = new MicroShopContext())
            {
                return context.Menus.Where(x => x.ParentId == parentId).OrderBy(x => x.OrderValue).Select(entity => GetMenuDTO(entity)).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <exception cref="ServiceException"></exception>
        public MenuDTO Modify(ModifyMenuReqDTO req)
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

                return GetMenuDTO(menu);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="menu"></param>
        private static void ToEntity(CreateMenuReqDTO req, Menu menu)
        {
            menu.OrderValue = req.OrderValue;
            menu.MenuUrl = string.IsNullOrEmpty(req.MenuUrl) ? "" : req.MenuUrl.Trim();
            menu.MenuName = string.IsNullOrEmpty(req.MenuName) ? "" : req.MenuName.Trim();
            menu.Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim();
            menu.ParentId = req.ParentId;
        }

        #region private static MenuDTO GetMenuDTO(MenuEntity entity)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        private static MenuDTO GetMenuDTO(Menu entity)
        {
            if (entity == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "菜单记录为null" };
            }

            return new MenuDTO
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
    }
}
