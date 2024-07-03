using MicroShop.BLL.Permission;
using MicroShop.Enums.Web;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Web.AdminApi.Filter;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Permission
{
    /// <summary>
    /// 运营平台角色API
    /// </summary>
    [Route("permission/role")]
    [ApiController]
    public class PermissionRoleController
    {
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns>RoleVO</returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpGet("detail/{roleId}")]
        public ApiResultVO<RoleVO> GetRole([FromRoute] int roleId)
        {
            return new ApiResultVO<RoleVO>() { Result = BRole.GetInstance().GetRole(roleId), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="req">创建角色的请求</param>
        /// <returns>RoleVO</returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpPost("create")]
        public ApiResultVO<RoleVO> CreateRole([FromBody] CreateRoleReqDTO req)
        {
            return new ApiResultVO<RoleVO> { Result = BRole.GetInstance().Create(req), ResultCode = RequestResultCodeEnum.Success };
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
            BRole.GetInstance().Modify(req);
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
            BRole.GetInstance().Delete(roleId);
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
            return new ApiResultVO<PageResultVO<RoleVO>> { Result = BRole.GetInstance().GetPageResult(req), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>List</returns>        
        [HttpGet("list")]
        public ApiResultVO<List<RoleVO>> GetRoles()
        {
            return new ApiResultVO<List<RoleVO>> { Result = BRole.GetInstance().GetRoles(), ResultCode = RequestResultCodeEnum.Success };
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
            BRoleMenuRelation.GetInstance().SetRoleMenuRelation(req);
            return ApiResultVO<string>.Success("设置成功");
        }
    }
}
