using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enums.Permission;

namespace MicroShop.SQLServerDAL.Entity.Permission
{
    /// <summary>
    /// 系统用户表
    /// </summary>
    [Serializable]
    [Table("system_user")]
    public class SystemUser
    {
        /// <summary>
        /// 系统用户编号
        /// </summary>
        [Key]
        [Column("user_id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } = 0;

        /// <summary>
        /// 角色编号
        /// </summary>
        [Column("role_id", TypeName = "int")]
        [Range(0, int.MaxValue, ErrorMessage = "角色编号不在范围内")]
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 登录名
        /// </summary>
        [Column("login_name", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "登录名不能为控"), StringLength(50, ErrorMessage = "登录名最对50个字")]
        public string LoginName { get; set; } = string.Empty;

        /// <summary>
        /// 访问的令牌
        /// </summary>
        [Column("access_token", TypeName = "varchar(256)")]
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码
        /// </summary>
        [Column("login_password", TypeName = "varchar(256)")]
        [Required(ErrorMessage = "登录密码不能为空"), StringLength(256, ErrorMessage = "登录密码不能为空")]
        public string LoginPassword { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name", TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "用户名不能为空"), StringLength(30, ErrorMessage = "用户名最多30个字")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("mobile", TypeName = "varchar(30)")]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Column("email", TypeName = "varchar(256)")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 是否管理员
        /// </summary>
        [Column("is_admin", TypeName = "bit")]
        public bool IsAdmin { get; set; } = false;

        /// <summary>
        /// 登录状态
        /// </summary>
        [Column("login_status", TypeName = "int")]
        public LoginStatusEnum LoginStatus { get; set; } = LoginStatusEnum.Forbidden;

        /// <summary>
        /// 登录次数
        /// </summary>
        [Column("login_count", TypeName = "int")]
        public int LoginCount { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at", TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemUser()
        {
            UserId = 0;
            RoleId = 0;
            LoginName = "";
            LoginPassword = "";
            AccessToken = "";
            LoginCount = 0;
            UserName = "";
            Email = "";
            Mobile = "";
            IsAdmin = false;
            LoginStatus = LoginStatusEnum.Forbidden;
            UpdatedAt = DateTime.Now;
            CreatedAt = DateTime.Now;
        }
    }
}
