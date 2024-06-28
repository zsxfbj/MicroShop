using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Auth;
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
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MenuVO Create(CreateMenuReqDTO req, SystemUserTokenDTO userToken)
        {
            if (!userToken.IsAdmin) 
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotAllowAccess, ErrorMessage = "您非系统管理员，无法执行该操作" };
            }

            MenuVO dto = dal.Create(req);

            return dto;
        }
    }
}
