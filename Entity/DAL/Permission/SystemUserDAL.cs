using MicroShop.Enums.Permission;
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
    public class SystemUserDAL : ISystemUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SystemUserDTO Create(CreateSystemUserReqDTO req)
        {
            SystemUser systemUser = new SystemUser();
            ToEntity(req, systemUser);

            using (var context = new MicroShopContext())
            {
                context.SystemUsers.Add(systemUser);
                context.SaveChanges();
            }

            return ToDTO(systemUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public SystemUserDTO Modify(ModifySystemUserReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == req.UserId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("编号为{0}，登录名为{1}系统用户记录不存在", req.UserId, req.LoginName) };
                }

                ToEntity(req, systemUser);
                systemUser.UpdatedAt = DateTime.Now;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
                return ToDTO(systemUser);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public SystemUserDTO GetSystemUserDTO(int userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("编号为{0}的系统用户记录不存在", userId) };
                }
                return ToDTO(systemUser);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <exception cref="ServiceException"></exception>
        public void Delete(int userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("编号为{0}的系统用户记录不存在", userId) };
                }

                //删除对应的操作日志
                context.SystemUserActionLogs.Where(x => x.UserId == userId).DeleteFromQuery();

                context.SystemUsers.Remove(systemUser);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <exception cref="ServiceException"></exception>
        public void SetLoginStatus(int userId)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.UserId == userId);
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("编号为{0}为{1}系统用户记录不存在", userId) };
                }
                systemUser.LoginStatus = systemUser.LoginStatus == LoginStatusEnum.Allowable ? LoginStatusEnum.Forbidden : LoginStatusEnum.Allowable;
                context.SystemUsers.Update(systemUser);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public SystemUserDTO GetSystemUserDTO(string loginName)
        {
            using (var context = new MicroShopContext())
            {
                SystemUser? systemUser = context.SystemUsers.FirstOrDefault(x => x.LoginName == loginName.Trim());
                if (systemUser == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = string.Format("登录名为{0}的系统用户记录不存在", loginName) };
                }
                return ToDTO(systemUser);
            }
        }

        public PageResultDTO<SystemUserDTO> GetPageResult(SystemUserPageReqDTO req)
        {
            throw new NotImplementedException();
        }

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


        #region private static SystemUserDTO ToDTO(SystemUser systemUser)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        private static SystemUserDTO ToDTO(SystemUser systemUser)
        {
            return new SystemUserDTO
            {
                UserId = systemUser.UserId,
                UserName = string.IsNullOrEmpty(systemUser.UserName) ? "" : systemUser.UserName,
                LoginCount = systemUser.LoginCount,
                LoginName = string.IsNullOrEmpty(systemUser.LoginName) ? "" : systemUser.LoginName,
                CreatedAt = systemUser.CreatedAt,
                UpdatedAt = systemUser.UpdatedAt,
                IsAdmin = systemUser.IsAdmin,
                LoginStatus = systemUser.LoginStatus,
                RoleId = systemUser.RoleId
            };
        }
        #endregion private static SystemUserDTO ToDTO(SystemUser systemUser)
    }
}
