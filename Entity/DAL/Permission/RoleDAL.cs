using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.Permission;
using MicroShop.Model.Web;
using MicroShop.SQLServerDAL.Entity;
using MicroShop.SQLServerDAL.Entity.Permission;

namespace MicroShop.SQLServerDAL.DAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleDAL : IRole
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public RoleDTO Create(CreateRoleReqDTO req)
        {
            Role role = new Role();
            ToEntity(req, role);
            using (var context = new MicroShopContext())
            {               
                context.Roles.Add(role);
                context.SaveChanges();
            }
            return ToDTO(role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <exception cref="ServiceException"></exception>
        public void Delete(int roleId)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
                if (role == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在" };
                }
                context.Roles.Remove(role);

                List<RoleMenuRelation> roleMenus = context.RoleMenuRelations.Where(x => x.RoleId == roleId).ToList();
                if(roleMenus.Count > 0)
                {
                    context.RoleMenuRelations.RemoveRange(roleMenus);
                }               
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PageResultDTO<RoleDTO> GetPageResult(QueryRoleReqDTO req)
        {
            PageResultDTO<RoleDTO> pageResult = new PageResultDTO<RoleDTO>
            {
                PageIndex = req.PageIndex.HasValue ? req.PageIndex.Value : 1,
                PageSize = req.PageSize.HasValue ? req.PageSize.Value : 15,
                RecordCount = 0,
                Data = new List<RoleDTO>()
            };

            using (var context = new MicroShopContext())
            {
                if (string.IsNullOrWhiteSpace(req.RoleName))
                {
                    pageResult.RecordCount = context.Roles.Count();
                    pageResult.Data = context.Roles.Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => ToDTO(entity)).ToList();
                }
                else
                {
                    var query = context.Roles.Where(x => x.RoleName.Contains(req.RoleName.Trim()));
                    pageResult.RecordCount = query.Count();
                    pageResult.Data = query.Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => ToDTO(entity)).ToList();
                }
            }
            return pageResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleDTO GetRole(int roleId)
        {
            using(var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
                if (role == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在" };
                }
                return ToDTO(role);
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RoleDTO> GetRoles()
        {
            using (var context = new MicroShopContext())
            {
                return context.Roles.OrderByDescending(x => x.RoleId).Select(entity => ToDTO(entity)).ToList();
            }
        }

        #region public RoleDTO Modify(ModifyRoleReqDTO req)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleDTO Modify(ModifyRoleReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == req.RoleId);
                if (role == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在" };
                }
                ToEntity(req, role);
                role.UpdatedAt = DateTime.Now;
                context.Roles.Update(role);
                context.SaveChanges();
                return ToDTO(role);
            }
        }
        #endregion public RoleDTO Modify(ModifyRoleReqDTO req)

        #region private static void ToEntity(CreateRoleReqDTO req, Role role)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="role"></param>
        private static void ToEntity(CreateRoleReqDTO req, Role role)
        {
            role.RoleName = string.IsNullOrEmpty(req.RoleName) ? "" : req.RoleName.Trim();
            role.IsEnable = req.IsEnable;
            role.Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim();
        }
        #endregion private static void ToEntity(CreateRoleReqDTO req, Role role)

        #region private RoleDTO GetRole(Role role)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private static RoleDTO ToDTO(Role role)
        {
            return new RoleDTO
            {
                RoleId = role.RoleId,
                RoleName = string.IsNullOrEmpty(role.RoleName) ? "" : role.RoleName.Trim(),
                Note = string.IsNullOrEmpty(role.Note) ? "" : role.Note.Trim(),
                IsEnable = role.IsEnable,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt
            };
        }
        #endregion private RoleDTO GetRole(Role role)
    }
}
