using Lazy.Captcha.Core;
using MicroShop.Model.Auth;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebApi.Controllers.Admin
{
    /// <summary>
    /// 运营平台相关通用API
    /// </summary>
    [Route("admin/common")]
    [ApiController]
    public class CommonController
    {
        private readonly ICaptcha _captcha;

        /// <summary>
        /// 构造函数
        /// </summary>      
        /// <param name="captcha"></param>
        public CommonController(ICaptcha captcha)
        {
            _captcha = captcha;
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
            return new FileContentResult(info.Bytes, "image/png");
        }
    }
}
