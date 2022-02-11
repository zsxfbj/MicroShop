using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string Token { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        
        public long UserId { get; set; }




    }
}
