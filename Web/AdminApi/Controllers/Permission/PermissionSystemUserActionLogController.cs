﻿using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Permission.BLL;
using MicroShop.Permission.Model;
using MicroShop.Web.AdminApi.Filter;
using MicroShop.Web.Common;
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
        /// <param name="querySystemUserAction"></param>
        /// <returns></returns>
        [LoginAuth(IsAdmin = true)]
        [HttpPost("page")]
        public ApiResultVO<PageResultVO<SystemUserActionLogVO>> GetPagedSystemUserActions([FromBody]QuerySystemUserActionDTO querySystemUserAction)
        {
            return new ApiResultVO<PageResultVO<SystemUserActionLogVO>>
            {
                Result = BSystemUserActionLog.GetInstance().GetPagedSystemUserActions(querySystemUserAction),
                ResultCode = RequestResultCodeEnum.Success
            };
        }

        /// <summary>
        /// 删除单个日志
        /// </summary>
        /// <param name="logId">日志编号</param>
        /// <returns></returns>
        [HttpGet("delete/{logId}")]
        [LoginAuth(IsAdmin = true)]
        public ApiResultVO<string> DeleteOne([FromRoute] long logId)
        {
            BSystemUserActionLog.GetInstance().Delete(logId);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="batchDeleteSystemUserActionLogs"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        [LoginAuth(IsAdmin = true)]
        public ApiResultVO<string> Delete([FromBody] BatchDeleteSystemUserActionLogsDTO batchDeleteSystemUserActionLogs)
        {
            BSystemUserActionLog.GetInstance().Delete(batchDeleteSystemUserActionLogs);
            return ApiResultVO<string>.Success("");
        }

        /// <summary>
        /// 全部删除
        /// </summary>
        /// <returns></returns>
        [HttpGet("delete/all")]
        [LoginAuth(IsAdmin = true)]
        public ApiResultVO<string> DeleteAll()
        {
            BSystemUserActionLog.GetInstance().DeleteAll();
            return ApiResultVO<string>.Success("");
        }

    }
}
