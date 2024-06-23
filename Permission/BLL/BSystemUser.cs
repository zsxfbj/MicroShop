using MicroShop.Permission.Entity;
using MicroShop.Permission.Model;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;
using MicroShop.Web.Common.SystemUser;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 系统用户相关
    /// </summary>
    public class BSystemUser : Singleton<BSystemUser>
    {
        #region public SystemUserDTO Create(CreateSystemUserDTO createSystemUser)
        /// <summary>
        /// 创建系统用户
        /// </summary>
        /// <param name="createSystemUser"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public SystemUserDTO Create(CreateSystemUserDTO createSystemUser)
        {
            createSystemUser.InitData();

            using (var context = new PermissionContext())
            {
                if (context.SystemUsers.Where(x => x.LoginName == createSystemUser.LoginName).Count() > 0)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.LoginNameIsExist, ErrorMessage = "登录名已存在" };
                }

                RoleDTO role = BRole.GetInstance().GetRole(createSystemUser.RoleId);

                if (string.IsNullOrEmpty(createSystemUser.LoginPassword))
                {
                    createSystemUser.LoginPassword = "123456";
                }

                SystemUserEntity systemUser = new SystemUserEntity
                {
                    RoleId = createSystemUser.RoleId,
                    AccessToken = "",
                    LoginCount = 0,
                    LoginName = createSystemUser.LoginName,
                    UserName = createSystemUser.UserName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = createSystemUser.Email,
                    Mobile = createSystemUser.Mobile,
                    IsAdmin = createSystemUser.IsAdmin,
                    LoginPassword = createSystemUser.LoginPassword.Sha256(),
                    LoginStatus = createSystemUser.LoginStatus,
                    UserId = 0
                };
                context.SystemUsers.Add(systemUser);
                context.SaveChanges();
                SystemUserDTO systemUserDTO = GetSystemUserDTO(systemUser);
                systemUserDTO.RoleName = role.RoleName;

                return systemUserDTO;
            }
        }
        #endregion public SystemUserDTO Create(CreateSystemUserDTO createSystemUser)

        #region public SystemUserDTO Modify(ModifySystemUserDTO modifySystemUser)
        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="modifySystemUser"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public SystemUserDTO Modify(ModifySystemUserDTO modifySystemUser)
        {
            modifySystemUser.InitData();
            using (var context = new PermissionContext())
            {
                if (context.SystemUsers.Where(x => x.LoginName == modifySystemUser.LoginName && x.UserId != modifySystemUser.UserId).Count() > 0)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.LoginNameIsExist, ErrorMessage = "登录名已重复" };
                }

                RoleDTO role = BRole.GetInstance().GetRole(modifySystemUser.RoleId);

                SystemUserEntity? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == modifySystemUser.UserId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "系统用户信息不存在" };
                }
                systemUser.UpdatedAt = DateTime.Now;

                SystemUserTokenDTO systemUserToken = BSystemUserToken.GetInstance().GetSystemUserToken();
                if (systemUserToken.IsAdmin)
                {
                    systemUser.IsAdmin = modifySystemUser.IsAdmin;
                    if (!string.IsNullOrEmpty(modifySystemUser.LoginPassword))
                    {
                        systemUser.LoginPassword = modifySystemUser.LoginPassword.Sha256();
                    }
                }

                systemUser.Email = modifySystemUser.Email;
                systemUser.Mobile = modifySystemUser.Mobile;
                systemUser.UserName = modifySystemUser.UserName;
                systemUser.RoleId = modifySystemUser.RoleId;
                systemUser.LoginStatus = modifySystemUser.LoginStatus;
                systemUser.LoginName = modifySystemUser.LoginName;
                SystemUserDTO systemUserDTO = GetSystemUserDTO(systemUser);
                systemUserDTO.RoleName = role.RoleName;
                return systemUserDTO;
            }
        }
        #endregion public SystemUserDTO Modify(ModifySystemUserDTO modifySystemUser)

        #region public SystemUserDTO GetSystemUserDTO(int userId)
        /// <summary>
        /// 获取系统用户详细信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SystemUserDTO GetSystemUserDTO(int userId)
        {
            if (userId <= 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "系统用户编号格式错误" };
            }

            using (var context = new PermissionContext())
            {
                SystemUserEntity? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "系统用户信息不存在" };
                }

                RoleDTO role = BRole.GetInstance().GetRole(systemUser.RoleId);

                SystemUserDTO systemUserDTO = GetSystemUserDTO(systemUser);
                systemUserDTO.RoleName = role.RoleName;
                return systemUserDTO;
            }
        }
        #endregion public SystemUserDTO GetSystemUserDTO(int userId)

        #region public void Delete(int userId)
        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="userId">用户编号</param>
        public void Delete(int userId)
        {
            if (userId <= 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "系统用户编号格式错误" };
            }

            using (var context = new PermissionContext())
            {
                SystemUserEntity? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "系统用户信息不存在" };
                }
                context.SystemUsers.Remove(systemUser);
                context.SaveChanges();
            }

            //    SystemUserTokenDTO systemUserToken = BSystemUserToken.GetInstance().GetSystemUserToken(accessor);
            //    SaveSystemUserActionLogDTO saveSystemUserActionLog = new SaveSystemUserActionLogDTO
            //    {
            //        AccessToken = systemUserToken.AccessToken,
            //        UserId = systemUserToken.UserId,
            //        ActionType = Enums.ActionTypeEnum.Delete,
            //        ClientType = Web.AdminApi.Core.HttpContext,
            //        OperateContent = "删除系统用户：编号：" + userId,
            //         RemoteIp = 
            //};
        }
        #endregion public void Delete(int userId)

        #region public void SetLoginStatus(int userId)
        /// <summary>
        /// 设置登录状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accessor"></param>
        /// <exception cref="ServiceException"></exception>
        public void SetLoginStatus(int userId)
        {
            if (userId <= 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "系统用户编号格式错误" };
            }

            SystemUserTokenDTO systemUserToken = BSystemUserToken.GetInstance().GetSystemUserToken();
            if (!systemUserToken.IsAdmin)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotAllowAccess, ErrorMessage = "您无权设置系统用户登录状态" };
            }
            using (var context = new PermissionContext())
            {
                SystemUserEntity? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "系统用户信息不存在" };
                }

                systemUser.LoginStatus = systemUser.LoginStatus == Enums.LoginStatusEnum.Allowable ? Enums.LoginStatusEnum.Forbidden : Enums.LoginStatusEnum.Allowable;
                systemUser.UpdatedAt = DateTime.Now;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
            }
        }
        #endregion public void SetLoginStatus(int userId)

        #region public LoginResultDTO Login(SystemUserLoginDTO systemUserLogin)
        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <param name="systemUserLogin"></param>      
        /// <returns></returns>
        public SystemUserLoginResultDTO Login(SystemUserLoginDTO systemUserLogin)
        {
            //初始化数据
            systemUserLogin.InitData();
            string accessToken = HttpContext.GetHeaderValue(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY);    
            SystemUserEntity? systemUser = null;

            using (var context = new PermissionContext())
            {
                systemUser = context.SystemUsers.FirstOrDefault(x => x.LoginName == systemUserLogin.LoginName);
            }
            if (systemUser == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.SystemUserNotExist, ErrorMessage = "登录账号不存在" };
            }

            if (string.IsNullOrEmpty(systemUser.AccessToken))
            {
                systemUser.AccessToken = accessToken;
            }

            systemUser.LoginCount += 1;

            //定义输出对象
            SystemUserLoginResultDTO loginResult = new SystemUserLoginResultDTO
            {
                UpdatedAt = systemUser.UpdatedAt,
                LoginName = systemUser.LoginName,
                UserName = systemUser.UserName,
                RoleId = systemUser.RoleId,
                IsAdmin = systemUser.IsAdmin,
                LoginCount = systemUser.LoginCount,
                RoleMenus = null
            };

            if(systemUser.RoleId > 0)
            {
                RoleDTO roleDTO = BRole.GetInstance().GetRole(systemUser.RoleId);
                if (roleDTO != null)
                {
                    loginResult.RoleName = roleDTO.RoleName;
                }
            }
            else
            {
                loginResult.RoleName = "";
            }
           

            SystemUserTokenDTO systemUserToken = BSystemUserToken.GetInstance().GetSystemUserToken(systemUser.AccessToken);
            systemUserToken.Mobile = systemUser.Mobile;
            systemUserToken.Email = systemUserToken.Email;
            systemUserToken.UserName = systemUser.UserName;
            systemUserToken.UserId = systemUser.UserId;
            systemUserToken.ClientType = (ClientTypeEnum)Enum.Parse(typeof(ClientTypeEnum), HttpContext.GetHeaderValue(HeaderParameters.CLIENT_TYPE_KEY));
            systemUserToken.IsAdmin = systemUser.IsAdmin;
            systemUserToken.RoleId = systemUser.RoleId;
            BSystemUserToken.GetInstance().CacheSystemUserToken(systemUserToken);
            loginResult.AccessToken = systemUserToken.AccessToken;
            if (systemUser.IsAdmin)
            {
                loginResult.RoleMenus = BRoleMenuRelation.GetInstance().GetAdminMenus();
            }
            else
            {
                loginResult.RoleMenus = BRoleMenuRelation.GetInstance().GetRoleMenus(systemUser.RoleId);
            }

            //更新记录
            systemUser.AccessToken = loginResult.AccessToken;
            systemUser.UpdatedAt = DateTime.Now;

            using (var context = new PermissionContext())
            {
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
            }

            HttpContext.Current.Response.Headers.Add(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY, loginResult.AccessToken);
            return loginResult;
        }
        #endregion public LoginResultDTO Login(SystemUserLoginDTO systemUserLogin, IHttpContextAccessor accessor)

        #region public PageResultDTO<SystemUserDTO> GetPagedSystemUsers(QuerySystemUserDTO querySystemUser)
        /// <summary>
        /// 分页查询系统用户记录
        /// </summary>
        /// <param name="querySystemUser"></param>
        /// <returns></returns>
        public PageResultDTO<SystemUserDTO> GetPagedSystemUsers(QuerySystemUserDTO querySystemUser)
        {
            if (querySystemUser == null)
            {
                querySystemUser = new QuerySystemUserDTO { PageIndex = 1, PageSize = 10 };
            }

            querySystemUser.InitData();

            PageResultDTO<SystemUserDTO> pageResult = new PageResultDTO<SystemUserDTO>
            {
                PageIndex = querySystemUser.PageIndex.HasValue ? querySystemUser.PageIndex.Value : 1,
                PageSize = querySystemUser.PageSize.HasValue ? querySystemUser.PageSize.Value : 10,
                RecordCount = 0,
                Data = new List<SystemUserDTO>()
            };

            using var context = new PermissionContext();
            var query = context.SystemUsers.Where(x => x.UserId > 0);
            if (!string.IsNullOrEmpty(querySystemUser.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(querySystemUser.Keyword) || x.LoginName.Contains(querySystemUser.Keyword));
            }
            if (!string.IsNullOrEmpty(querySystemUser.Mobile))
            {
                query = query.Where(x => x.Mobile == querySystemUser.Mobile);
            }
            if (!string.IsNullOrEmpty(querySystemUser.Email))
            {
                query = query.Where(x => x.Email == querySystemUser.Email);
            }
            if (querySystemUser.RoleId.HasValue && querySystemUser.RoleId.Value > 0)
            {
                query = query.Where(x => x.RoleId == querySystemUser.RoleId.Value);
            }
            pageResult.RecordCount = query.LongCount();
            pageResult.Data = query.OrderByDescending(x => x.UserId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => GetSystemUserDTO(entity)).ToList();
            //输出结果
            return pageResult;
        }
        #endregion public PageResultDTO<SystemUserDTO> GetPagedSystemUsers(QuerySystemUserDTO querySystemUser)

        #region private static SystemUserDTO GetSystemUserDTO(SystemUserEntity systemUser)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        private static SystemUserDTO GetSystemUserDTO(SystemUserEntity systemUser)
        {
            return new SystemUserDTO
            {
                UserId = systemUser.UserId,
                UserName = systemUser.UserName,
                LoginCount = systemUser.LoginCount,
                LoginName = systemUser.LoginName,
                CreatedAt = systemUser.CreatedAt,
                UpdatedAt = systemUser.UpdatedAt,
                IsAdmin = systemUser.IsAdmin,
                LoginStatus = systemUser.LoginStatus,
                RoleId = systemUser.RoleId
            };
        }
        #endregion private static SystemUserDTO GetSystemUserDTO(SystemUserEntity systemUser)
    }
}