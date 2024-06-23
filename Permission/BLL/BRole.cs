using MicroShop.Permission.Entity;
using MicroShop.Permission.Model;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;
using Z.EntityFramework.Plus;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 角色业务逻辑类
    /// </summary>
    public class BRole : Singleton<BRole>
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
        /// <exception cref="ServiceException"></exception>
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

        #region public void ModifyRole(ModifyRoleDTO modifyRole)
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

            using var context = new PermissionContext();          

            if (context.Roles.Any(x => x.RoleName == modifyRole.RoleName.Trim() && x.RoleId != modifyRole.RoleId))
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RoleNameIsExist, ErrorMessage = "存在相同名称的角色" };
            }

            RoleEntity role = GetRoleEntity(modifyRole.RoleId, context);

            if (role != null)
            {
                role.IsEnable = modifyRole.IsEnable;
                role.Note = string.IsNullOrEmpty(modifyRole.Note) ? "" : modifyRole.Note.Trim();
                role.UpdatedAt = DateTime.Now;
                context.Roles.Update(role);
                context.SaveChanges();
            }
        }
        #endregion public void ModifyRole(ModifyRoleDTO modifyRole)

        #region public void DeleteRole(int roleId)
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        public void DeleteRole(int roleId)
        {
            using var context = new PermissionContext();
            RoleEntity role = GetRoleEntity(roleId, context);           
            context.SystemUsers.Where(x => x.RoleId == roleId).Update(po => new SystemUserEntity { RoleId = 0, UpdatedAt = DateTime.Now });
            context.Roles.Remove(role);
            List<RoleMenuRelationEntity> roleMenuRelations = context.RoleMenuRelations.Where(x => x.RoleId == roleId).ToList();
            if (roleMenuRelations.Count > 0)
            {
                context.RoleMenuRelations.RemoveRange(roleMenuRelations);
            }
            context.SaveChanges();            
        }
        #endregion public void DeleteRole(int roleId)

        #region public PageResultDTO<RoleDTO> GetPageResult(QueryRoleDTO queryRole)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryRole"></param>
        /// <returns></returns>
        public PageResultDTO<RoleDTO> GetPageResult(QueryRoleDTO queryRole)
        {
            if (queryRole == null)
            {
                return new PageResultDTO<RoleDTO> { PageIndex = 1, PageSize = 10, Data = new List<RoleDTO>(), RecordCount = 0 };
            }

            queryRole.InitData();

            PageResultDTO<RoleDTO> pageResult = new PageResultDTO<RoleDTO>
            {
                PageIndex = queryRole.PageIndex.HasValue ? queryRole.PageIndex.Value : 1,
                PageSize = queryRole.PageSize.HasValue ? queryRole.PageSize.Value : 15,
                RecordCount = 0,
                Data = new List<RoleDTO>()
            };

            using var context = new PermissionContext();
            if (string.IsNullOrWhiteSpace(queryRole.RoleName))
            {
                pageResult.RecordCount = context.Roles.Count();
                pageResult.Data = context.Roles.Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => GetRole(entity)).ToList();
            }
            else
            {
                var query = context.Roles.Where(x => x.RoleName.Contains(queryRole.RoleName.Trim()));
                pageResult.RecordCount = query.Count();
                pageResult.Data = query.Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => GetRole(entity)).ToList();
            }
            return pageResult;
        }
        #endregion  public PageResultDTO<RoleDTO> GetPageResult(QueryRoleDTO queryRole)

        #region public List<RoleDTO> GetRoles()
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleDTO> GetRoles()
        {            
            using var context = new PermissionContext();
            return context.Roles.Where(x=>x.IsEnable == true).Select(entity => GetRole(entity)).ToList();
        }
        #endregion public List<RoleDTO> GetRoles()

        #region private RoleEntity GetRoleEntity(int roleId, PermissionContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        private static RoleEntity GetRoleEntity(int roleId, PermissionContext context)
        {
            if (roleId < 1)
            {
                throw new ServiceException
                {
                    ErrorCode = RequestResultCodeEnum.RequestParameterError,
                    ErrorMessage = "角色编号数据错误"
                };
            }

            if (context == null)
            {
                context = new PermissionContext();
            }

            RoleEntity? entity = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
            if(entity == null)
            {
                throw new ServiceException
                {
                    ErrorCode = RequestResultCodeEnum.NotFound,
                    ErrorMessage = "角色记录不存在"
                };
            }
            return entity;
        }
        #endregion private RoleEntity GetRoleEntity(int roleId, PermissionContext context)

        #region private RoleDTO GetRole(RoleEntity role)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private static RoleDTO GetRole(RoleEntity role)
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
