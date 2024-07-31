
namespace MicroShop.Utility.Model.TencentCloud
{
    /// <summary>
    /// 腾讯云短信通道参数
    /// </summary>
    [Serializable]
    public class SmsConfig
    {
        /// <summary>
        /// 信应用的唯一标识
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 校验短信发送合法性的密码
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 短信签名
        /// </summary>
        public string Sign {  get; set; }

        /// <summary>
        /// 访问API接口的AppId
        /// </summary>
        public string ApiAppId { get; set; }

        /// <summary>
        /// 访问API接口的密钥Id
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// 访问API接口的密钥
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SmsConfig() 
        {
            AppId = string.Empty;
            AppKey = string.Empty;
            Sign = string.Empty;
            ApiAppId = string.Empty;
            SecretId = string.Empty;
            SecretKey = string.Empty;
        }
    }
}
