using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroShop.Web.Common.Filter
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// 发生异常进入
        /// </summary>
        /// <param name="context"></param>
        Task IAsyncExceptionFilter.OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                ContentResult result = new ContentResult
                {
                    StatusCode = 200,
                    ContentType = "application/json;charset=utf-8;"
                };
                ApiResultVO<string> apiResult = new ApiResultVO<string>();
                if (context.Exception.GetType() == typeof(ServiceException))
                {
                    ServiceException se = (ServiceException)context.Exception;
                    apiResult.ResultCode = se.ErrorCode;
                    apiResult.ErrorMessage = se.ErrorMessage;
                }
                else if (context.Exception.GetType() == typeof(FileNotFoundException))
                {
                    apiResult.ResultCode = RequestResultCodeEnum.NotFound;
                    apiResult.ErrorMessage = "文件未找到";
                }
                else
                {
                    apiResult.ResultCode = RequestResultCodeEnum.UnkownError;
                    apiResult.ErrorMessage = context.Exception.Message;
                }
                result.Content = JsonConvert.SerializeObject(apiResult);
                context.Result = result;
                Console.WriteLine("结果异常：" + context.Exception.ToString());
            }

            // 设置为true，表示异常已经被处理了
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
