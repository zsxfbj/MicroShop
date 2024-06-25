using System.ComponentModel.DataAnnotations;
using MicroShop.Model.Web;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// /
    /// </summary>
    [Serializable]
    public class SystemUserPageReqDTO : PageRequestDTO
    {
        /// <summary>
        /// 关键词（登录账号或者姓名）
        /// </summary>
        public string Keyword { get; set; } = string.Empty;

        /// <summary>
        /// 角色编号
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DataType(DataType.PhoneNumber, ErrorMessage = "手机号格式错误")]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [DataType(DataType.EmailAddress, ErrorMessage = "电子邮箱格式错误")]
        public string Email { get; set; } = string.Empty;

        
    }
}
