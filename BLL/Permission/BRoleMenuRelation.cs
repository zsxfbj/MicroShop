using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BRoleMenuRelation
    {
        /// <summary>
        /// 数据访问实例对象
        /// </summary>
        private readonly static IRoleMenuRelation dal = RoleMenuRelationFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static bool IsExist(int roleId, int menuId)
        {
           if(roleId <= 0 || menuId <= 0) { throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "请求的参数错误" }; }
            
           return dal.IsExist(roleId, menuId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static List<RoleMenuVO> GetRoleMenus(int roleId)
        {
            if(roleId < 1)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "请求的参数错误" };
            }
            return dal.GetRoleMenus(roleId);
        }

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="req"></param>
        public static void SetRoleMenuRelation(SetRoleMenuRelationReqDTO req)
        {
            dal.SetRoleMenuRelation(req);
        }
    }
}
