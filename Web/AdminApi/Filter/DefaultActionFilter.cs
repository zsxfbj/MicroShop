using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Filter
{
    /// <summary>
    /// 默认操作拦截器
    /// </summary>
    public class DefaultActionFilter : IActionFilter
    {
        /// <summary>
        /// action执行前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //校验参数
            if (!context.ModelState.IsValid)
            {
                var errorMsg = context.ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).FirstOrDefault();
                if (errorMsg == null)
                {
                    errorMsg = "未知异常错误";
                }
                context.Result = new OkObjectResult(ApiResultDTO<string>.Error(RequestResultCodeEnum.RequestParameterError, errorMsg));
                return;
            }
        }

        /// <summary>
        /// action执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Header头输入输出参数配置
            if (context.HttpContext.Request.Headers.ContainsKey(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY))
            {
                context.HttpContext.Response.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY] = context.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY];
            }
        }
    }
}
