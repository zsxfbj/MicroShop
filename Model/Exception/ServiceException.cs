using MicroShop.Enums.Web;
using MicroShop.Utility.Common;

namespace MicroShop.Model.Common.Exception
{
    /// <summary>
    /// 服务异常类
    /// </summary>
    [Serializable]
    public class ServiceException : System.Exception
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public RequestResultCodeEnum ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            return "ErrorCode:" + (int) ErrorCode + ", ErrorMessage: " + (string.IsNullOrEmpty(ErrorMessage) ? ErrorCode.GetDescription() : ErrorMessage);
        }

    }
}
