﻿using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;

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
        PageResultVO<SystemUserActionLogVO> GetPageResult(SystemUserActionPageReqDTO req);
    }
}
