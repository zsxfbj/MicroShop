using MicroShop.Common.Enum;
using MicroShop.Database.IDAL.Permission;
using MicroShop.Common.Model.Common.Exception;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using System.Data.SqlClient;
using MicroShop.Common.Enum.Web;

namespace MicroShop.Database.SQLServerDAL.Permission
{
    /// <summary>
    /// Menu表基于SQLServer的增删改查实现
    /// </summary>
    public class Menu : IMenu
    {
        #region Private Methods

        #region private static void ToEntity(CreateMenuReqDTO req, Menu menu)
        /// <summary>
        /// 请求数据和表数据对应
        /// </summary>
        /// <param name="req">需要保存菜单的数据</param>
        /// <param name="entity">菜单数据表对象</param>
        private static void ToEntity(CreateMenuReqDTO req, Menu entity)
        {
            entity.MenuType = req.MenuType;
            entity.MenuName = req.MenuName.Trim();
            entity.ParentId = req.ParentId;
            entity.Path = string.IsNullOrEmpty(req.Path) ? "" : req.Path.Trim();
            entity.Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim();
            entity.Icon = string.IsNullOrEmpty(req.Icon) ? "" : req.Icon.Trim();
            entity.ComponentConfig = string.IsNullOrEmpty(req.ComponentConfig) ? "" : req.ComponentConfig.Trim();
            entity.ComponentName = string.IsNullOrEmpty(req.ComponentName) ? "" : req.ComponentName.Trim();
            entity.Permission = string.IsNullOrEmpty(req.Permission) ? "" : req.Permission.Trim();
            entity.IsEnable = req.IsEnable;
            entity.Hidden = req.Hidden;
            entity.OrderValue = req.OrderValue;
        }
        #endregion private static void ToEntity(CreateMenuReqDTO req, Menu menu)

        #region private static MenuDTO GetMenuDTO(MenuEntity entity)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdr"></param>
        /// <returns></returns>        
        private static MenuVO ToVO(SqlDataReader rdr)
        {            
            return new MenuVO
            {
                MenuId = rdr.IsDBNull(0) ? 0L: rdr.GetInt64(0),
                ParentId = rdr.IsDBNull(1) ? 0L : rdr.GetInt64(1),
                MenuName = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2).ToString(),
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

        #region public MenuVO MenuVO Create(CreateMenuReqDTO req)
        /// <summary>
        /// 创建菜单的方法
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MenuVO Create(CreateMenuReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Menu entity = entity = new Menu
                {
                    MenuId = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                };

                ToEntity(req, entity);
                context.Menus.Add(entity);
                context.SaveChanges();

                return ToVO(entity);
            }
        }
        #endregion public MenuVO Create(CreateMenuReqDTO req)

        #region public MenuVO Modify(ModifyMenuReqDTO req)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MenuVO Modify(ModifyMenuReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Menu? entity = context.Menus.FirstOrDefault(x => x.MenuId == req.MenuId);
                if (entity == null || entity.IsDeleted)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodes.NotFound, ErrorMessage = "编号为【" + req.MenuId + "】菜单记录不存在！" };
                }

                entity.UpdatedAt = DateTime.Now;

                ToEntity(req, entity);

                context.Menus.Update(entity);
                context.SaveChanges();

                return ToVO(entity);
            }
        }
        #endregion public MenuVO Modify(ModifyMenuReqDTO req)

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
                    throw new ServiceException { ErrorCode = RequestResultCodes.NotFound, ErrorMessage = "菜单记录不存在" };
                }

                if (context.Menus.Count(x => x.ParentId == menuId) > 0)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodes.HasSubRecords, ErrorMessage = "该菜单下还有子菜单，无法删除" };
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
        /// <returns>MicroShop.Common.Model.VO.Permission.MenuVO</returns>
        /// <exception cref="ServiceException">服务异常错误</exception>
        public MenuVO GetMenu(int menuId)
        {
            using (var context = new MicroShopContext())
            {
                Menu? entity = context.Menus.FirstOrDefault(x => x.MenuId == menuId);
                if (entity == null || entity.IsDeleted == false)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodes.NotFound, ErrorMessage = "菜单记录不存在或已删除！" };
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
