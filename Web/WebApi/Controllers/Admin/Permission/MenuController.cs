﻿using MicroShop.BLL.Permission;
using MicroShop.Enum.Web;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.WebApi.Filter;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebApi.Controllers.Admin.Permission
{
    /// <summary>
    /// 系统运营平台菜单API
    /// </summary>
    [Route("admin/permission/menu")]
    [ApiController]
    public class MenuController
    {
        /// <summary>
        /// 获取菜单详情
        /// </summary>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        [HttpGet("detail/{menuId}")]
        public ApiResultVO<MenuVO> GetMenu([FromRoute] int menuId)
        {
            return new ApiResultVO<MenuVO> { Result = BMenu.GetMenu(menuId), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 获取一级菜单列表
        /// </summary>    
        /// <returns></returns>
        [HttpGet("list")]
        public ApiResultVO<List<MenuVO>> GetMenus()
        {
            return new ApiResultVO<List<MenuVO>> { Result = BMenu.GetMenus(0), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="parentId">上级编号</param>
        /// <returns></returns>
        [HttpGet("list/{parentId}")]
        public ApiResultVO<List<MenuVO>> GetMenus([FromRoute] int parentId)
        {
            return new ApiResultVO<List<MenuVO>> { Result = BMenu.GetMenus(parentId), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        [HttpGet("delete/{menuId}")]
        [SysLoginAuth(IsAdmin = true)]
        public ApiResultVO<string> Delete([FromRoute] int menuId)
        {
            BMenu.Delete(menuId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 创建菜单信息
        /// </summary>
        /// <param name="req">创建菜单数据内容</param>
        /// <returns></returns>
        [HttpPost("create")]
        [SysLoginAuth(IsAdmin = true)]
        public ApiResultVO<MenuVO> Create([FromBody] CreateMenuReqDTO req)
        {
            return new ApiResultVO<MenuVO> { Result = BMenu.Create(req), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("modify")]
        [SysLoginAuth(IsAdmin = true)]
        public ApiResultVO<string> Modify([FromBody] ModifyMenuReqDTO req)
        {
            BMenu.Modify(req);
            return ApiResultVO<string>.Success("请求成功");
        }
    }
}
