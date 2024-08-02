using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroShop.Enum.Permission;


namespace MicroShop.Entity.Permission
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
        [Column("log_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; } = 0L;

        /// <summary>
        /// 系统用户编号
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; } = 0L;

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 访问的令牌
        /// </summary>
        [Column("access_token")]
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        [Column("action_type")]
        public ActionTypes ActionType { get; set; } = ActionTypes.View;

        /// <summary>
        /// 远程访问的IP
        /// </summary>
        [Column("remote_ip")]
        public string RemoteIp { get; set; } = "127.0.0.1";

        /// <summary>
        /// 访问的客户端头信息
        /// </summary>
        [Column("user_agent")]
        public string UserAgent { get; set; } = string.Empty;

        /// <summary>
        /// 请求的相对地址
        /// </summary>
        [Column("request_url")]
        public string RequestUrl { get; set; } = string.Empty;

        /// <summary>
        /// 操作内容
        /// </summary>
        [Column("operate_content")]
        public string OperateContent { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
 
    }
}
