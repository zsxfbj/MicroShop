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

        #region public static bool HasPermission(int roleId, string permission)
        /// <summary>
        /// 判断是否有权限访问
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool HasPermission(long roleId, string permission)
        {
            if(roleId < 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(permission))
            {
                return true;
            }            
            return dal.HasPermission(roleId, permission);
        }
        #endregion public static bool HasPermission(int roleId, string permission)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="showHidden">显示隐藏菜单</param>
        /// <returns></returns>
        public static List<RoleMenuVO> GetRoleMenus(long roleId, bool showHidden = false)
        {
            if(roleId < 1)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "请求的参数错误" };
            }
            return dal.GetRoleMenus(roleId, showHidden);
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
