using System.ComponentModel;
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
        public ApiResultDTO<RoleDTO> GetRole([FromRoute] int roleId)
        {
            return new ApiResultDTO<RoleDTO>() { Result = BRole.GetInstance().GetRole(roleId), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="createRole">创建角色的请求</param>
        /// <returns>RoleDTO</returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("create")]
        public ApiResultDTO<RoleDTO> CreateRole([FromBody] CreateRoleDTO createRole)
        {
            return new ApiResultDTO<RoleDTO> { Result = BRole.GetInstance().CreateRole(createRole), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="modifyRole">修改角色的请求</param>
        /// <returns>RoleDTO</returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("modify")]
        public ApiResultDTO<string> ModifyRole([FromBody] ModifyRoleDTO modifyRole)
        {
            BRole.GetInstance().ModifyRole(modifyRole);
            return ApiResultDTO<string>.Success("");
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpGet("delete/{roleId}")]
        public ApiResultDTO<string> DeleteRole([FromRoute] int roleId)
        {
            BRole.GetInstance().DeleteRole(roleId);
            return ApiResultDTO<string>.Success("");
        }

        /// <summary>
        /// 获取分页记录
        /// </summary>
        /// <param name="queryRole">查询分页内容</param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("page")]
        public ApiResultDTO<PageResultDTO<RoleDTO>> GetPageRoles([FromBody] QueryRoleDTO queryRole)
        {
            return new ApiResultDTO<PageResultDTO<RoleDTO>> { Result = BRole.GetInstance().GetPageResult(queryRole), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>List</returns>        
        [HttpGet("list")]
        public ApiResultDTO<List<RoleDTO>> GetRoles()
        {
            return new ApiResultDTO<List<RoleDTO>> { Result = BRole.GetInstance().GetRoles(), ResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleMenuRelation"></param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("set-menus")]
        public ApiResultDTO<string> SetRoleMenuRelation([FromBody] RoleMenuRelationDTO roleMenuRelation)
        {
            BRoleMenuRelation.GetInstance().SetRoleMenuRelation(roleMenuRelation);
            return ApiResultDTO<string>.Success("设置成功");
        }
    }
}
