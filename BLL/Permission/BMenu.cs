using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 菜单业务逻辑类
    /// </summary>
    public class BMenu
    {
        private readonly static IMenu dal = MenuFactory.Create();

        /// <summary>
        /// 初始化保存数据
        /// </summary>
        /// <param name="req"></param>
        private static MenuDTO InitData(CreateMenuReqDTO req)
        {
            MenuDTO menu = new MenuDTO
            {
                OrderValue = req.OrderValue,
                Path = string.IsNullOrEmpty(req.Path) ? "" : req.Path.Trim(),
                MenuName = string.IsNullOrEmpty(req.MenuName) ? "" : req.MenuName.Trim(),
                MenuType = req.MenuType,
                Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim(),
                ParentId = req.ParentId,
                Icon = string.IsNullOrEmpty(req.Icon) ? "" : req.Icon.Trim(),
                ComponentName = string.IsNullOrEmpty(req.ComponentName) ? "" : req.ComponentName.Trim(),
                ComponentConfig = string.IsNullOrEmpty(req.ComponentConfig) ? "" : req.ComponentConfig.Trim(),
                Permission = string.IsNullOrEmpty(req.Permission) ? "" : req.Permission.Trim(),
                IsEnable = req.IsEnable,
                Hidden = req.Hidden
            };
            return menu;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static MenuVO Create(CreateMenuReqDTO req)
        {
            MenuDTO menu = InitData(req);
            return dal.Save(menu);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static MenuVO Modify(ModifyMenuReqDTO req)
        {
            MenuDTO menu = InitData(req);
            menu.MenuId = req.MenuId;
            return dal.Save(menu);
        }

        /// <summary>
        /// 根据menuId删除记录
        /// </summary>
        /// <param name="menuId">菜单Id</param>
        /// <exception cref="ServiceException"></exception>
        public static void Delete(int menuId)
        {
            if (menuId < 1)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "参数值错误" };
            }
            dal.Delete(menuId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <exception cref="ServiceException"></exception>
        public static MenuVO GetMenu(int menuId)
        {
            if (menuId < 1)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "参数值错误" };
            }

            return dal.GetMenu(menuId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        public static List<MenuVO> GetMenus(int parentId)
        {
            if (parentId < 1)
            {
                parentId = 0;
            }
            return dal.GetMenus(parentId);
        }
    }
}
