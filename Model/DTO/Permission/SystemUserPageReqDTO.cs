using System.ComponentModel.DataAnnotations;
using MicroShop.Model.DTO.Web;

namespace MicroShop.Model.DTO.Permission
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
        [Display(Name = "关键词"),StringLength(30, ErrorMessage = "{0}不能超过30个字符")]
        public string Keyword { get; set; } = string.Empty;

        /// <summary>
        /// 角色编号
        /// </summary>
        [Display(Name = "角色编号")]
        public int? RoleId { get; set; } 

        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号"), RegularExpression(pattern: @"^1[34578]\\d{9}$", ErrorMessage = "手机号格式错误")]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Display(Name = "电子邮箱"), DataType(DataType.EmailAddress, ErrorMessage = "电子邮箱格式错误")]
        public string Email { get; set; } = string.Empty;


    }
}
