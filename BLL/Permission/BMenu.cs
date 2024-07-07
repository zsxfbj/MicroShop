using MicroShop.BLL.Auth;
using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Auth;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.SQLServerDAL.Permission;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 菜单业务逻辑类
    /// </summary>
    public class BMenu
    {
        private readonly static IMenu dal = MenuFactory.Create();

        private static void InitData(CreateMenuReqDTO req)
        {
            req.OrderValue = req.OrderValue;
            req.Path = string.IsNullOrEmpty(req.Path) ? "" : req.Path.Trim();
            req.MenuName = string.IsNullOrEmpty(req.MenuName) ? "" : req.MenuName.Trim();
            req.Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim();
            req.ParentId = req.ParentId;
            req.Icon = string.IsNullOrEmpty(req.Icon) ? "" : req.Icon.Trim();
            req.ComponentName = string.IsNullOrEmpty(req.ComponentName) ? "" : req.ComponentName.Trim();
            req.ComponentConfig = string.IsNullOrEmpty(req.ComponentConfig) ? "" : req.ComponentConfig.Trim();
            req.Permission = string.IsNullOrEmpty(req.Permission) ? "" : req.Permission.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static MenuVO Create(CreateMenuReqDTO req)
        {
           

            MenuVO dto = dal.Create(req);

            return dto;
        }

        public static void Modify(ModifyMenuReqDTO req)
        {
          

            dal.Modify(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <exception cref="ServiceException"></exception>
        public static void Delete(int menuId) 
        {
            

            dal.Delete(menuId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <exception cref="ServiceException"></exception>
        public static MenuVO GetMenu(int menuId)
        {
            

            return dal.GetMenu(menuId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        public static List<MenuVO> GetMenus(int parentId)
        {
            if(parentId < 1)
            {
                parentId = 0;
            }
            return dal.GetMenus(parentId);
        }
    }
}
