using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MicroShop.Common.Model.Serialize.Json;

namespace MicroShop.Common.Model.Auth
{
    /// <summary>
    /// 用户访问令牌类，存储相关的信息
    /// </summary>
    [Serializable]
    public class UserTokenDTO
    {
        /// <summary>
        /// 令牌
        /// </summary>      
        [Required(ErrorMessage = "访问令牌不能为空")]
        public string Token { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImage { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserTokenDTO()
        {
            Token = string.Empty;
            UserId = 0;
            UserName = string.Empty;
            HeadImage = string.Empty;
        }

    }
}
