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
    /// 系统用户操作接口
    /// </summary>
    [Route("permission/system-user/action")]
    [ApiController]
    public class PermissionSystemUserActionLogController
    {
        /// <summary>
        /// 分页查询系统用户操作日志
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [SysLoginAuth(IsAdmin = true)]
        [HttpPost("page")]
        public ApiResultVO<PageResultVO<SystemUserActionLogVO>> GetPagedSystemUserActions([FromBody] SystemUserActionPageReqDTO req)
        {
            return new ApiResultVO<PageResultVO<SystemUserActionLogVO>>
            {
                Result = BSystemUserActionLog.GetPageResult(req),
                ResultCode = RequestResultCodeEnum.Success
            };
        }
               
        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        [SysLoginAuth(IsAdmin = true)]
        public ApiResultVO<string> Delete([FromBody] BatchDeleteLogReqDTO req)
        {
            BSystemUserActionLog.BatchDelete(req);
            return ApiResultVO<string>.Success("");
        }
    }
}
