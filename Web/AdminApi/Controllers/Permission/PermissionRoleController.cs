using System.ComponentModel;
using MicroShop.Model.VO.Web;
using MicroShop.Permission.BLL;
using MicroShop.Permission.Model;
using MicroShop.Web.AdminApi.Filter;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Permission
{
    /// <summary>
    /// 角色接口
    /// </summary>
    [Route("permission/role")]
    [ApiController]
    public class PermissionRoleController
    {
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns>RoleDTO</returns>
        [LoginAuth(IsAdmin = true)]
        [HttpGet("detail/{roleId}")]
        public ApiResultVO<RoleDTO> GetRole([FromRoute] int roleId)
        {
            return new ApiResultVO<RoleDTO>() { Result = BRole.GetInstance().GetRole(roleId), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="createRole">创建角色的请求</param>
        /// <returns>RoleDTO</returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("create")]
        public ApiResultVO<RoleDTO> CreateRole([FromBody] CreateRoleDTO createRole)
        {
            return new ApiResultVO<RoleDTO> { Result = BRole.GetInstance().CreateRole(createRole), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="modifyRole">修改角色的请求</param>
        /// <returns>RoleDTO</returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("modify")]
        public ApiResultVO<string> ModifyRole([FromBody] ModifyRoleDTO modifyRole)
        {
            BRole.GetInstance().ModifyRole(modifyRole);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpGet("delete/{roleId}")]
        public ApiResultVO<string> DeleteRole([FromRoute] int roleId)
        {
            BRole.GetInstance().DeleteRole(roleId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 获取分页记录
        /// </summary>
        /// <param name="queryRole">查询分页内容</param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("page")]
        public ApiResultVO<PageResultVO<RoleDTO>> GetPageRoles([FromBody] QueryRoleDTO queryRole)
        {
            return new ApiResultVO<PageResultVO<RoleDTO>> { Result = BRole.GetInstance().GetPageResult(queryRole), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>List</returns>        
        [HttpGet("list")]
        public ApiResultVO<List<RoleDTO>> GetRoles()
        {
            return new ApiResultVO<List<RoleDTO>> { Result = BRole.GetInstance().GetRoles(), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleMenuRelation"></param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("set-menus")]
        public ApiResultVO<string> SetRoleMenuRelation([FromBody] RoleMenuRelationDTO roleMenuRelation)
        {
            BRoleMenuRelation.GetInstance().SetRoleMenuRelation(roleMenuRelation);
            return ApiResultVO<string>.Success("设置成功");
        }
    }
}
