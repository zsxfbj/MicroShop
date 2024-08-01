using MicroShop.BLL.Common;
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
        /// <summary>
        /// 数据访问实现
        /// </summary>
        private readonly static IMenu dal = MenuFactory.Create();

        /// <summary>
        /// 缓存的Key
        /// </summary>
        private const string CacheKey = "sys-menu-";
               
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static MenuVO Create(CreateMenuReqDTO req)
        {
            MenuVO vo = dal.Create(req);
            BCache.SetValue(CacheKey + vo.MenuId, vo);
            return vo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static MenuVO Modify(ModifyMenuReqDTO req)
        {            
            MenuVO vo =  dal.Modify(req);
            BCache.SetValue(CacheKey + vo.MenuId, vo);
            return vo;
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
            //移除缓存
            BCache.Remove(CacheKey + menuId);
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
            string key = CacheKey + menuId;
            if (BCache.IsExist(key)) 
            {
                return BCache.GetValue<MenuVO>(key);
            }

            MenuVO vo = dal.GetMenu(menuId);
            BCache.SetValue(key, vo);
            return vo;
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
