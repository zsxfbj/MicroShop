using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enums.Permission;

namespace MicroShop.Entity.Permission
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
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; } = 0L;

        /// <summary>
        /// 角色编号
        /// </summary>
        [Column("role_id")]       
        public long RoleId { get; set; } = 0L;

        /// <summary>
        /// 登录名
        /// </summary>
        [Column("login_name")]       
        public string LoginName { get; set; } = string.Empty;

        /// <summary>
        /// 密码加盐
        /// </summary>
        [Column("salt")]
        public string Salt { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码
        /// </summary>
        [Column("login_password")]     
        public string LoginPassword { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name")]     
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("mobile")]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 是否管理员
        /// </summary>
        [Column("is_admin")]
        public bool IsAdmin { get; set; } = false;

        /// <summary>
        /// 登录状态
        /// </summary>
        [Column("login_status")]
        public LoginStatusEnum LoginStatus { get; set; } = LoginStatusEnum.Forbidden;

        /// <summary>
        /// 登录次数
        /// </summary>
        [Column("login_count")]
        public int LoginCount { get; set; } = 0;

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Erp对应的编码
        /// </summary>
        [Column("erp_code")]
        public string ErpCode { get; set; } = string.Empty;

        /// <summary>
        /// Erp对应的名称
        /// </summary>
        [Column("erp_name")]
        public string ErpName { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 最新登录时间
        /// </summary>
        [Column("last_login")]
        public DateTime? LastLogin { get; set; } = default(DateTime);
    }
}
