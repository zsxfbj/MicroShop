using MicroShop.Permission.Entity;
using MicroShop.Permission.Model;
using MicroShop.Web.Common;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 菜单管理业务逻辑
    /// </summary>
    public class BMenu : Utility.Common.Singleton<BMenu>
    {
        #region public MenuDTO Create(CreateMenuDTO createMenu)
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="createMenu"></param>
        /// <returns></returns>
        public MenuDTO Create(CreateMenuDTO createMenu)
        {
            if (createMenu == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "请求参数不能为空" };
            }

            createMenu.InitData();

            using var context = new PermissionContext();

            MenuEntity entity = new MenuEntity
            {
                CreatedAt = DateTime.Now,
                MenuName = createMenu.MenuName,
                MenuUrl = createMenu.MenuUrl,
                Note = createMenu.Note,
                OrderValue = createMenu.OrderValue,
                UpdatedAt = DateTime.Now,
                ParentId = createMenu.ParentId
            };

            context.Menus.Add(entity);
            context.SaveChanges();

            return GetMenuDTO(entity);
        }
        #endregion public MenuDTO Create(CreateMenuDTO createMenu)

        #region public void Modify(ModifyMenuDTO modifyMenu)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modifyMenu"></param>
        public void Modify(ModifyMenuDTO modifyMenu)
        {
            if (modifyMenu == null || modifyMenu.MenuId == 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "请求参数不能为空" };
            }

            modifyMenu.InitData();

            using var context = new PermissionContext();

            MenuEntity? entity = GetMenuEntity(modifyMenu.MenuId, context);

            if(entity == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
            }
            entity.MenuName = modifyMenu.MenuName;
            entity.OrderValue = modifyMenu.OrderValue;  
            entity.UpdatedAt = DateTime.Now;
            entity.ParentId = modifyMenu.ParentId;
            entity.MenuUrl = modifyMenu.MenuUrl;
            entity.Note = modifyMenu.Note;
            context.Menus.Update(entity);
            context.SaveChanges();
        }
        #endregion public void Modify(ModifyMenuDTO modifyMenu)

        #region public MenuDTO GetMenuDTO(int menuId)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public MenuDTO GetMenuDTO(int menuId)
        {
            using var context = new PermissionContext();

            MenuEntity? entity = GetMenuEntity(menuId, context);

            if (entity == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
            }
            return GetMenuDTO(entity);
        }
        #endregion public MenuDTO GetMenuDTO(int menuId)

        #region public void Delete(int menuId)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        public void Delete(int menuId)
        {
            using var context = new PermissionContext();

            MenuEntity? entity = GetMenuEntity(menuId, context);

            if (entity == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "菜单记录不存在" };
            }
 
            if(context.Menus.Count(x=>x.ParentId == menuId) > 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "该菜单下还有子菜单，无法删除" };
            }

            //删除关联记录
            List<RoleMenuRelationEntity> roleMenuRelations = context.RoleMenuRelations.Where(x => x.MenuId == menuId).ToList();
            if(roleMenuRelations.Count> 0)
            {
                context.RoleMenuRelations.RemoveRange(roleMenuRelations);
            }
            context.Menus.Remove(entity);
            context.SaveChanges();
        }
        #endregion public void Delete(int menuId)

        #region public List<MenuDTO> GetMenus(int parentId = 0)
        /// <summary>
        /// 根据上级编号获取菜单列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<MenuDTO> GetMenus(int parentId = 0)
        {
            using var context = new PermissionContext();
            return context.Menus.Where(x=>x.ParentId == parentId).OrderBy(x=>x.OrderValue).Select(entity => GetMenuDTO(entity)).ToList();
        }
        #endregion public List<MenuDTO> GetMenus(int parentId = 0)

        #region private static MenuDTO GetMenuDTO(MenuEntity entity)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        private static MenuDTO GetMenuDTO(MenuEntity entity)
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

        #region  private static MenuEntity? GetMenuEntity(int menuId, PermissionContext permissionContext)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="permissionContext"></param>        
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        private static MenuEntity? GetMenuEntity(int menuId, PermissionContext permissionContext)
        {
            if(menuId < 1)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "菜单编号不合法" };
            }

            if (permissionContext == null)
            {
                permissionContext = new PermissionContext();    
            }
            return permissionContext.Menus.FirstOrDefault(x => x.MenuId == menuId);            
        }
        #endregion  private static MenuEntity? GetMenuEntity(int menuId, PermissionContext permissionContext)
    }
}
