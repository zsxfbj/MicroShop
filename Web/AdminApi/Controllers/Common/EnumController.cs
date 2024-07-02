using MicroShop.BLL.Common;
using MicroShop.Enums.Web;
using MicroShop.Model.VO.Common;
using MicroShop.Model.VO.Web;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebApi.Controllers.Common
{
    /// <summary>
    /// 枚举列表接口
    /// </summary>
    [Route("common/enum")]
    [ApiController]
    public class EnumController
    {
        /// <summary>
        /// 获取用户的登录状态列表
        /// </summary>
        /// <returns>List of KeyValueVO</returns>
        [HttpGet("login-status-list")]
        public ApiResultVO<List<KeyValueVO<int>>> GetLoginStatus()
        {
            return new ApiResultVO<List<KeyValueVO<int>>> { Result = BEnum.GetInstance().GetLoginStatusList(), ResultCode = RequestResultCodeEnum.Success };

        }

        /// <summary>
        /// 获取用户的操作类型列表
        /// </summary>
        /// <returns>List of KeyValueVO</returns>
        [HttpGet("action-type-list")]
        public ApiResultVO<List<KeyValueVO<int>>> GetUserActionTypeList()
        {
            return new ApiResultVO<List<KeyValueVO<int>>> { Result = BEnum.GetInstance().GetUserActionTypeList(), ResultCode = RequestResultCodeEnum.Success };
        }


        /// <summary>
        /// 获取货币类型列表
        /// </summary>
        /// <returns>List of KeyValueVO</returns>
        [HttpGet("currency-type-list")]
        public ApiResultVO<List<KeyValueVO<int>>> GetCurrencyTypes()
        {
            return new ApiResultVO<List<KeyValueVO<int>>> { Result = BEnum.GetInstance().GetCurrencyTypeList(), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取媒体类型列表
        /// </summary>
        /// <returns>List of KeyValueVO</returns>
        [HttpGet("media-type-list")]
        public ApiResultVO<List<KeyValueVO<int>>> GetMediaTypes()
        {
            return new ApiResultVO<List<KeyValueVO<int>>> { Result = BEnum.GetInstance().GetMediaTypeList(), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取产品状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("product-status-list")]
        public ApiResultVO<List<KeyValueVO<int>>> GetProductStatusList()
        {
            return new ApiResultVO<List<KeyValueVO<int>>> { Result = BEnum.GetInstance().GetProductStatusList(), ResultCode = RequestResultCodeEnum.Success };
        }
    }
}
