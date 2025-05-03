using MicroShop.Common.Enum.Permission;
using MicroShop.Database.IDAL.Permission;
using MicroShop.Common.Model.Common.Exception;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using MicroShop.Common.Enum.Web;
using MicroShop.Model.Base;

namespace MicroShop.Database.SQLServerDAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUser : ISystemUser
    {
        #region Private Methods

        #region private static void ToEntity(CreateSystemUserReqDTO req, SystemUser systemUser)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="systemUser"></param>
        private static void ToEntity(CreateSystemUserReqDTO req, SystemUser entity)
        {
            entity.RoleId = req.RoleId;
            entity.LoginName = req.LoginName.Trim();
            entity.UserName = req.UserName.Trim();
            entity.LoginStatus = req.LoginStatus;
            entity.LoginPassword = req.LoginPassword;
            entity.IsAdmin = req.IsAdmin;
            entity.Email = req.Email;
            entity.Mobile = req.Mobile;
            entity.ErpCode = req.ErpCode;
            entity.ErpName = req.ErpName;
        }
        #endregion private static void ToEntity(CreateSystemUserReqDTO req, SystemUser systemUser)

        #region private static SystemUserDTO ToDTO(SystemUser systemUser)
        /// <summary>
        /// 转成业务使用的数据结构
        /// </summary>
        /// <param name="systemUser">系统用户表数据</param>
        /// <param name="context">数据库缓存对象</param>
        /// <returns></returns>
        private static SystemUserVO ToVO(SystemUser systemUser, MicroShopContext context)
        {
            SystemUserVO dto = new SystemUserVO
            {
                UserId = systemUser.UserId,
                UserName = string.IsNullOrEmpty(systemUser.UserName) ? "" : systemUser.UserName,
                LoginCount = systemUser.LoginCount,
                LoginName = string.IsNullOrEmpty(systemUser.LoginName) ? "" : systemUser.LoginName,
                CreatedAt = systemUser.CreatedAt,
                UpdatedAt = systemUser.UpdatedAt,
                IsAdmin = systemUser.IsAdmin,
                LoginStatus = systemUser.LoginStatus,
                RoleId = systemUser.RoleId,
                RoleName = "",
                Mobile = string.IsNullOrEmpty(systemUser.Mobile) ? "" : systemUser.Mobile,
                Email = string.IsNullOrEmpty(systemUser.Email) ? "" : systemUser.Email,
                ErpCode = string.IsNullOrEmpty(systemUser.ErpCode) ? "" : systemUser.ErpCode,
                ErpName = string.IsNullOrEmpty(systemUser.ErpName) ? "" : systemUser.ErpName,
                LastLogin = systemUser.LastLogin.HasValue ? systemUser.LastLogin.Value.ToString(Constants.DEFAULT_DATETIME_FORMAT) : ""
            };

            if (systemUser.RoleId > 0)
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == systemUser.RoleId);
                if (role != null)
                {
                    dto.RoleName = role.RoleName;
                }
            }
            return dto;
        }
        #endregion private static SystemUserDTO ToDTO(SystemUser systemUser)

        #region private static SystemUser GetSystemUser(long userId, MicroShopContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        private static SystemUser GetSystemUser(long userId, MicroShopContext context)
        {
            SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
            if (systemUser == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodes.NotFound, ErrorMessage = string.Format("编号为{0}的系统用户记录不存在", userId) };
            }
            return systemUser;
        }
        #endregion private static SystemUser GetSystemUser(long userId, MicroShopContext context)

        #endregion Private Methods

        #region Public Methods

        #region public SystemUserVO Create(CreateSystemUserReqDTO req)
        /// <summary>
        /// 创建系统用户
        /// </summary>
        /// <param name="req">新增系统用户请求内容</param>
        /// <returns>MicroShop.Common.Model.Permission.SystemUserDTO</returns>      
        public SystemUserVO Create(CreateSystemUserReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser entity = new SystemUser
                {
                    UserId = 0,
                    LastLogin = null,
                    LoginCount = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Salt = StringHelper.GetRandNum(6)
                };

                //数据转化
                ToEntity(req, entity);

                //生成密码
                entity.LoginPassword = (entity.Salt + req.LoginPassword.Trim()).Sha256();

                //加到数据库缓存里
                context.SystemUsers.Add(entity);

                //保存到数据库文件里
                context.SaveChanges();

                //返回系统用户视图
                return ToVO(entity, context);
            }
        }
        #endregion public SystemUserVO Create(CreateSystemUserReqDTO req)

        #region public SystemUserVO Modify(ModifySystemUserReqDTO req)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SystemUserVO Modify(ModifySystemUserReqDTO req)
        {
            using var context = new MicroShopContext();
            SystemUser? entity = context.SystemUsers.FirstOrDefault(x => x.UserId == req.UserId);
            if (entity == null || entity.IsDeleted)
            {
                throw new ServiceException { ErrorCode = RequestResultCodes.NotFound, ErrorMessage = "编号为【" + req.UserId + "】系统用户记录不存在" };
            }
            //数据转化
            ToEntity(req, entity);
            entity.UpdatedAt = DateTime.Now;

            if (!string.IsNullOrEmpty(req.LoginPassword))
            {
                entity.Salt = StringHelper.GetRandNum(6);
                entity.LoginPassword = (entity.Salt + req.LoginPassword.Trim()).Sha256();
            }

            //推送到数据库缓存里
            context.SystemUsers.Update(entity);

            //保存到数据库文件里
            context.SaveChanges();

            //返回系统用户视图
            return ToVO(entity, context);
        }
        #endregion public SystemUserVO Modify(ModifySystemUserReqDTO req)

        #region public void ModifyLoginPassword(string passowrd, long userId)
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="passowrd">密码</param>
        /// <param name="userId">用户Id</param>
        /// <exception cref="ServiceException">服务异常信息</exception>
        public void ModifyLoginPassword(string passowrd, long userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser systemUser = GetSystemUser(userId, context);
                systemUser.Salt = StringHelper.GetRandNum(6);
                systemUser.LoginPassword = (systemUser.Salt + passowrd.Trim()).Sha256();
                systemUser.UpdatedAt = DateTime.Now;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
            }
        }
        #endregion public void ModifyLoginPassword(string passowrd, long userId)

        #region public SystemUserVO GetSystemUser(long userId)
        /// <summary>
        /// 根据用户编号获取系统用户基础信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>SystemUserDTO</returns>
        /// <exception cref="ServiceException">服务异常信息</exception>
        public SystemUserVO GetSystemUser(long userId)
        {
            using (var context = new MicroShopContext())
            {
                return ToVO(GetSystemUser(userId, context), context);
            }
        }
        #endregion public SystemUserVO GetSystemUser(long userId)

        #region public void Delete(long userId)
        /// <summary>
        /// 根据用户Id删除用户记录，同时删除操作日志表里的所有数据
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <exception cref="ServiceException">服务异常信息</exception>
        public void Delete(long userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser systemUser = GetSystemUser(userId, context);

                //删除对应的操作日志
                context.SystemUserActionLogs.Where(x => x.UserId == userId).DeleteFromQuery();

                context.SystemUsers.Remove(systemUser);
                context.SaveChanges();
            }
        }
        #endregion public void Delete(long userId)

        #region public void SetLoginStatus(long userId)
        /// <summary>
        /// 禁用/启动用户登录状态
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <exception cref="ServiceException">服务异常信息</exception>
        public void SetLoginStatus(long userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser systemUser = GetSystemUser(userId, context);
                systemUser.LoginStatus = systemUser.LoginStatus == LoginStatuses.Allowable ? LoginStatuses.Forbidden : LoginStatuses.Allowable;
                systemUser.UpdatedAt = DateTime.Now;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
            }
        }
        #endregion public void SetLoginStatus(long userId)

        #region public SystemUserVO GetSystemUser(string loginName)
        /// <summary>
        /// 根据登录名称查询系统用户信息
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public SystemUserVO? GetSystemUser(string loginName)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.LoginName == loginName.Trim() && x.IsDeleted == false);
                if (systemUser == null)
                {
                    return null;
                }
                return ToVO(systemUser, context);
            }
        }
        #endregion public SystemUserVO GetSystemUser(string loginName)

        #region public PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PageResult<SystemUserVO> GetPageResult(SystemUserPageReqDTO req)
        {
            PageResult<SystemUserVO> pageResult = new PageResult<SystemUserVO>
            {
                PageIndex = req.PageIndex,
                PageSize = req.PageSize,
                RecordCount = 0,
                Data = new List<SystemUserVO>()
            };

            using (var context = new MicroShopContext())
            {
                var query = context.SystemUsers.Where(x => x.UserId > 0);
                if (!string.IsNullOrEmpty(req.Keyword))
                {
                    query = query.Where(x => x.UserName.Contains(req.Keyword) || x.LoginName.Contains(req.Keyword));
                }
                if (!string.IsNullOrEmpty(req.Mobile))
                {
                    query = query.Where(x => x.Mobile.Contains(req.Mobile.Trim()));
                }
                if (!string.IsNullOrEmpty(req.Email))
                {
                    query = query.Where(x => x.Email.Contains(req.Email.Trim()));
                }
                if (req.RoleId.HasValue && req.RoleId.Value > 0)
                {
                    query = query.Where(x => x.RoleId == req.RoleId.Value);
                }
                pageResult.RecordCount = query.LongCount();
                pageResult.Data = query.OrderByDescending(x => x.UserId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => ToVO(entity, context)).ToList();
                //输出结果
                return pageResult;
            }
        }
        #endregion public PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req)

        #endregion Public Methods

    }
}
