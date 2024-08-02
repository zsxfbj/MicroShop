using MicroShop.BLL.Permission;
using MicroShop.Enum.Web;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.WebApi.Filter;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebApi.Controllers.Admin.Permission
{
    /// <summary>
    /// 运营平台角色API
    /// </summary>
    [Route("admin/permission/role")]
    [ApiController]
    public class RoleController
    {
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns>RoleVO</returns>
        //[SysLoginAuth]
        [HttpGet("detail/{roleId}")]
        public ApiResultVO<RoleVO> GetRole([FromRoute] int roleId)
        {
            return new ApiResultVO<RoleVO>() { Result = BRole.GetRole(roleId), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="req">创建角色的请求</param>
        /// <returns>RoleVO</returns>
        //[SysLoginAuth(IsAdmin = true)]
        [HttpPost("create")]
        public ApiResultVO<RoleVO> CreateRole([FromBody] CreateRoleReqDTO req)
        {
            return new ApiResultVO<RoleVO> { Result = BRole.Create(req), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="req">修改角色的请求</param>
        /// <returns>RoleVO</returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpPost("modify")]
        public ApiResultVO<string> ModifyRole([FromBody] ModifyRoleReqDTO req)
        {
            BRole.Modify(req);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpGet("delete/{roleId}")]
        public ApiResultVO<string> Delete([FromRoute] int roleId)
        {
            BRole.Delete(roleId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 获取分页记录
        /// </summary>
        /// <param name="req">查询分页内容</param>
        /// <returns></returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpPost("page")]
        public ApiResultVO<PageResultVO<RoleVO>> GetPageRoles([FromBody] RolePageReqDTO req)
        {
            return new ApiResultVO<PageResultVO<RoleVO>> { Result = BRole.GetPageResult(req), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>List</returns>        
        [HttpGet("list")]
        public ApiResultVO<List<RoleVO>> GetRoles()
        {
            return new ApiResultVO<List<RoleVO>> { Result = BRole.GetRoles(), ResultCode = RequestResultCodes.Success };
        }

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpPost("set-menus")]
        public ApiResultVO<string> SetRoleMenuRelation([FromBody] SetRoleMenuRelationReqDTO req)
        {
            BRoleMenuRelation.SetRoleMenuRelation(req);
            return ApiResultVO<string>.Success("设置成功");
        }
    }
}
