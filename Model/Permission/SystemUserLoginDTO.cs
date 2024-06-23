using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 系统用户登录
    /// </summary>
    [Serializable]
    public class SystemUserLoginDTO
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required(ErrorMessage = "登录名必须填写")]
        [StringLength(30, ErrorMessage = "登录名最多30个字符")]
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Required(ErrorMessage = "登录密码必须填写")]
        [StringLength(256, ErrorMessage = "登录密码为256个字符")]
        public string LoginPassword { get; set; }

        /// <summary>
        /// 图形验证码必须填写
        /// </summary>
        [Required(ErrorMessage = "验证码必须填写")]
        [StringLength(4, ErrorMessage = "验证码为4位字符")]
        public string VerifyCode { get; set; }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            LoginName = LoginName.Trim();
            LoginPassword = LoginPassword.Trim();
            VerifyCode = VerifyCode.Trim();
        }
    }
}
