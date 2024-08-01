using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Entity.Permission;

namespace MicroShop.SQLServerDAL.Permission
{
    /// <summary>
    /// Role表数据访问层
    /// </summary>
    public class RoleDAL : IRole
    {
        #region Private Methods

        #region private static void ToEntity(CreateRoleReqDTO req, Role role)
        /// <summary>
        /// 外部数据赋值到实体类
        /// </summary>
        /// <param name="entity">数据实体对象</param>
        /// <param name="role">数据转对象实例</param>
        private static void ToEntity(CreateRoleReqDTO req, Role entity)
        {
            entity.RoleName = req.RoleName.Trim();
            entity.IsEnable = req.IsEnable;
            entity.Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim();
        }
        #endregion private static void ToEntity(CreateRoleReqDTO req, Role role)

        #region private ToVO ToVO(Role role)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private static RoleVO ToVO(Role role)
        {
            return new RoleVO
            {
                RoleId = role.RoleId,
                RoleName = string.IsNullOrEmpty(role.RoleName) ? "" : role.RoleName.Trim(),
                Note = string.IsNullOrEmpty(role.Note) ? "" : role.Note.Trim(),
                IsEnable = role.IsEnable,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt
            };
        }
        #endregion private ToVO ToVO(Role role)

        #endregion Private Methods

        #region Public Methods

        #region public RoleVO Create(CreateRoleReqDTO role)
        /// <summary>
        /// 保存到数据库里
        /// </summary>
        /// <param name="role">角色实体对象</param>
        /// <returns>a value of RoleVO</returns>
        public RoleVO Create(CreateRoleReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Role entity = new Role
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false,
                    RoleId = 0
                };

                //赋值到数据对象类里
                ToEntity(req, entity);

                context.Roles.Add(entity);
                context.SaveChanges();

                //返回对象视图
                return ToVO(entity);
            }
        }
        #endregion public RoleVO Create(CreateRoleReqDTO req)

        #region public RoleVO Modify(ModifyRoleReqDTO req)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleVO Modify(ModifyRoleReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Role? entity = context.Roles.FirstOrDefault(x => x.RoleId == req.RoleId);

                if(entity == null || entity.IsDeleted)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "编号为【" + req.RoleId + "】的角色记录不存在或已被删除" };
                }
                ToEntity(req, entity);
                entity.UpdatedAt = DateTime.Now;
                context.Roles.Update(entity);
                context.SaveChanges();

                return ToVO(entity);
            }
        }
        #endregion public RoleVO Modify(ModifyRoleReqDTO req)

        #region public void Delete(long roleId)
        /// <summary>
        /// 删除角色记录
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <exception cref="ServiceException"></exception>
        public void Delete(long roleId)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
                if (role == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在" };
                }

                role.IsDeleted = true;
                role.UpdatedAt = DateTime.Now;
                context.Roles.Update(role);
                context.SaveChanges();
            }
        }
        #endregion public void Delete(int roleId)

        #region public PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        /// <summary>
        /// 查询角色分页记录
        /// </summary>
        /// <param name="req">分页查询请求内容</param>
        /// <returns>a value of PageResultVO about RoleVO</returns>
        public PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        {
            PageResultVO<RoleVO> pageResult = new PageResultVO<RoleVO>
            {
                PageIndex = req.PageIndex,
                PageSize = req.PageSize,
                RecordCount = 0,
                Data = new List<RoleVO>()
            };

            using (var context = new MicroShopContext())
            {
                IQueryable<Role>? query = context.Roles.Where(x => x.IsDeleted == false);

                if (string.IsNullOrWhiteSpace(req.RoleName))
                {
                    query = query.Where(x => x.RoleName.Contains(req.RoleName.Trim()));
                }
                if (req.IsEnable != null)
                {
                    query = query.Where(x => x.IsEnable == req.IsEnable.Value);
                }
                pageResult.RecordCount = query.Count();
                pageResult.Data = query.OrderByDescending(x => x.RoleId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => ToVO(entity)).ToList();
            }
            return pageResult;
        }

        #endregion public PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)

        #region public RoleVO GetRole(int roleId)
        /// <summary>
        /// 根据角色Id获取角色详情
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleVO GetRole(long roleId)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
                if (role == null || role.IsDeleted == true)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在或者已被删除" };
                }
                return ToVO(role);
            }
        }
        #endregion public RoleVO GetRole(int roleId)

        #region public List<RoleVO> GetRoles()
        /// <summary>
        /// 获取全部可用的角色记录
        /// </summary>
        /// <returns>a lList of RoleVO</returns>
        public List<RoleVO> GetRoles()
        {
            using (var context = new MicroShopContext())
            {
                return context.Roles.Where(x => x.IsEnable == true && x.IsDeleted == false).OrderByDescending(x => x.RoleId).Select(entity => ToVO(entity)).ToList();
            }
        }
        #endregion public List<RoleVO> GetRoles()

        #region public RoleVO? GetRole(string roleName)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public RoleVO? GetRole(string roleName)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleName == roleName.Trim() && x.IsDeleted == false);
                if (role != null)
                {
                    return ToVO(role);
                }
                return null;
            }
        }
        #endregion public RoleVO? GetRole(string roleName)

        #endregion Public Methods
    }
}