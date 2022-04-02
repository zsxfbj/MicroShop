using MicroShop.Permission.Enums;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Common
{
    /// <summary>
    /// 通用接口系统人员相关设置
    /// </summary>
    [Route("common/system-user")]
    [ApiController]
    public class UserController
    {
        /// <summary>
        /// 获取系统用户的登录状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("login-status")]
        public ApiResultDTO<List<KeyValueDTO>> GetLoginStatus()
        {
            List<KeyValueDTO> keyValues = new List<KeyValueDTO>();

            foreach(LoginStatusEnum status in Enum.GetValues(typeof(LoginStatusEnum)))
            {
                keyValues.Add(new KeyValueDTO {  Key = ((int)status).ToString(), Value = status.GetDescription() });
            }

            return new ApiResultDTO<List<KeyValueDTO>> { Result = keyValues, RequestResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取系统用户的操作类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("action-type")]
        public ApiResultDTO<List<KeyValueDTO>> GetActionTypes()
        {
            List<KeyValueDTO> keyValues = new List<KeyValueDTO>();
            foreach (ActionTypeEnum actionType in Enum.GetValues(typeof(ActionTypeEnum)))
            {
                keyValues.Add(new KeyValueDTO { Key = ((int)actionType).ToString(), Value = actionType.GetDescription() });
            }
            return new ApiResultDTO<List<KeyValueDTO>> { Result = keyValues, RequestResultCode = RequestResultCodeEnum.Success };
        }
    }
}
