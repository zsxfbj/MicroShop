using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroShop.Web.AdminApi.Filter
{
    /// <summary>
    /// 效验权限
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class LoginAuth : Attribute, IActionFilter
    {
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string? MenuCode { get; set; }

        /// <summary>
        /// 执行完毕
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        /// <summary>
        /// 执行过程中
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
             
        }
    }

}
