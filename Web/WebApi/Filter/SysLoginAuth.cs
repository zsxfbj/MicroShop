using MicroShop.BLL.Auth;
using MicroShop.BLL.Permission;
using MicroShop.Enums.Permission;
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
        public string Permission { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        public ActionTypeEnum ActionType { get; set; } = ActionTypeEnum.View;

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
            SystemUserTokenDTO systemUserToken = BSystemUserAuth.GetSystemUserToken(context.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY]);
            BSystemUserActionLog.SaveAction(systemUserToken, ActionType);
            //判断是否登录
            if (systemUserToken.UserId == 0)
            {
                throw new ServiceException { ErrorMessage = "登录信息已失效，请重新登录系统！", ErrorCode = RequestResultCodeEnum.NotAllowAnonymous };
            }

            if(IsAdmin && systemUserToken.IsAdmin == false)
            {
                throw new ServiceException { ErrorMessage = "您无权访问该菜单！", ErrorCode = RequestResultCodeEnum.NotAllowAccess };
            }

            //判断菜单权限
            if (!BRoleMenuRelation.HasPermission(systemUserToken.RoleId, Permission))
            {
                throw new ServiceException { ErrorMessage = "您无权访问该菜单！", ErrorCode = RequestResultCodeEnum.NotAllowAccess };
            }
        }
    }

}
