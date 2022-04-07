using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Permission.Enums;
using MicroShop.Web.Common;

namespace MicroShop.Permission.Entity
{
    /// <summary>
    /// 系统用户访问令牌表
    /// </summary>
    [Serializable]
    [Table("system_user_access_token")]
    public class SystemUserAccessTokenEntity
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        [Key]
        [Column("id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// 系统用户编号
        /// </summary>
        [Column("user_id", TypeName = "int")]
        public int UserId { get; set; }

        /// <summary>
        /// 访问的客户端类型
        /// </summary>
        [Column("client_type", TypeName = "int")]
        public ClientTypeEnum ClientType { get; set; }

        /// <summary>
        /// 访问的令牌
        /// </summary>
        [Column("access_token", TypeName = "varchar(256)")]
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// 登录状态
        /// </summary>
        [Column("login_count", TypeName = "int")]
        public LoginStatusEnum LoginStatus { get; set; } = LoginStatusEnum.Allowable;
 
        /// <summary>
        /// 外部用户访问令牌
        /// </summary>
        [Column("out_user_token", TypeName = "varchar(256)")]
        public string OutUserToken  { get; set; }

        /// <summary>
        /// 外部用户编号
        /// </summary>
        [Column("out_user_id", TypeName = "varchar(256)")]
        public string OutUserId { get; set; }

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
    }
}
