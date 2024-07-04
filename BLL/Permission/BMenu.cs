using MicroShop.BLL.Auth;
using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Auth;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 菜单业务逻辑类
    /// </summary>
    public class BMenu : Singleton<BMenu>
    {
        private readonly static IMenu dal = MenuFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MenuVO Create(CreateMenuReqDTO req)
        {
           

            MenuVO dto = dal.Create(req);

            return dto;
        }

        public void Modify(ModifyMenuReqDTO req)
        {
          

            dal.Modify(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <exception cref="ServiceException"></exception>
        public void Delete(int menuId) 
        {
            

            dal.Delete(menuId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <exception cref="ServiceException"></exception>
        public MenuVO GetMenu(int menuId)
        {
            

            return dal.GetMenu(menuId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<MenuVO> GetMenus(int parentId)
        {
            return dal.GetMenus(parentId);
        }
    }
}
