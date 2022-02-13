using MicroShop.Permission.Entity;
using MicroShop.Permission.Model.Request;
using MicroShop.Permission.Model.Response;
using MicroShop.Web.Common;

namespace MicroShop.Permission.WebApi.BLL
{
    /// <summary>
    /// 角色业务逻辑类
    /// </summary>
    public class BRole : MicroShop.Utility.Common.Singleton<BRole>
    {
        #region public RoleDTO GetRole(int roleId)
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleDTO GetRole(int roleId)
        {
            if(roleId < 1)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "角色编号格式错误" };
            }

            Entity.PermissionContext permissionContext = new Entity.PermissionContext();

            RoleEntity? role = permissionContext.Roles.FirstOrDefault(x => x.RoleId == roleId);

            if(role == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "角色信息不存在" };
            }
            return GetRole(role);
             
        }
        #endregion public RoleDTO GetRole(int roleId)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRole"></param>
        /// <returns></returns>
        public RoleDTO CreateRole(CreateRoleDTO createRole)
        {


            return new RoleDTO();
        }

        #region private RoleDTO GetRole(RoleEntity role)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private RoleDTO GetRole(RoleEntity role)
        {
            return new RoleDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Note = role.Note,
                IsEnable = role.IsEnable,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt

            };
        }
        #endregion private RoleDTO GetRole(RoleEntity role)
    }
}
