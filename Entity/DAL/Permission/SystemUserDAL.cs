using MicroShop.Enums.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.SQLServerDAL.Entity;
using MicroShop.SQLServerDAL.Entity.Permission;
using MicroShop.Utility.Common;

namespace MicroShop.SQLServerDAL.DAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserDAL : ISystemUser
    {
        #region Private Methods

        #region private static void ToEntity(CreateSystemUserReqDTO req, SystemUser systemUser)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="systemUser"></param>
        private static void ToEntity(CreateSystemUserReqDTO req, SystemUser systemUser)
        {
            systemUser.Email = string.IsNullOrEmpty(req.Email) ? "" : req.Email.Trim();
            systemUser.Mobile = string.IsNullOrEmpty(req.Mobile) ? "" : req.Mobile.Trim();
            systemUser.UserName = string.IsNullOrEmpty(req.UserName) ? "" : req.UserName.Trim();
            systemUser.RoleId = req.RoleId;
            systemUser.LoginStatus = req.LoginStatus;
            systemUser.LoginName = string.IsNullOrEmpty(req.LoginName) ? "" : req.LoginName.Trim();
            systemUser.IsAdmin = req.IsAdmin;
        }
        #endregion private static void ToEntity(CreateSystemUserReqDTO req, SystemUser systemUser)

        #region private static SystemUserDTO ToDTO(SystemUser systemUser)
        /// <summary>
        /// 转成业务使用的数据结构
        /// </summary>
        /// <param name="systemUser">系统用户表数据</param>
        /// <param name="context">数据库缓存对象</param>
        /// <returns></returns>
        private static SystemUserVO ToDTO(SystemUser systemUser, MicroShopContext context)
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
                RoleName = ""
            };

            if(systemUser.RoleId > 0)
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == systemUser.RoleId);
                if(role != null)
                {
                    dto.RoleName = role.RoleName;
                }
            }
            return dto;
        }
        #endregion private static SystemUserDTO ToDTO(SystemUser systemUser)

        #region private static SystemUser GetSystemUser(int userId, MicroShopContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        private static SystemUser GetSystemUser(int userId, MicroShopContext context)
        {
            SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
            if (systemUser == null)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("编号为{0}的系统用户记录不存在", userId) };
            }
            return systemUser;
        }
        #endregion private static SystemUser GetSystemUser(int userId, MicroShopContext context)

        #endregion Private Methods

        #region public SystemUserDTO Create(CreateSystemUserReqDTO req)
        /// <summary>
        /// 创建系统用户
        /// </summary>
        /// <param name="req">新增系统用户请求内容</param>
        /// <returns>MicroShop.Model.Permission.SystemUserDTO</returns>      
        public SystemUserVO Create(CreateSystemUserReqDTO req)
        {
           
            SystemUser systemUser = new SystemUser();
            ToEntity(req, systemUser);
            systemUser.LoginPassword = req.LoginPassword.Trim().Sha256();
            using (var context = new MicroShopContext())
            {
                //入库
                context.SystemUsers.Add(systemUser);
                context.SaveChanges();
                return ToDTO(systemUser, context);             
            }           
        }
        #endregion public SystemUserDTO Create(CreateSystemUserReqDTO req)

        #region public SystemUserDTO Modify(ModifySystemUserReqDTO req)
        /// <summary>
        /// 修改系统用户信息
        /// </summary>
        /// <param name="req">修改系统用户的请求内容</param>
        /// <returns>MicroShop.Model.Permission.SystemUserDTO</returns>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException"></exception>
        public SystemUserVO Modify(ModifySystemUserReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == req.UserId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("编号为{0}，登录名为{1}系统用户记录不存在", req.UserId, req.LoginName) };
                }

                ToEntity(req, systemUser);
                //判断是否修改了密码：如果密码框有输入，则自动修改密码，否者不变。
                if (!string.IsNullOrEmpty(req.LoginPassword))
                {
                    systemUser.LoginPassword = req.LoginPassword.Trim().Sha256();
                }

                systemUser.UpdatedAt = DateTime.Now;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
                return ToDTO(systemUser, context);
            }
        }
        #endregion public SystemUserDTO Modify(ModifySystemUserReqDTO req)

        #region public void ModifyLoginPassword(string passowrd, int userId)
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="passowrd">密码</param>
        /// <param name="userId">用户Id</param>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常信息</exception>
        public void ModifyLoginPassword(string passowrd, int userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser systemUser = GetSystemUser(userId, context);

                systemUser.LoginPassword = passowrd.Trim().Sha256();
                systemUser.UpdatedAt = DateTime.Now;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
            }
        }
        #endregion public void ModifyLoginPassword(string passowrd, int userId)

        #region public SystemUserDTO GetSystemUserDTO(int userId)
        /// <summary>
        /// 根据用户编号获取系统用户基础信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>SystemUserDTO</returns>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常信息</exception>
        public SystemUserVO GetSystemUser(int userId)
        {
            using (var context = new MicroShopContext())
            {                
                return ToDTO(GetSystemUser(userId, context), context);
            }
        }
        #endregion public GetSystemUser GetSystemUserDTO(int userId)

        #region public void Delete(int userId)
        /// <summary>
        /// 根据用户Id删除用户记录，同时删除操作日志表里的所有数据
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常信息</exception>
        public void Delete(int userId)
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
        #endregion public void Delete(int userId)

        #region public void SetLoginStatus(int userId)
        /// <summary>
        /// 禁用/启动用户登录状态
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException">服务异常信息</exception>
        public void SetLoginStatus(int userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser systemUser = GetSystemUser(userId, context);
                systemUser.LoginStatus = systemUser.LoginStatus == LoginStatusEnum.Allowable ? LoginStatusEnum.Forbidden : LoginStatusEnum.Allowable;
                systemUser.UpdatedAt = DateTime.Now;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
            }
        }
        #endregion public void SetLoginStatus(int userId)

        #region public SystemUserDTO GetSystemUserDTO(string loginName)
        /// <summary>
        /// 根据登录名称查询系统用户信息
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        /// <exception cref="MicroShop.Model.Common.Exception.ServiceException"></exception>
        public SystemUserVO GetSystemUserDTO(string loginName)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.LoginName == loginName.Trim());
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("登录名为{0}的系统用户记录不存在", loginName) };
                }
                return ToDTO(systemUser, context);
            }
        }
        #endregion public SystemUserDTO GetSystemUserDTO(string loginName)

        public PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req)
        {
            PageResultVO<SystemUserVO> pageResult = new PageResultVO<SystemUserVO>
            {
                PageIndex = req.PageIndex.HasValue ? req.PageIndex.Value : 1,
                PageSize = req.PageSize.HasValue ? req.PageSize.Value : 10,
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
                pageResult.Data = query.OrderByDescending(x => x.UserId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => ToDTO(entity, context)).ToList();
                //输出结果
                return pageResult;
            }
            
        }
    }
}
