using MicroShop.Permission.Entity;
using MicroShop.Permission.Enums;
using MicroShop.Permission.Model;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;
using MicroShop.Web.Common.SystemUser;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 系统用户操作记录逻辑类
    /// </summary>
    public class BSystemUserActionLog : Singleton<BSystemUserActionLog>
    {
        #region public async void Save(SystemUserTokenDTO systemUserToken, ActionTypeEnum actionType, string operateContent)
        /// <summary>
        /// 保存系统用户操作日志
        /// </summary>
        /// <param name="saveSystemUserActionLog"></param>
        public async void Save(SystemUserTokenDTO systemUserToken, ActionTypeEnum actionType, string operateContent)
        {
            SystemUserActionLogEntity systemUserActionLog = new SystemUserActionLogEntity
            {
                AccessToken = systemUserToken.AccessToken,
                ActionType = actionType,
                CreatedAt = DateTime.Now,
                OperateContent = operateContent,
                RemoteIp = HttpContext.GetClientIp(),
                UserAgent = HttpContext.GetUserAgent(),
                UserId = systemUserToken.UserId,
                UserName = systemUserToken.UserName,
                ClientType = systemUserToken.ClientType
            };

            using (var context = new Entity.PermissionContext())
            {
                context.SystemUserActionLogs.Add(systemUserActionLog);
                await context.SaveChangesAsync();
            }
        }
        #endregion public async void Save(SystemUserTokenDTO systemUserToken, ActionTypeEnum actionType, string operateContent)

        #region public PageResultDTO<SystemUserActionLogDTO> GetPagedSystemUserActions(QuerySystemUserActionDTO querySystemUserAction)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="querySystemUserAction"></param>
        /// <returns></returns>
        public PageResultDTO<SystemUserActionLogDTO> GetPagedSystemUserActions(QuerySystemUserActionDTO querySystemUserAction)
        {
            if (querySystemUserAction == null)
            {
                querySystemUserAction = new QuerySystemUserActionDTO { PageIndex = 1, PageSize = 10 };
            }

            querySystemUserAction.InitData();


            PageResultDTO<SystemUserActionLogDTO> pageResult = new PageResultDTO<SystemUserActionLogDTO>
            {
                PageIndex = querySystemUserAction.PageIndex.HasValue ? querySystemUserAction.PageIndex.Value : 1,
                PageSize = querySystemUserAction.PageSize.HasValue ? querySystemUserAction.PageSize.Value : 10,
                Data = new List<SystemUserActionLogDTO>(),
                RecordCount = 0
            };

            using var context = new PermissionContext();
            var query = context.SystemUserActionLogs.Where(x => x.LogId > 0);

            if (!string.IsNullOrEmpty(querySystemUserAction.UserName))
            {
                query = query.Where(x => x.UserName.Contains(querySystemUserAction.UserName.Trim()));
            }

            if (!string.IsNullOrEmpty(querySystemUserAction.Keyword))
            {
                query = query.Where(x => x.OperateContent.Contains(querySystemUserAction.Keyword.Trim()) || x.UserAgent.Contains(querySystemUserAction.Keyword.Trim()));
            }

            if (!string.IsNullOrEmpty(querySystemUserAction.RemoteIp))
            {
                query = query.Where(x => x.RemoteIp.Contains(querySystemUserAction.RemoteIp.Trim()));
            }

            if (querySystemUserAction.ActionType.HasValue)
            {
                query = query.Where(x => x.ActionType == querySystemUserAction.ActionType.Value);
            }

            if (!DateTime.TryParse(querySystemUserAction.StartDate, out DateTime startDate))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            }

            if (!DateTime.TryParse(querySystemUserAction.EndDate, out DateTime endDate))
            {
                endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            }

            pageResult.RecordCount = query.LongCount();

            pageResult.Data.AddRange(query.OrderByDescending(x => x.LogId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => new SystemUserActionLogDTO { ActionType = entity.ActionType, AccessToken = entity.AccessToken, CreatedAt = entity.CreatedAt, LogId = entity.LogId, OperateContent = entity.OperateContent, RemoteIp = entity.RemoteIp, UserAgent = entity.UserAgent, UserId = entity.UserId, UserName = entity.UserName }).ToList());

            return pageResult;
        }
        #endregion public PageResultDTO<SystemUserActionLogDTO> GetPagedSystemUserActions(QuerySystemUserActionDTO querySystemUserAction)

        #region public void Delete(long logId)
        /// <summary>
        /// 删除单个日志
        /// </summary>
        /// <param name="logId">日志编号</param>
        public void Delete(long logId)
        {
            using (var context = new PermissionContext())
            {
                SystemUserActionLogEntity? systemUserActionLog = context.SystemUserActionLogs.FirstOrDefault(x => x.LogId == logId);
                if (systemUserActionLog != null)
                {
                    context.SystemUserActionLogs.Remove(systemUserActionLog);
                    context.SaveChangesAsync();
                }
            }
        }
        #endregion public void Delete(long logId)

        #region public void Delete(BatchDeleteSystemUserActionLogsDTO batchDeleteSystemUserActionLogs)
        /// <summary>
        /// 根据日志编号组批量删除
        /// </summary>
        /// <param name="batchDeleteSystemUserActionLogs">批量结构</param>
        public void Delete(BatchDeleteSystemUserActionLogsDTO batchDeleteSystemUserActionLogs)
        {
            if (batchDeleteSystemUserActionLogs != null && batchDeleteSystemUserActionLogs.LogIds != null && batchDeleteSystemUserActionLogs.LogIds.Any())
            {
                using (var context = new PermissionContext())
                {
                    List<SystemUserActionLogEntity> systemUserActionLogs = context.SystemUserActionLogs.Where(x => batchDeleteSystemUserActionLogs.LogIds.Contains(x.LogId)).ToList();
                    if (systemUserActionLogs.Any())
                    {
                        context.SystemUserActionLogs.RemoveRange(systemUserActionLogs);
                        context.SaveChanges();
                    }
                }
            }
        }
        #endregion public void Delete(BatchDeleteSystemUserActionLogsDTO batchDeleteSystemUserActionLogs)

        #region public void DeleteAll()
        /// <summary>
        /// 删除全部记录
        /// </summary>
        public void DeleteAll()
        {
            using (var context = new PermissionContext())
            {
                context.SystemUserActionLogs.Where(x => x.LogId > 0).DeleteFromQuery();
                context.SaveChangesAsync();
            }
        }
        #endregion public void DeleteAll()
    }
}