using MicroShop.Product.BLL;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Product
{
    /// <summary>
    /// 产品通用接口
    /// </summary>
    [Route("product/common")]
    [ApiController]
    public class ProductCommonController
    {

        /// <summary>
        /// 获取货币类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("currency-types")]
        public ApiResultDTO<Dictionary<Int32, string>> GetCurrencyTypes()
        {
            return new ApiResultDTO<Dictionary<Int32, string>> { Result = BCommon.GetInstance().GetCurrencyTypes(), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取货币类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("media-types")]
        public ApiResultDTO<Dictionary<Int32, string>> GetMediaTypes()
        {
            return new ApiResultDTO<Dictionary<Int32, string>> { Result = BCommon.GetInstance().GetMediaTypes(), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取产品状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("product-status")]
        public ApiResultDTO<Dictionary<Int32, string>> GetProductStatusList()
        {
            return new ApiResultDTO<Dictionary<Int32, string>> { Result = BCommon.GetInstance().GetProductStatusList(), ResultCode = RequestResultCodeEnum.Success };
        }
    }
}
