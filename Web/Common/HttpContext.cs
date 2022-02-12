using Microsoft.AspNetCore.Http;

namespace MicroShop.Web.Common
{
    /// <summary>
    /// 重写HttpContext类
    /// </summary>
    public static class HttpContext
    {
        /// <summary>
        /// 私有变量
        /// </summary>
        private static IHttpContextAccessor? _accessor;

        /// <summary>
        /// 定义当前访问请求
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                if(_accessor == null)
                {
                    _accessor = new HttpContextAccessor();
                }
                return _accessor.HttpContext;
            }
        }

        /// <summary>
        /// 内部配置方法
        /// </summary>
        /// <param name="accessor"></param>
        internal static void Configure(IHttpContextAccessor accessor)
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
                ip = Current.Request.Headers["REMOTE_ADDR"].FirstOrDefault();
                if(string.IsNullOrEmpty(ip))
                {
                    ip = Current.Connection.RemoteIpAddress.ToString();
                }
            }
            return ip;
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
        /// 获取请求头的Token
        /// </summary>
        /// <returns></returns>
        public static string GetUserToken()
        {
            var token = Current.Request.Headers[HeaderParameters.USER_AUTH_TOKEN_KEY].FirstOrDefault();
            if (!string.IsNullOrEmpty(token))
            {
                return token;
            }
            return string.Empty;
        }

        /// <summary>
        /// 设置令牌键值
        /// </summary>
        /// <param name="token">访问令牌</param>
        public static void SetUserToken(string token = "")
        {
            if (string.IsNullOrEmpty(token))
            {
                token = Guid.NewGuid().ToString();
            }
            Current.Response.Headers.Add(HeaderParameters.USER_AUTH_TOKEN_KEY, token);
        }

        /// <summary>
        /// 获取客户端名称
        /// </summary>
        /// <returns></returns>
        public static ClientTypeEnum GetClientType()
        {
            var clientTypeValue = Current.Request.Headers[HeaderParameters.CLIENT_TYPE_KEY].FirstOrDefault();
            if(clientTypeValue != null && Enum.IsDefined(typeof(ClientTypeEnum), clientTypeValue))
            {
                return (ClientTypeEnum)Enum.Parse(typeof(ClientTypeEnum), clientTypeValue);
            }
            return ClientTypeEnum.PCWeb;
        }

    }

}
