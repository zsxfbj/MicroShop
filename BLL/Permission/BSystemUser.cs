using MicroShop.BLL.Auth;
using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Auth;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 系统用户相关业务逻辑方法
    /// </summary>
    public class BSystemUser
    {
        /// <summary>
        /// 缓存
        /// </summary>
        private const string SystemUserTokenCacheKey = "system-user-token-";

        /// <summary>
        /// 数据访问层实例对象
        /// </summary>
        private readonly static ISystemUser dal = SystemUserFactory.Create();

        #region private static void RemoveCache(int userId)
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="userId">用户Id</param>
        private static void RemoveCache(int userId)
        {
            //清理缓存
            string key = SystemUserTokenCacheKey + userId;
            if (RedisClient.KeyExists(key))
            {
                //读取用户的访问令牌
                string? token = RedisClient.StringGet<string>(key);
                //设置已登录的系统用户登录状态无效
                SystemUserTokenDTO systemUserToken = BSystemUserAuth.GetSystemUserToken(token);
                systemUserToken.UserId = 0;
                BSystemUserAuth.CacheSystemUserToken(systemUserToken);
                //移除缓存
                RedisClient.KeyDelete(key);
            }
        }
        #endregion private static void RemoveCache(int userId)

        #region public static SystemUserVO Create(CreateSystemUserReqDTO req)
        /// <summary>
        /// 创建系统用户
        /// </summary>
        /// <param name="req">新增系统用的请求内容</param>
        /// <returns>MicroShop.Model.VO.Permission.SystemUserVO</returns>
        public static SystemUserVO Create(CreateSystemUserReqDTO req)
        {
            //判断登录名是否重复
            SystemUserVO checkUser;
            try
            {
                checkUser = dal.GetSystemUser(req.LoginName.Trim());
            }
            catch (Exception e)
            {
                LogHelper.Error("BSystemUser.Create: " + e.ToString());
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "新增系统用户查询重复登录名发生异常！" };
            }
            //不为空则抛出异常
            if (checkUser != null)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NameIsExist, ErrorMessage = "登录名有重复，请修改登录账号" };
            }

            try
            {
                return dal.Create(req);
            }
            catch (Exception e)
            {
                LogHelper.Error("BSystemUser.Create: " + e.ToString());
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "新增系统用户记录入库发生异常！" };
            }
        }
        #endregion public static SystemUserVO Create(CreateSystemUserReqDTO req)

        #region public static SystemUserVO Modify(ModifySystemUserReqDTO req)
        /// <summary>
        /// 修改系统用户的信息，同时强制消除登录状态
        /// </summary>
        /// <param name="req">修改系统用户信息的请求</param>
        /// <returns>MicroShop.Model.VO.Permission.SystemUserVO</returns>
        public static SystemUserVO Modify(ModifySystemUserReqDTO req)
        {
            //判断登录名是否重复
            SystemUserVO checkUser;
            try
            {
                checkUser = dal.GetSystemUser(req.LoginName.Trim());
            }
            catch (Exception e)
            {
                LogHelper.Error("BSystemUser.Modify: " + e.ToString());
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "修改系统用户查询重复登录名发生异常！" };
            }
            if (checkUser != null && checkUser.UserId != req.UserId)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NameIsExist, ErrorMessage = "登录名有重复，请修改登录账号" };
            }

            try
            {
                //清理缓存
                RemoveCache(req.UserId);
                //更新并返回最新试图
                return dal.Modify(req); 
            }
            catch (Exception e)
            {
                LogHelper.Error("BSystemUser.Modify: " + e.ToString());
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "修改系统用户记录入库发生异常！" };
            }
        }
        #endregion public static SystemUserVO Modify(ModifySystemUserReqDTO req)

        #region public static SystemUserVO GetSystemUser(int userId)
        /// <summary>
        /// 根据用户Id查询系统用户信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>MicroShop.Model.VO.Permission.SystemUserVO</returns>
        public static SystemUserVO GetSystemUser(int userId)
        {
            if (userId <= 0)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "用户Id参数错误" };
            }
            try
            {
                return dal.GetSystemUser(userId);
            }
            catch (Exception e)
            {
                LogHelper.Error("BSystemUser.GetSystemUser: " + e.ToString());
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "读取系统用户记录时访问数据库异常！" };
            }            
        }
        #endregion public static SystemUserVO GetSystemUser(int userId)

        #region public static void Delete(int userId)
        /// <summary>
        /// 根据用户Id删除用户信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        public static void Delete(int userId)
        {
            if (userId <= 0)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "用户Id参数错误" };
            }
            try
            {
                //清除缓存
                RemoveCache(userId);
                //删除用户相关记录
                dal.Delete(userId);
            }
            catch (Exception e)
            {
                LogHelper.Error("BSystemUser.Delete: " + e.ToString());
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "删除系统用户记录时访问数据库异常！" };
            }           
        }
        #endregion public static void Delete(int userId)

        #region public static void SetLoginStatus(int userId)
        /// <summary>
        /// 设置系统用户的可登录状态
        /// </summary>
        /// <param name="userId">用户Id</param>
        public static void SetLoginStatus(int userId)
        {
            if (userId <= 0)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "用户Id参数错误" };
            }
            try
            {
                //清除缓存
                RemoveCache(userId);
                //更新用户可登录系统的状态
                dal.SetLoginStatus(userId);
            }
            catch (Exception e)
            {
                LogHelper.Error("BSystemUser.SetLoginStatus: " + e.ToString());
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "更新系统用户可登录状态时访问数据库异常！" };
            }            
        }
        #endregion public static void SetLoginStatus(int userId)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req)
        {
            return dal.GetPageResult(req);
        }

        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static SystemUserLoginResultVO Login(SystemUserLoginReqDTO req)
        {
            SystemUserTokenDTO systemUserToken = BSystemUserAuth.GetSystemUserToken();
            SystemUserVO systemUser;
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

            //比较密码
            string password = (systemUser.Salt + req.LoginPassword).Sha256();
            if (!systemUser.LoginPassword.Equals(password, StringComparison.OrdinalIgnoreCase))
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "登录密码错误！" };
            }

            if (systemUserToken.UserId == 0)
            {
                systemUserToken.UserId = systemUser.UserId;
                systemUserToken.UserName = systemUser.UserName;
                systemUserToken.RoleId = systemUser.RoleId;
                if (systemUser.RoleId > 0)
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
