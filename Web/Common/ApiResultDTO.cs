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
        public RequestResultCodeEnum ResultCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// 获取错误结果
        /// </summary>
        /// <param name="requestResultCode">错误码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>ApiResult</returns>
        public static ApiResultDTO<T> Error(RequestResultCodeEnum requestResultCode, string errorMessage)
        {
            return new ApiResultDTO<T>
            {
                ResultCode = requestResultCode,
                ErrorMessage = errorMessage,
                Result = default
            };             
        }

        /// <summary>
        /// 获取成功的消息
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ApiResultDTO<T> Success(T result)
        {
            return new ApiResultDTO<T>
            {
                ResultCode = RequestResultCodeEnum.Success,
                ErrorMessage = String.Empty,
                Result = result
            };
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiResultDTO()
        {
            this.ResultCode = RequestResultCodeEnum.Success;
            this.ErrorMessage = string.Empty;
            this.Result = default;
        }

    }
}
