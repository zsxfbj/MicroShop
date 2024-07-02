using MicroShop.BLL.Auth;
using MicroShop.BLL.Permission;
using MicroShop.Enums.Web;
using MicroShop.Model.Auth;
using MicroShop.Model.Common.Exception;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroShop.Web.AdminApi.Filter
{
    /// <summary>
    /// 用户登录效验
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class LoginAuth : Attribute, IActionFilter
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string? token = context.HttpContext.Request.Headers[HeaderParameters.USER_AUTH_TOKEN_KEY];
            if (string.IsNullOrEmpty(token))
            {
                token = StringHelper.GetGuid();
            }
            context.HttpContext.Response.Headers.Add(HeaderParameters.USER_AUTH_TOKEN_KEY, token);
        }

        /// <summary>
        /// 执行过程中
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {           
             
            UserTokenDTO userToken = null;
            if(userToken == null || userToken.UserId == 0)
            {
                throw new ServiceException { ErrorMessage = "登录信息已失效，请重新登录系统！", ErrorCode = RequestResultCodeEnum.NotAllowAnonymous };
            }
             
        }
    }

}
