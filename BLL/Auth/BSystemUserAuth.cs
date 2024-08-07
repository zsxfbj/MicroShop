﻿using MicroShop.Enums.Web;
using MicroShop.Model.Auth;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.BLL.Auth
{
    /// <summary>
    /// 系统用户认证相关
    /// </summary>
    public class BSystemUserAuth
    {
        /// <summary>
        /// 缓存的Key
        /// </summary>
        private const string SystemUserAccessTokenCacheKey = "ms-sys-user-auth-";

        #region  public SystemUserTokenDTO GetSystemUserToken()
        /// <summary>
        /// 从请求参数里获取系统用户访问令牌
        /// </summary>       
        /// <returns>SystemUserTokenDTO</returns>
        public static SystemUserTokenDTO GetSystemUserToken()
        {   
            return GetSystemUserToken(HttpContext.Current.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY]);
        }
        #endregion public SystemUserTokenDTO GetSystemUserToken(IHttpContextAccessor accessor)

        #region public SystemUserTokenDTO GetSystemUserToken(string accessToken = "")
        /// <summary>
        /// 获取用户访问令牌
        /// </summary>
        /// <param name="accessor"></param>
        /// <returns></returns>
        public static SystemUserTokenDTO GetSystemUserToken(string? accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                accessToken = StringHelper.GetGuid();
            }

            SystemUserTokenDTO? systemUserToken = null;
            string cacheKey = SystemUserAccessTokenCacheKey + accessToken;

            if (RedisClient.KeyExists(cacheKey))
            {
                systemUserToken = RedisClient.StringGet<SystemUserTokenDTO>(cacheKey);
            }

            if (systemUserToken == null)
            {
                systemUserToken = new SystemUserTokenDTO
                {
                    AccessToken = accessToken,
                    UserId = 0,                
                    Email = "",
                    IsAdmin = false,
                    Mobile = "",
                    RoleId = 0,
                    UserName = string.Empty
                };
            }
            //缓存
            RedisClient.StringSet(cacheKey, systemUserToken, TimeSpan.FromMinutes(15));
            return systemUserToken;
        }
        #endregion public SystemUserTokenDTO GetSystemUserToken(string accessToken = "")

        #region public void CacheSystemUserToken(SystemUserTokenDTO systemUserToken)
        /// <summary>
        /// 缓存访问令牌
        /// </summary>
        /// <param name="systemUserToken">系统用户访问令牌</param>
        public static void CacheSystemUserToken(SystemUserTokenDTO systemUserToken)
        {
            if (systemUserToken != null)
            {
                if (string.IsNullOrEmpty(systemUserToken.AccessToken))
                {
                    systemUserToken.AccessToken = StringHelper.GetGuid();
                }
                //更新缓存时间
                systemUserToken.CacheTime = DateTime.Now.ToString(Constants.DEFAULT_DATETIME_FORMAT);
                //缓存15天
                RedisClient.StringSet(SystemUserAccessTokenCacheKey + systemUserToken.AccessToken, systemUserToken, TimeSpan.FromDays(Constants.FIFTEEN));
            }
        }
        #endregion public void CacheSystemUserToken(SystemUserTokenDTO systemUserToken)
    }
}
