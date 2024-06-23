using System;
using System.Text.Json.Serialization;
using MicroShop.Utility.Common;
using MicroShop.Utility.Serialize.Json;

namespace MicroShop.Permission.Model
{
    /// <summary>
    /// 系统用户操作日志
    /// </summary>
    [Serializable]
    public class SystemUserActionLogDTO
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long LogId { get; set; }
    
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public Enums.ActionTypeEnum ActionType { get; set; }

        /// <summary>
        /// 操作类型名称
        /// </summary>
        public string ActionTypeName
        {
            get
            {
                return ActionType.GetDescription();
            }
        }

        /// <summary>
        /// 客户端Ip
        /// </summary>
        public string RemoteIp { get; set; }

        /// <summary>
        /// 客户端
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string OperateContent { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemUserActionLogDTO()
        {
            LogId = 0;
            UserId = 0;
            UserName = "";
            AccessToken = "";
            ActionType = Enums.ActionTypeEnum.None;
            RemoteIp = "";
            UserAgent = "";
            OperateContent = "";
            CreatedAt = DateTime.Now;
        }
    }
}
