using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MicroShop.Web.Common.User
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
        [Key]
        [Required(ErrorMessage = "访问令牌不能为空")]
        public string? Token { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 用户编号
        /// </summary>
        [JsonConverter(typeof(Utility.Serialize.Json.LongToStringConverter))]
        public long UserId { get; set; } = 0;

        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; } = string.Empty;

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImage { get; set; } = string.Empty;


        

    }
}
