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
    /// 系统用户登录效验
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class SysLoginAuth : Attribute, IActionFilter
    {
        /// <summary>
        /// 系统菜单编号
        /// </summary>
        public int MenuId { get; set; } = 0;

        /// <summary>
        /// 是否必须管理员
        /// </summary>
        public bool IsAdmin { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>  
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string? token = context.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY];
            if (string.IsNullOrEmpty(token))
            {
                token = StringHelper.GetGuid();
            }
            context.HttpContext.Response.Headers.Add(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY, token);
        }

        /// <summary>
        /// 执行过程中
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            SystemUserTokenDTO systemUserToken = BSystemUserAuth.GetInstance().GetSystemUserToken(context.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY]);
            //判断是否登录
            if (systemUserToken.UserId == 0)
            {
                throw new ServiceException { ErrorMessage = "登录信息已失效，请重新登录系统！", ErrorCode = RequestResultCodeEnum.NotAllowAnonymous };
            }

            //判断菜单权限
            if (MenuId > 0)
            {
                if (!BRoleMenuRelation.GetInstance().IsExist(systemUserToken.RoleId, MenuId))
                {
                    throw new ServiceException { ErrorMessage = "无权访问页面！", ErrorCode = RequestResultCodeEnum.NotAllowAccess };
                }
            }
        }
    }

}
