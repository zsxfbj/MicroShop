using System.Collections.Generic;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using MicroShop.Model.Base;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISystemUserActionLog
    {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="vo"></param>
        void Save(SystemUserActionLogVO vo);

        /// <summary>
        /// 批量删除日志记录
        /// </summary>
        /// <param name="logIds"></param>
        void BatchDelete(List<long> logIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        PageResult<SystemUserActionLogVO> GetPageResult(SystemUserActionPageReqDTO req);
    }
}
