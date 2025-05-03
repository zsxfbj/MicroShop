using System;
using MicroShop.Enum.Web;

namespace MicroShop.Model.DTO.Web
{
    /// <summary>
    /// 请求的Header参数及值
    /// </summary>
    [Serializable]
    public class RequestHeaderDTO
    {
        /// <summary>
        /// 访问的令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 访问的客户端类型
        /// </summary>
        public ClientTypes ClientType { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RequestHeaderDTO()
        {
            AccessToken = string.Empty;
            ClientType = ClientTypes.PCWeb;
        }
    }
}
