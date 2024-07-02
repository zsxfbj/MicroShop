using MicroShop.BLL.Auth;
using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Auth;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BSystemUser : Singleton<BSystemUser>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly static ISystemUser dal = SystemUserFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SystemUserVO Create(CreateSystemUserReqDTO req)
        {
            return dal.Create(req);
        }
            

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SystemUserVO Modify(ModifySystemUserReqDTO req) { return dal.Modify(req); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SystemUserVO GetSystemUser(int userId ) { return dal.GetSystemUser(userId); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void Delete(int userId) { dal.Delete(userId); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void SetLoginStatus(int userId)
        {
            dal.SetLoginStatus(userId);
        }

        public PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req)
        {
            return dal.GetPageResult(req);
        }

        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SystemUserLoginResultVO Login(SystemUserLoginReqDTO req)
        {
            SystemUserTokenDTO systemUserToken = BSystemUserAuth.GetInstance().GetSystemUserToken();
            SystemUserVO systemUser = null;
            if (systemUserToken.UserId > 0)
            {
                systemUser = dal.GetSystemUser(systemUserToken.UserId);                
            }
            else
            {
                systemUser = dal.GetSystemUser(req.LoginName);
                
            }
            if (systemUser == null)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "用户信息异常，请清空浏览器缓存后，再重新登录！" };
            }

            if(systemUserToken.UserId == 0)
            {
                systemUserToken.UserId = systemUser.UserId;
                systemUserToken.UserName = systemUser.UserName;
                systemUserToken.RoleId = systemUser.RoleId;
                if(systemUser.RoleId > 0)
                {
                    RoleVO role = BRole.GetInstance().GetRole(systemUser.RoleId);
                    systemUserToken.RoleName = role.RoleName;
                }
                else
                {
                    systemUserToken.RoleName = "";
                }
               
            }

            return new SystemUserLoginResultVO
            {
                AccessToken = systemUserToken.AccessToken,
                IsAdmin = systemUserToken.IsAdmin,
                LoginCount = systemUser.LoginCount,
                LoginName = systemUser.LoginName,
                RoleId = systemUser.RoleId,
                RoleName = systemUserToken.RoleName,
                RoleMenus = new List<RoleMenuVO>(),
                UpdatedAt = systemUser.UpdatedAt,
                UserName = systemUser.UserName
            };
        }
    }
}
