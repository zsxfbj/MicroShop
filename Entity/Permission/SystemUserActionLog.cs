using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enums.Permission;

namespace MicroShop.SQLServerDAL.Permission
{
    /// <summary>
    /// 系统用户操作记录表
    /// </summary>
    [Serializable]
    [Table("system_user_action_log")]
    public class SystemUserActionLog
    {
        /// <summary>
        /// 增值流水号
        /// </summary>
        [Key]
        [Column("log_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; } = 0L;

        /// <summary>
        /// 系统用户编号
        /// </summary>
        [Column("user_id", TypeName = "int")]
        public int UserId { get; set; } = 0;

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name", TypeName = "nvarchar(32)")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 访问的令牌
        /// </summary>
        [Column("access_token", TypeName = "varchar(256)")]
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        [Column("action_type", TypeName = "int")]
        public ActionTypeEnum ActionType { get; set; } = ActionTypeEnum.View;

        /// <summary>
        /// 远程访问的IP
        /// </summary>
        [Column("remote_ip", TypeName = "varchar(128)")]
        public string RemoteIp { get; set; } = "127.0.0.1";

        /// <summary>
        /// 访问的客户端头信息
        /// </summary>
        [Column("user_agent", TypeName = "varchar(512)")]
        public string UserAgent { get; set; } = string.Empty;

        /// <summary>
        /// 请求的相对地址
        /// </summary>
        [Column("request_url", TypeName = "varchar(1024)")]
        public string RequestUrl { get; set; } = string.Empty;

        /// <summary>
        /// 操作内容
        /// </summary>
        [Column("operate_content", TypeName = "ntext")]
        public string OperateContent { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
 
    }
}
