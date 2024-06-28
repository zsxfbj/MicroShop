using Lazy.Captcha.Core;
using MicroShop.Enums.Web;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Permission.BLL;
using MicroShop.Permission.Model;
using MicroShop.Web.AdminApi.Filter;
using MicroShop.Web.Common; 
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Permission
{
    /// <summary>
    /// 系统用户相关接口
    /// </summary>
    [Route("permission/system-user")]
    [ApiController]
    public class PermissionSystemUserController
    {
        /// <summary>
        /// 创建系统用户
        /// </summary>
        /// <param name="createSystemUser"></param>
        /// <returns></returns>
        [LoginAuth]
        [HttpPost("create")]
        public ApiResultVO<SystemUserDTO> Create([FromBody] CreateSystemUserDTO createSystemUser)
        {
            return new ApiResultVO<SystemUserDTO> { Result = BSystemUser.GetInstance().Create(createSystemUser), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 修改系统用户信息
        /// </summary>
        /// <param name="modifySystemUser"></param>
        /// <returns></returns>
        [LoginAuth]
        [HttpPost("modify")]
        public ApiResultVO<SystemUserVO> Modify([FromBody] ModifySystemUserDTO modifySystemUser)
        {
            return new ApiResultVO<SystemUserVO> { Result = BSystemUser.GetInstance().Modify(modifySystemUser), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取系统用户详情
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        [LoginAuth]
        [HttpGet("detail/{userId}")]
        public ApiResultVO<SystemUserVO> GetSystemUser([FromRoute] int userId)
        {
            return new ApiResultVO<SystemUserVO> { Result = BSystemUser.GetInstance().GetSystemUserDTO(userId), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpGet("delete/{userId}")]
        public ApiResultVO<string> Delete([FromRoute] int userId)
        {
            BSystemUser.GetInstance().Delete(userId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 设置用户登录状态
        /// 允许登录变禁止登录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpGet("login-status/{userId}")]
        public ApiResultVO<string> SetLoginStatus([FromRoute] int userId)
        {
            BSystemUser.GetInstance().SetLoginStatus(userId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="querySystemUser"></param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("page")]
        public ApiResultVO<PageResultVO<SystemUserVO>> GetPagedSystemUsers([FromBody] QuerySystemUserDTO querySystemUser)
        {
            return new ApiResultVO<PageResultVO<SystemUserVO>> { Result = BSystemUser.GetInstance().GetPagedSystemUsers(querySystemUser), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <param name="systemUserLogin"></param>
        /// <returns>SystemUserLoginResultDTO</returns>
        [HttpPost("login")]
        public ApiResultVO<SystemUserLoginResultDTO> Login([FromBody] SystemUserLoginDTO systemUserLogin)
        {
            if(systemUserLogin == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "登录请求内容不能为空" };
            }
            if (string.IsNullOrEmpty(systemUserLogin.VerifyCode))
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "图形验证码必须填写"};
            }
            if(!_captcha.Validate(Utility.Common.HttpContext.GetHeaderValue(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY), systemUserLogin.VerifyCode))
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "验证码填写错误" };
            }

            return new ApiResultVO<SystemUserLoginResultDTO>() { Result = BSystemUser.GetInstance().Login(systemUserLogin), ResultCode = RequestResultCodeEnum.Success };
        }

        




    }
}
