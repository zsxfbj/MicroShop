
namespace MicroShop.Utility.Model.TencentCloud
{
    /// <summary>
    /// 腾讯云云存储配置类
    /// </summary>
    [Serializable]
    public class CosConfig
    {
        /// <summary>
        /// 云存储应用编号
        /// </summary>
        public string AppId {  get; set; }

        /// <summary>
        /// 云存储密钥ID
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// 云存储密钥Key
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 云存储名称
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// 所在地域
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CosConfig() {
            AppId = string.Empty;
            SecretId = string.Empty;
            SecretKey = string.Empty;
            BucketName = string.Empty;
            Region = string.Empty;
        }

       


    }
}
