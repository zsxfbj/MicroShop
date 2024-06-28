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
        public ApiResultVO<MenuDTO> GetMenu([FromRoute] int menuId)
        {
            return new ApiResultVO<MenuDTO> { Result = BMenu.GetInstance().GetMenuDTO(menuId), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取一级菜单列表
        /// </summary>    
        /// <returns></returns>
        [HttpGet("list")]
        public ApiResultVO<List<MenuDTO>> GetMenus()
        {
            return new ApiResultVO<List<MenuDTO>> { Result = BMenu.GetInstance().GetMenus(0), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="parentId">上级编号</param>
        /// <returns></returns>
        [HttpGet("list/{parentId}")]
        public ApiResultVO<List<MenuDTO>> GetMenus([FromRoute] int parentId)
        {
            return new ApiResultVO<List<MenuDTO>> { Result = BMenu.GetInstance().GetMenus(parentId), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        [HttpGet("delete/{menuId}")]
        public ApiResultVO<string> Delete([FromRoute] int menuId)
        {
            BMenu.GetInstance().Delete(menuId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 创建菜单信息
        /// </summary>
        /// <param name="createMenu">创建菜单数据内容</param>
        /// <returns></returns>
        [HttpPost("create")]
        public ApiResultVO<MenuDTO> Create([FromBody] CreateMenuDTO createMenu)
        {
            return new ApiResultVO<MenuDTO> { Result = BMenu.GetInstance().Create(createMenu), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="modifyMenu"></param>
        /// <returns></returns>
        [HttpPost("modify")]
        [LoginAuth(MenuId = 0, IsAdmin = true)]
        public ApiResultVO<string> Modify([FromBody] ModifyMenuDTO modifyMenu)
        {
            BMenu.GetInstance().Modify(modifyMenu);
            return ApiResultVO<string>.Success("请求成功");
        }
    }
}
