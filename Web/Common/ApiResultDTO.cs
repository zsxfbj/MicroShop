namespace MicroShop.Web.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ApiResultDTO<T>
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        public RequestResultCodeEnum RequestResultCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiResultDTO()
        {
            this.RequestResultCode = RequestResultCodeEnum.Success;
            this.ErrorMessage = string.Empty;
            this.Result = default;
        }

    }
}
