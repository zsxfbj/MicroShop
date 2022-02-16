using MicroShop.Permission.Entity;
using MicroShop.Permission.Model.Request;
using MicroShop.Permission.Model.Response;
using MicroShop.Web.Common;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 角色业务逻辑类
    /// </summary>
    public class BRole : Utility.Common.Singleton<BRole>
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
            if (roleId < 1)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "角色编号格式错误" };
            }

            using PermissionContext permissionContext = new PermissionContext();

            RoleEntity? role = permissionContext.Roles.FirstOrDefault(x => x.RoleId == roleId);

            if (role == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "角色信息不存在" };
            }
            return GetRole(role);

        }
        #endregion public RoleDTO GetRole(int roleId)

        #region public RoleDTO CreateRole(CreateRoleDTO createRole)
        /// <summary>
        /// 创建角色记录
        /// </summary>
        /// <param name="createRole"></param>
        /// <returns></returns>
        public RoleDTO CreateRole(CreateRoleDTO createRole)
        {
            using var context = new PermissionContext();
            if (context.Roles.Any(x => x.RoleName == createRole.RoleName.Trim()))
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RoleNameIsExist, ErrorMessage = "存在相同名称的角色" };
            }

            RoleEntity role = new RoleEntity
            {
                RoleName = createRole.RoleName.Trim(),
                IsEnable = createRole.IsEnable,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Note = string.IsNullOrEmpty(createRole.Note) ? "" : createRole.Note.Trim()
            };
            context.Roles.Add(role);
            context.SaveChanges();

            return GetRole(role);
        }
        #endregion public RoleDTO CreateRole(CreateRoleDTO createRole)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modifyRole"></param>
        /// <exception cref="ServiceException"></exception>
        public void ModifyRole(ModifyRoleDTO modifyRole)
        {
            if (modifyRole == null)
            {
                throw new ServiceException
                {
                    ErrorCode = RequestResultCodeEnum.RequestParameterError,
                    ErrorMessage = "提交的修改内容为空"
                };
            }
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
