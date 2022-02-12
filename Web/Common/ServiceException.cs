namespace MicroShop.Web.Common
{
    /// <summary>
    /// 服务异常类
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public RequestResultCodeEnum ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string? ErrorMessage { get; set; }

    }
}
