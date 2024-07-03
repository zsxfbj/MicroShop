using MicroShop.Enums.Web;

namespace MicroShop.Model.VO.Web
{
    /// <summary>
    /// API接口返回基础结构
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    [Serializable]
    public class ApiResultVO<T>
    {
        /// <summary>
        /// 请求结果状态值
        /// </summary>
        public RequestResultCodeEnum ResultCode { get; set; } = RequestResultCodeEnum.UnkownError;

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;

        /// <summary>
        /// 结果数据
        /// </summary>
        public T Result { get; set; } = default!;


        /// <summary>
        /// 获取错误结果
        /// </summary>
        /// <param name="requestResultCode">错误码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>ApiResult</returns>
        public static ApiResultVO<T> Error(RequestResultCodeEnum requestResultCode, string errorMessage)
        {
            return new ApiResultVO<T>
            {
                ResultCode = requestResultCode,
                ErrorMessage = errorMessage,
                Result = default!
            };             
        }

        /// <summary>
        /// 获取成功的消息
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ApiResultVO<T> Success(T result)
        {
            return new ApiResultVO<T>
            {
                ResultCode = RequestResultCodeEnum.Success,
                ErrorMessage = String.Empty,
                Result = result
            };
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiResultVO()
        {
            this.ResultCode = RequestResultCodeEnum.Success;
            this.ErrorMessage = string.Empty;
            this.Result = default!;
        }

    }
}
