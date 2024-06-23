using MicroShop.Permission.Model;
using MicroShop.Permission.BLL;
using MicroShop.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Permission.WebApi.Controllers
{
    /// <summary>
    /// 角色接口
    /// </summary>
    [Route("role")]
    [ApiController]
    public class RoleController
    {
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("detail/{roleId}")]
        public ApiResultDTO<RoleDTO> GetRole([FromRoute] int roleId)
        {
            return new ApiResultDTO<RoleDTO>() { Result = BRole.GetInstance().GetRole(roleId), ResultCode = RequestResultCodeEnum.Success};
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="createRole"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public ApiResultDTO<RoleDTO> CreateRole([FromBody] CreateRoleDTO createRole)
        {
            return new ApiResultDTO<RoleDTO> { Result = BRole.GetInstance().CreateRole(createRole), ResultCode = RequestResultCodeEnum.Success };
        }
    }
}
