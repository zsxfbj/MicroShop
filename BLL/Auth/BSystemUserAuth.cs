using MicroShop.Enums.Web;
using MicroShop.Model.Auth;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.BLL.Auth
{
    /// <summary>
    /// 系统用户认证相关
    /// </summary>
    public class BSystemUserAuth : Singleton<BSystemUserAuth>        
    {
        /// <summary>
        /// 缓存的Key
        /// </summary>
        private const string SystemUserAccessTokenCacheKey = "SystemUserAccessToken-";

        #region  public SystemUserTokenDTO GetSystemUserToken()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        /// <returns></returns>
        public SystemUserTokenDTO GetSystemUserToken()
        {
            string accessToken = HttpContext.Current.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY];
            string clientTypeValue = HttpContext.Current.Request.Headers[HeaderParameters.CLIENT_TYPE_KEY];
            ClientTypeEnum clientType = ClientTypeEnum.PCWeb;
            if (Enum.IsDefined(typeof(ClientTypeEnum), clientTypeValue))
            {
                clientType = (ClientTypeEnum)Enum.Parse(typeof(ClientTypeEnum), clientTypeValue);
            }
            return GetSystemUserToken(accessToken, clientType);
        }
        #endregion public SystemUserTokenDTO GetSystemUserToken(IHttpContextAccessor accessor)

        #region public SystemUserTokenDTO GetSystemUserToken(string accessToken = "")
        /// <summary>
        /// 获取用户访问令牌
        /// </summary>
        /// <param name="accessor"></param>
        /// <returns></returns>
        public SystemUserTokenDTO GetSystemUserToken(string accessToken = "", ClientTypeEnum clientType = ClientTypeEnum.PCWeb)
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
                    ClientType = clientType,
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
        /// <param name="systemUserToken"></param>
        public void CacheSystemUserToken(SystemUserTokenDTO systemUserToken)
        {
            if (systemUserToken != null)
            {
                if (string.IsNullOrEmpty(systemUserToken.AccessToken))
                {
                    systemUserToken.AccessToken = StringHelper.GetGuid();
                }
                RedisClient.StringSet(SystemUserAccessTokenCacheKey + systemUserToken.AccessToken, systemUserToken, TimeSpan.FromHours(18));
            }
        }
        #endregion public void CacheSystemUserToken(SystemUserTokenDTO systemUserToken)
    }
}
