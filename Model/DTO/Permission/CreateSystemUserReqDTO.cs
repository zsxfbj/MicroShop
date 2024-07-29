using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MicroShop.Enums.Permission;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 创建系统用户请求
    /// </summary>
    [Serializable]
    public class CreateSystemUserReqDTO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Required(ErrorMessage = "请选择用户角色")]
        [Range(0, int.MaxValue, ErrorMessage = "请选择用户角色")]
        public int RoleId { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>   
        [Required(ErrorMessage = "登录名必须填写")]
        [StringLength(30, ErrorMessage = "登录名不得超过30个字")]
        public string LoginName { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码
        /// </summary>
        [StringLength(30, MinimumLength = 6, ErrorMessage = "密码6~30位")]
        public string LoginPassword { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>     
        [Description("用户名")]
        [Required(ErrorMessage = "用户名必须填写")]
        [StringLength(30, ErrorMessage = "用户名不得超过30个字")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 是否管理员
        /// </summary> 
        [Description("是否管理员")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 登录状态
        /// </summary>       
        [Description("登录状态")]
        public LoginStatusEnum LoginStatus { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [DataType(DataType.EmailAddress, ErrorMessage = "电子邮箱格式错误")]
        [StringLength(100, ErrorMessage = "电子邮箱字符数必须小于100")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 手机号
        /// </summary>
        [RegularExpression(pattern: @"^1[3456789]\d{9}$", ErrorMessage = "手机号码格式错误")]
        [StringLength(16, ErrorMessage = "手机号码长度超过16位")]
        public string Mobile { get; set; } = string.Empty;


        /// <summary>
        /// Erp对应的编码
        /// </summary>
        [StringLength(32, ErrorMessage = "Erp对应的编码长度超过32个字符")]
        public string ErpCode { get; set; } = string.Empty;

        /// <summary>
        /// Erp对应的名称
        /// </summary>
        [StringLength(32, ErrorMessage = "Erp对应的名称长度超过32个字数")]
        public string ErpName { get; set; } = string.Empty;

    }
}
