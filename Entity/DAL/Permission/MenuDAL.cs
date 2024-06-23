using MicroShop.IDAL.Permission;
using MicroShop.Permission.Model;
using MicroShop.SQLServerDAL.Entity;
using MicroShop.SQLServerDAL.Entity.Permission;
using MicroShop.Web.Common;

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
        /// <param name="createMenu"></param>
        /// <returns></returns>
        public async Task<MenuDTO> CreateAsync(CreateMenuDTO createMenu)
        {
            using (var context = new MicroShopContext())
            {
                Menu entity = new Menu
                {
                    CreatedAt = DateTime.Now,
                    MenuName = createMenu.MenuName,
                    MenuUrl = createMenu.MenuUrl,
                    Note = createMenu.Note,
                    OrderValue = createMenu.OrderValue,
                    UpdatedAt = DateTime.Now,
                    ParentId = createMenu.ParentId
                };
                await context.Menus.AddAsync(entity);
                await context.SaveChangesAsync();

                return GetMenuDTO(entity);
            }           
        }

        public void Delete(int menuId)
        {
            throw new NotImplementedException();
        }

        public MenuDTO GetMenuDTO(int menuId)
        {
            throw new NotImplementedException();
        }

        public List<MenuDTO> GetMenus(int parentId = 0)
        {
            throw new NotImplementedException();
        }

        public void Modify(ModifyMenuDTO modifyMenu)
        {
            throw new NotImplementedException();
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
