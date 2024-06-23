using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MicroShop.Utility.Common;

namespace MicroShop.Web.Common.Filter
{
    /// <summary>
    /// 默认过滤器
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
                context.Result = new OkObjectResult(ApiResultDTO<string>.Error(RequestResultCodeEnum.RequestParameterError, string.IsNullOrEmpty(errorMsg) ? RequestResultCodeEnum.RequestParameterError.GetDescription() : errorMsg.Trim()));
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
            if (context.HttpContext.Request.Headers.ContainsKey(HeaderParameters.USER_AUTH_TOKEN_KEY))
            {
                if (!context.HttpContext.Response.Headers.ContainsKey(HeaderParameters.USER_AUTH_TOKEN_KEY))
                {
                    context.HttpContext.Response.Headers.Add(HeaderParameters.USER_AUTH_TOKEN_KEY, HttpContext.Current.Request.Cookies[HeaderParameters.USER_AUTH_TOKEN_KEY]);
                }
                else
                {
                    context.HttpContext.Response.Headers[HeaderParameters.USER_AUTH_TOKEN_KEY] = context.HttpContext.Request.Headers[HeaderParameters.USER_AUTH_TOKEN_KEY];
                }
            }

            if (context.HttpContext.Request.Headers.ContainsKey(HeaderParameters.CLIENT_TYPE_KEY))
            {
                if (!context.HttpContext.Response.Headers.ContainsKey(HeaderParameters.CLIENT_TYPE_KEY))
                {
                    context.HttpContext.Response.Headers.Add(HeaderParameters.CLIENT_TYPE_KEY, HttpContext.Current.Request.Cookies[HeaderParameters.CLIENT_TYPE_KEY]);
                }
                else
                {
                    context.HttpContext.Response.Headers[HeaderParameters.CLIENT_TYPE_KEY] = context.HttpContext.Request.Headers[HeaderParameters.CLIENT_TYPE_KEY];
                }
            }

            if (context.HttpContext.Request.Headers.ContainsKey(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY))
            {
                if (!context.HttpContext.Response.Headers.ContainsKey(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY))
                {
                    context.HttpContext.Response.Headers.Add(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY, HttpContext.Current.Request.Cookies[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY]);
                }
                else
                {
                    context.HttpContext.Response.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY] = context.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY];
                }
            }

        }
    }
}
