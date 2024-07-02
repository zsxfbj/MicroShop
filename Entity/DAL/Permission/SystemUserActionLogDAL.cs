using MicroShop.IDAL.Permission;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.SQLServerDAL.Entity;
using MicroShop.SQLServerDAL.Entity.Permission;

namespace MicroShop.SQLServerDAL.DAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserActionLogDAL : ISystemUserActionLog
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
                PageIndex = req.PageIndex.HasValue ? req.PageIndex.Value : 1,
                PageSize = req.PageSize.HasValue ? req.PageSize.Value : 10,
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
        /// 批量入库
        /// </summary>
        /// <param name="logs"></param>
        public void BatchInsert(List<SystemUserActionLogVO> logs)
        {
            List<SystemUserActionLog> entities = new List<SystemUserActionLog> ();
            foreach(SystemUserActionLogVO vo in logs) 
            {
                SystemUserActionLog entity = new SystemUserActionLog();
                entity.UserId = vo.UserId;
                entity.UserName = vo.UserName;
                entity.AccessToken = vo.AccessToken;
                entity.RemoteIp = vo.RemoteIp;
                entity.ActionType = vo.ActionType;
                
                entities.Add(entity);
            }

            using(var context = new MicroShopContext())
            {
                context.SystemUserActionLogs.AddRange(entities);
                context.BulkSaveChanges();
            }          
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="logIds"></param>       
        public void BatchDelete(List<long> logIds)
        {
            if(logIds != null && logIds.Count > 0)
            {
                using (var context = new MicroShopContext())
                {
                    context.SystemUserActionLogs.Where(x => logIds.Contains(x.LogId)).DeleteFromQuery();    
                }
            }            
        }
 
    }
}
