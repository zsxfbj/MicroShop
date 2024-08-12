namespace MicroShop.Common.Model.Auth
{
    /// <summary>
    /// 头部请求参数
    /// </summary>
    public class HeaderParameters
    {
        /// <summary>
        /// 用户访问令牌
        /// </summary>
        public const string USER_AUTH_TOKEN_KEY = "X-Auth-Token";

        /// <summary>
        /// 客户端类型
        /// </summary>
        public const string CLIENT_TYPE_KEY = "X-Client-Type";

        /// <summary>
        /// 系统用户访问令牌
        /// </summary>
        public const string SYSTEM_USER_AUTH_TOKEN_KEY = "X-System-Auth-Token";

        /// <summary>
        /// 租户令牌
        /// </summary>
        public const string TENANT_ID_KEY = "X-Tenant";

        /// <summary>
        /// 应用Id令牌
        /// </summary>
        public const string APP_CODE_KEY = "X-App-Code";
    }
}
