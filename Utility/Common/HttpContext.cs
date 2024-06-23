using Microsoft.AspNetCore.Http;

namespace MicroShop.Utility.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpContext
    {
        private const string UserAgent = "User-Agent";

        /// <summary>
        /// 私有变量
        /// </summary>
        private static IHttpContextAccessor _accessor;

        /// <summary>
        /// 定义当前访问请求
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                return _accessor.HttpContext;
            }
        }

        /// <summary>
        /// 内部配置方法
        /// </summary>
        /// <param name="accessor"></param>
        public static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// 获取客户端访问的ip
        /// </summary>    
        /// <returns></returns>
        public static string GetClientIp()
        {
            var ip = Current.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = Current.Connection.RemoteIpAddress.ToString();
            }
            return ip.Replace("::ffff:", "");
        }

        /// <summary>
        /// 获取客户端类型
        /// </summary>
        /// <returns></returns>
        public static string GetUserAgent()
        {
            if (Current.Request.Headers.ContainsKey(UserAgent))
            {
                return Current.Request.Headers[UserAgent];
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取基础访问地址
        /// </summary>
        /// <returns>String</returns>
        public static string GetBaseUrl()
        {
            return Current.Request.Scheme + "://" + Current.Request.Host.Value;
        }

        /// <summary>
        /// 获取Header指定键值的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHeaderValue(string key)
        {
            if (Current.Request.Headers.ContainsKey(key))
            {
                return Current.Request.Headers[key];
            }
            return string.Empty;
        }

    }
}
