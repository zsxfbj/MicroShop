using System;
using System.Text.Json.Serialization;
using MicroShop.Enum.Permission;
using MicroShop.Model.Serialize.Json;
using MicroShop.Enum;

namespace MicroShop.Model.VO.Permission
{
    /// <summary>
    /// 系统用户操作日志
    /// </summary>
    [Serializable]
    public class SystemUserActionLogVO
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long LogId { get; set; } = 0L;

        /// <summary>
        /// 用户编号
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long UserId { get; set; } = 0;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        public ActionTypes ActionType { get; set; } = ActionTypes.View;

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
        public string RemoteIp { get; set; } = string.Empty;

        /// <summary>
        /// 客户端
        /// </summary>
        public string UserAgent { get; set; } = string.Empty;

        /// <summary>
        /// 请求Url地址
        /// </summary>
        public string RequestUrl { get; set; } = string.Empty;

        /// <summary>
        /// 操作内容
        /// </summary>
        public string OperateContent { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
    }
}
