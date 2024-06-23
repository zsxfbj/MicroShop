using MicroShop.Permission.BLL;
using MicroShop.Web.Common;
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
        /// 菜单编号
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 是否需要管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginAuth()
        {
            MenuId = 0;
            IsAdmin = false;
        }

        
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
            Common.SystemUser.SystemUserTokenDTO systemUserToken = BSystemUserToken.GetInstance().GetSystemUserToken(context.HttpContext.Request.Headers[HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY]);
            //判断是否登录
            if(systemUserToken.UserId == 0)
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

            //判断是否是管理员
            if(IsAdmin == true && systemUserToken.IsAdmin == false)
            {
                throw new ServiceException { ErrorMessage = "非管理员无权访问！", ErrorCode = RequestResultCodeEnum.NotAllowAccess };
            }
        }
    }

}
