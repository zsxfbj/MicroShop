using System.ComponentModel;
using MicroShop.Permission.BLL;
using MicroShop.Permission.Model.Request;
using MicroShop.Permission.Model.Response;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Web.AdminApi.Controllers.Permission
{
    /// <summary>
    /// 角色接口
    /// </summary>
    [Route("permission/role")]
    [ApiController]
    public class RoleController
    {
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns>RoleDTO</returns>
        [HttpGet("detail/{roleId}")]
        public ApiResultDTO<RoleDTO> GetRole([FromRoute][DefaultValue("10")] int roleId)
        {
            return new ApiResultDTO<RoleDTO>() { Result = BRole.GetInstance().GetRole(roleId), RequestResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="createRole">创建角色的请求</param>
        /// <returns>RoleDTO</returns>
        [HttpPost("create")]
        public ApiResultDTO<RoleDTO> CreateRole([FromBody] CreateRoleDTO createRole)
        {
            return new ApiResultDTO<RoleDTO> { Result = BRole.GetInstance().CreateRole(createRole), RequestResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="modifyRole">修改角色的请求</param>
        /// <returns>RoleDTO</returns>
        [HttpPost("modify")]
        public ApiResultDTO<string> ModifyRole([FromBody] ModifyRoleDTO modifyRole)
        {
            BRole.GetInstance().ModifyRole(modifyRole);
            return new ApiResultDTO<string>();
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        [HttpGet("delete/{roleId}")]
        public ApiResultDTO<string> DeleteRole([FromRoute][DefaultValue("10")] int roleId)
        {
            BRole.GetInstance().DeleteRole(roleId);
            return new ApiResultDTO<string>();
        }

        /// <summary>
        /// 获取分页记录
        /// </summary>
        /// <param name="queryRole">查询分页内容</param>
        /// <returns></returns>
        [HttpPost("page")]
        public ApiResultDTO<PageResultDTO<RoleDTO>> GetPageRoles([FromBody] QueryRoleDTO queryRole)
        {
            return new ApiResultDTO<PageResultDTO<RoleDTO>> { Result = BRole.GetInstance().GetPageResult(queryRole), RequestResultCode = RequestResultCodeEnum.Success };
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>List</returns>
        [HttpGet("list")]
        public ApiResultDTO<List<RoleDTO>> GetRoles()
        {
            return new ApiResultDTO<List<RoleDTO>> { Result = BRole.GetInstance().GetRoles(), RequestResultCode = RequestResultCodeEnum.Success };
        }
    }
}
