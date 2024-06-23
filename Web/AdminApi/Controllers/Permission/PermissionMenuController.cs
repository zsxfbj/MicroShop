using MicroShop.Permission.BLL;
using MicroShop.Permission.Model;
using MicroShop.Web.AdminApi.Filter;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Permission
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Route("permission/menu")]
    [ApiController]
    public class PermissionMenuController
    {
        /// <summary>
        /// 获取菜单详情
        /// </summary>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        [HttpGet("detail/{menuId}")]
        public ApiResultDTO<MenuDTO> GetMenu([FromRoute] int menuId)
        {
            return new ApiResultDTO<MenuDTO> { Result = BMenu.GetInstance().GetMenuDTO(menuId), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取一级菜单列表
        /// </summary>    
        /// <returns></returns>
        [HttpGet("list")]
        public ApiResultDTO<List<MenuDTO>> GetMenus()
        {
            return new ApiResultDTO<List<MenuDTO>> { Result = BMenu.GetInstance().GetMenus(0), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="parentId">上级编号</param>
        /// <returns></returns>
        [HttpGet("list/{parentId}")]
        public ApiResultDTO<List<MenuDTO>> GetMenus([FromRoute] int parentId)
        {
            return new ApiResultDTO<List<MenuDTO>> { Result = BMenu.GetInstance().GetMenus(parentId), ResultCode = RequestResultCodeEnum.Success };
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
            return ApiResultDTO<string>.Success("");
        }

        /// <summary>
        /// 创建菜单信息
        /// </summary>
        /// <param name="createMenu">创建菜单数据内容</param>
        /// <returns></returns>
        [HttpPost("create")]
        public ApiResultDTO<MenuDTO> Create([FromBody] CreateMenuDTO createMenu)
        {
            return new ApiResultDTO<MenuDTO> { Result = BMenu.GetInstance().Create(createMenu), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="modifyMenu"></param>
        /// <returns></returns>
        [HttpPost("modify")]
        [LoginAuth(MenuId = 0, IsAdmin = true)]
        public ApiResultDTO<string> Modify([FromBody] ModifyMenuDTO modifyMenu)
        {
            BMenu.GetInstance().Modify(modifyMenu);
            return ApiResultDTO<string>.Success("请求成功");
        }
    }
}
