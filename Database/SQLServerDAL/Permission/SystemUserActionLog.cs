using MicroShop.Database.IDAL.Permission;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using MicroShop.Common.Model.VO.Web;
using System.Collections.Generic;

namespace MicroShop.Database.SQLServerDAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserActionLog : ISystemUserActionLog
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PageResultVO<SystemUserActionLogVO> GetPageResult(SystemUserActionPageReqDTO req)
        {
            PageResultVO<SystemUserActionLogVO> pageResult = new PageResultVO<SystemUserActionLogVO>
            {
                PageIndex = req.PageIndex,
                PageSize = req.PageSize,
                Data = new List<SystemUserActionLogVO>(),
                RecordCount = 0
            };

            using (var context = new MicroShopContext())
            {
                var query = context.SystemUserActionLogs.Where(x => x.LogId > 0);

                if (!string.IsNullOrEmpty(req.UserName))
                {
                    query = query.Where(x => x.UserName.Contains(req.UserName.Trim()));
                }

                if (!string.IsNullOrEmpty(req.Keyword))
                {
                    query = query.Where(x => x.OperateContent.Contains(req.Keyword.Trim()) || x.UserAgent.Contains(req.Keyword.Trim()));
                }

                if (!string.IsNullOrEmpty(req.RemoteIp))
                {
                    query = query.Where(x => x.RemoteIp.Contains(req.RemoteIp.Trim()));
                }

                if (req.ActionType.HasValue)
                {
                    query = query.Where(x => x.ActionType == req.ActionType.Value);
                }

                if (!DateTime.TryParse(req.StartDate, out DateTime startDate))
                {
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                }

                if (!DateTime.TryParse(req.EndDate, out DateTime endDate))
                {
                    endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                }

                pageResult.RecordCount = query.LongCount();

                pageResult.Data.AddRange(query.OrderByDescending(x => x.LogId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => new SystemUserActionLogVO { ActionType = entity.ActionType, AccessToken = entity.AccessToken, CreatedAt = entity.CreatedAt, LogId = entity.LogId, OperateContent = entity.OperateContent, RemoteIp = entity.RemoteIp, UserAgent = entity.UserAgent, UserId = entity.UserId, UserName = entity.UserName }).ToList());

            }

            return pageResult;
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="vo"></param>
        public void Save(SystemUserActionLogVO vo)
        {
            using (var context = new MicroShopContext())
            {
                SystemUserActionLog entity = new SystemUserActionLog
                {
                    UserId = vo.UserId,
                    UserName = vo.UserName,
                    AccessToken = vo.AccessToken,
                    RemoteIp = vo.RemoteIp,
                    ActionType = vo.ActionType,
                    RequestUrl = vo.RequestUrl,
                    OperateContent = vo.OperateContent,
                    UserAgent = vo.UserAgent,
                    CreatedAt = DateTime.Now
                };
                context.SystemUserActionLogs.Add(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="logIds"></param>       
        public void BatchDelete(List<long> logIds)
        {
            if (logIds != null && logIds.Count > 0)
            {
                using (var context = new MicroShopContext())
                {
                    context.SystemUserActionLogs.Where(x => logIds.Contains(x.LogId)).DeleteFromQuery();
                }
            }
        }

    }
}
