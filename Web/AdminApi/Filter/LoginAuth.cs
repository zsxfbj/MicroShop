using MicroShop.BLL.Auth;
using MicroShop.BLL.Permission;
using MicroShop.Enums.Web;
using MicroShop.Model.Auth;
using MicroShop.Model.Common.Exception;
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
        /// 系统菜单编号
        /// </summary>
        public int? MenuId { get; set; }

        /// <summary>
        /// 是否必须管理员
        /// </summary>
        public bool? IsAdmin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行过程中
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {           
            if(IsAdmin != null && IsAdmin == true)
            {
                SystemUserTokenDTO systemUserToken = BSystemUserAuth.GetInstance().GetSystemUserToken(context.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY]);
                //判断是否登录
                if (systemUserToken.UserId == 0)
                {
                    throw new ServiceException { ErrorMessage = "登录信息已失效，请重新登录系统！", ErrorCode = RequestResultCodeEnum.NotAllowAnonymous };
                }

                //判断菜单权限
                if (MenuId != null && MenuId > 0)
                {
                    if (!BRoleMenuRelation.GetInstance().IsExist(systemUserToken.RoleId, MenuId.Value))
                    {
                        throw new ServiceException { ErrorMessage = "无权访问页面！", ErrorCode = RequestResultCodeEnum.NotAllowAccess };
                    }
                }
            }
            else
            {
                UserTokenDTO userToken = null;
                if(userToken == null || userToken.UserId == 0)
                {
                    throw new ServiceException { ErrorMessage = "登录信息已失效，请重新登录系统！", ErrorCode = RequestResultCodeEnum.NotAllowAnonymous };
                }
            }
        }
    }

}
