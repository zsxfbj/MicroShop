using System;

namespace MicroShop.Common.Model.DTO.TencentCloud
{
    /// <summary>
    /// 腾讯云短信通道参数
    /// </summary>
    [Serializable]
    public class SmsConfigDTO
    {
        /// <summary>
        /// 信应用的唯一标识
        /// </summary>
        public string AppId { get; set; } = string.Empty;

        /// <summary>
        /// 校验短信发送合法性的密码
        /// </summary>
        public string AppKey { get; set; } = string.Empty;

        /// <summary>
        /// 短信签名
        /// </summary>
        public string Sign {  get; set; } = string.Empty;

        /// <summary>
        /// 访问API接口的AppId
        /// </summary>
        public string ApiAppId { get; set; } = string.Empty;

        /// <summary>
        /// 访问API接口的密钥Id
        /// </summary>
        public string SecretId { get; set; } = string.Empty;
        /// <summary>
        /// 访问API接口的密钥
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;
        
    }
}
