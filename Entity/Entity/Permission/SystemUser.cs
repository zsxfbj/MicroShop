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
        [Column("login_name", TypeName = "nvarchar(32)")]
        [Required(ErrorMessage = "登录名不能为控"), StringLength(32, ErrorMessage = "登录名最对32个字")]
        public string LoginName { get; set; } = string.Empty;

        /// <summary>
        /// 密码加盐
        /// </summary>
        [Column("salt", TypeName = "varchar(16)")]
        public string Salt { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码
        /// </summary>
        [Column("login_password", TypeName = "varchar(512)")]
        [Required(ErrorMessage = "登录密码不能为空"), StringLength(512, ErrorMessage = "密码长度最多512位")]
        public string LoginPassword { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name", TypeName = "nvarchar(64)")]
        [Required(ErrorMessage = "用户名不能为空"), StringLength(64, ErrorMessage = "用户名最多60个字")]
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
        /// 最新登录时间
        /// </summary>
        [Column("last_login")]
        public DateTime? LastLogin {  get; set; }
    }
}
