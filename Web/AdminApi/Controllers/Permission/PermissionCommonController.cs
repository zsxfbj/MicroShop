using Lazy.Captcha.Core;
using MicroShop.BLL.Common;
using MicroShop.Enums.Web;
using MicroShop.Model.VO.Common;
using MicroShop.Model.VO.Web;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Permission
{
    /// <summary>
    /// 通用接口系统人员相关设置
    /// </summary>
    [Route("permission/common")]
    [ApiController]
    public class PermissionCommonController
    {
        private readonly ICaptcha _captcha;

        /// <summary>
        /// 构造函数
        /// </summary>      
        /// <param name="captcha"></param>
        public PermissionCommonController(ICaptcha captcha)
        {
            _captcha = captcha;
        }

        /// <summary>
        /// 获取系统用户的登录状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("login-status")]
        public ApiResultVO<List<KeyValueVO<int>>> GetLoginStatus()
        {
            return new ApiResultVO<List<KeyValueVO<int>>> { Result = BEnum.GetInstance().GetLoginStatusList(), ResultCode = RequestResultCodeEnum.Success };

        }

        /// <summary>
        /// 获取系统用户的操作类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("action-type")]
        public ApiResultVO<List<KeyValueVO<Int32>>> GetActionTypes()
        {
           
            return new ApiResultVO<List<KeyValueVO<Int32>>> { Result = BEnum.GetInstance().GetSystemUserActionTypeList(), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 生成图形验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("verfify-code")]
        public IActionResult Captcha()
        {
            string accessToken = Utility.Common.HttpContext.GetHeaderValue(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY);
            CaptchaData info = _captcha.Generate(accessToken);
            Utility.Common.HttpContext.Current.Response.Headers.Add(HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY, accessToken);
            return new FileContentResult(info.Bytes, "image/gif");
        }
    }
}
