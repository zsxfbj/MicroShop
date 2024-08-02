using MicroShop.BLL.Permission;
using MicroShop.Enum.Web;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.WebApi.Filter;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebApi.Controllers.Admin.Permission
{
    /// <summary>
    /// 系统用户相关接口
    /// </summary>
    [Route("admin/permission/system-user")]
    [ApiController]
    public class SystemUserController
    {
        /// <summary>
        /// 创建系统用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        //[SysLoginAuth]
        [HttpPost("create")]
        public ApiResultVO<SystemUserVO> Create([FromBody] CreateSystemUserReqDTO req)
        {
            return new ApiResultVO<SystemUserVO> { Result = BSystemUser.Create(req), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 修改系统用户信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [SysLoginAuth]
        [HttpPost("modify")]
        public ApiResultVO<SystemUserVO> Modify([FromBody] ModifySystemUserReqDTO req)
        {
            return new ApiResultVO<SystemUserVO> { Result = BSystemUser.Modify(req), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 获取系统用户详情
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        //[SysLoginAuth]
        [HttpGet("detail/{userId}")]
        public ApiResultVO<SystemUserVO> GetSystemUser([FromRoute] int userId)
        {
            return new ApiResultVO<SystemUserVO> { Result = BSystemUser.GetSystemUser(userId), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpGet("delete/{userId}")]
        public ApiResultVO<string> Delete([FromRoute] int userId)
        {
            BSystemUser.Delete(userId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 设置用户登录状态
        /// 允许登录变禁止登录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpGet("login-status/{userId}")]
        public ApiResultVO<string> SetLoginStatus([FromRoute] int userId)
        {
            BSystemUser.SetLoginStatus(userId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpPost("page")]
        public ApiResultVO<PageResultVO<SystemUserVO>> GetPageResult([FromBody] SystemUserPageReqDTO req)
        {
            return new ApiResultVO<PageResultVO<SystemUserVO>> { Result = BSystemUser.GetPageResult(req), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns>SystemUserLoginResultDTO</returns>
        [HttpPost("login")]
        public ApiResultVO<SystemUserLoginResultVO> Login([FromBody] SystemUserLoginReqDTO req)
        {
            if (req == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodes.RequestParameterError, ErrorMessage = "登录请求内容不能为空" };
            }
            if (string.IsNullOrEmpty(req.VerifyCode))
            {
                throw new ServiceException { ErrorCode = RequestResultCodes.RequestParameterError, ErrorMessage = "图形验证码必须填写" };
            }
            //if(!_captcha.Validate(Utility.Common.HttpContext.GetHeaderValue(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY), systemUserLogin.VerifyCode))
            //{
            //    throw new ServiceException { ErrorCode = RequestResultCodes.RequestParameterError, ErrorMessage = "验证码填写错误" };
            //}

            return new ApiResultVO<SystemUserLoginResultVO>() { Result = BSystemUser.Login(req), ResultCode = RequestResultCodes.Success };
        }
    }
}
