
using System;

namespace MicroShop.Common.Model.DTO.TencentCloud
{
    /// <summary>
    /// 腾讯云云存储配置类
    /// </summary>
    [Serializable]
    public class CosConfigDTO
    {
        /// <summary>
        /// 云存储应用编号
        /// </summary>
        public string AppId {  get; set; } = string.Empty;

        /// <summary>
        /// 云存储密钥ID
        /// </summary>
        public string SecretId { get; set; } = string.Empty;

        /// <summary>
        /// 云存储密钥Key
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// 云存储名称
        /// </summary>
        public string BucketName { get; set; } = string.Empty;

        /// <summary>
        /// 所在地域
        /// </summary>
        public string Region { get; set; } = string.Empty;


    }
}
