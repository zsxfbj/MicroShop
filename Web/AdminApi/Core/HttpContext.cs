using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.Web.AdminApi.Core
{
    /// <summary>
    /// 当前HttpContext方法
    /// </summary>
    public class HttpContext
    {
        #region public static string? GetClientIp(IHttpContextAccessor accessor)
        /// <summary>
        /// 获取客户端访问的ip
        /// </summary>    
        /// <returns></returns>
        public static string? GetClientIp(IHttpContextAccessor accessor)
        {
            if (accessor != null && accessor.HttpContext != null)
            {
                string? ip = accessor.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                {
                    if (accessor.HttpContext.Connection != null && accessor.HttpContext.Connection.RemoteIpAddress != null)
                    {
                        ip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                        return ip.Replace("::ffff:", "");
                    }
                }
            }
            return "127.0.0.1";
        }
        #endregion public static string? GetClientIp(IHttpContextAccessor accessor)

        #region public static string GetBaseUrl(IHttpContextAccessor accessor)
        /// <summary>
        /// 获取基础访问地址
        /// </summary>
        /// <returns>String</returns>
        public static string GetBaseUrl(IHttpContextAccessor accessor)
        {
            if (accessor != null && accessor.HttpContext != null)
            {
                return accessor.HttpContext.Request.Scheme + "://" + accessor.HttpContext.Request.Host.Value;
            }
            return "/";
        }
        #endregion public static string GetBaseUrl(IHttpContextAccessor accessor)

        #region public static string GetAccessToken(IHttpContextAccessor accessor)
        /// <summary>
        /// 获取请求头的Token
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken(IHttpContextAccessor accessor)
        {
            string? token = string.Empty;
            if (accessor != null && accessor.HttpContext != null)
            {
                token = accessor.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY].FirstOrDefault();
                if (string.IsNullOrEmpty(token))
                {
                    token = accessor.HttpContext.Request.Cookies[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY];
                }
            }

            if (string.IsNullOrEmpty(token))
            {
                token = StringHelper.GetGuid();
            }
            return token;
        }
        #endregion public static string GetAccessToken(IHttpContextAccessor accessor)
    }
}
