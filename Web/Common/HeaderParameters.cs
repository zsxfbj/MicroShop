using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Web.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class HeaderParameters
    {
        /// <summary>
        /// 用户访问令牌
        /// </summary>
        public const string USER_AUTH_TOKEN_KEY = "X-Auth-Token";

        /// <summary>
        /// 客户类型
        /// </summary>
        public const string CLIENT_TYPE_KEY = "X-Client-Type";


        public const string SYSTEM_USER_AUTH_TOKEN_KEY = "X-System-Auth-Token";
    }
}
