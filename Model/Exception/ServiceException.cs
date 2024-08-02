using System;
using MicroShop.Enum;
using MicroShop.Enum.Web;
 

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
        public RequestResultCodes ErrorCode { get; set; } = RequestResultCodes.UnkownError;

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;

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
