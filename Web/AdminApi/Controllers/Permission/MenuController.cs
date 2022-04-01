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
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        [HttpGet("detail/{menuId}")]
        public ApiResultDTO<MenuDTO> GetMenu([FromRoute] int menuId)
        {
            return new ApiResultDTO<MenuDTO> { Result = BMenu.GetInstance().GetMenuDTO(menuId), RequestResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        [HttpGet("delete/{menuId}")]
        public ApiResultDTO<string> Delete([FromRoute] int menuId)
        {
            BMenu.GetInstance().Delete(menuId);
            return new ApiResultDTO<string>();
        }

        /// <summary>
        /// 创建菜单信息
        /// </summary>
        /// <param name="createMenu">创建菜单数据内容</param>
        /// <returns></returns>
        [HttpPost("create")]
        public ApiResultDTO<MenuDTO> Create([FromBody] MicroShop.Permission.Model.Request.CreateMenuDTO createMenu)
        {
            return new ApiResultDTO<MenuDTO> { Result = BMenu.GetInstance().Create(createMenu), RequestResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="modifyMenu"></param>
        /// <returns></returns>
        [HttpPost("modify")]
        public ApiResultDTO<string> Modify([FromBody] MicroShop.Permission.Model.Request.ModifyMenuDTO modifyMenu)
        {
            BMenu.GetInstance().Modify(modifyMenu);
            return new ApiResultDTO<string>();           
        }
    }
}
