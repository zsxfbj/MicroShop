using MicroShop.Permission.BLL;
using MicroShop.Permission.Model.Response;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Permission
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Route("permission/menu")]
    [ApiController]
    public class MenuController
    {
        /// <summary>
        /// 获取菜单详情
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpGet("detail/{menuId}")]
        public ApiResultDTO<MenuDTO> GetMenu([FromRoute] int menuId)
        {
            return new ApiResultDTO<MenuDTO> { Result = BMenu.GetInstance().GetMenuDTO(menuId), RequestResultCode = RequestResultCodeEnum.Success };
        } 
    }
}
