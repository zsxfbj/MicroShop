using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MicroShop.Web.Common.Filter
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthonizationFilter : Attribute, IAsyncAuthorizationFilter
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //这里可以做复杂的权限控制操作
            if (context.HttpContext.User.Identity.Name != "1") //简单的做一个示范
            {
                //未通过验证则跳转到无权限提示页
                RedirectToActionResult content = new RedirectToActionResult("NoAuth", "Exception", null);
                context.Result = content;
            }
        }

        private bool IsAuthorized(ClaimsPrincipal user)
        {
            // Check if the user is authenticated
            // Implement your custom authorization logic here
            // Check roles, claims, policies, or any other criteria
            // Return true if authorized, false if not
            if(user != null)
            {
                //user.Identity.Name = "1";
            }
            return false; // For demonstration purposes
        }
    }
}
