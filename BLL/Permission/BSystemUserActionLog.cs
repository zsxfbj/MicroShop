using MicroShop.DALFactory.Permission;
using MicroShop.Enums.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Auth;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BSystemUserActionLog
    {
        /// <summary>
        /// 数据访问实例层
        /// </summary>
        private readonly static ISystemUserActionLog dal = SystemUserActionLogFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static PageResultVO<SystemUserActionLogVO> GetPageResult(SystemUserActionPageReqDTO req)
        {
            req.InitData();

            return dal.GetPageResult(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        public static void BatchDelete(BatchDeleteLogReqDTO req)
        {
            if(req.LogIds != null && req.LogIds.Count > 0)
            {
                dal.BatchDelete(req.LogIds);
            }          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemUserToken"></param>
        /// <param name="actionType"></param>
        public static void SaveAction(SystemUserTokenDTO systemUserToken, ActionTypeEnum actionType)
        {
            SystemUserActionLogVO vo = new SystemUserActionLogVO
            {
                UserId = systemUserToken.UserId,
                UserName = systemUserToken.UserName,
                RemoteIp = HttpContext.GetClientIp(),
                AccessToken = systemUserToken.AccessToken,
                ActionType = actionType,
                CreatedAt = DateTime.Now,
                RequestUrl = HttpContext.Current.Request.Path,
                UserAgent = HttpContext.GetUserAgent()
            };

            string httpMethod = HttpContext.Current.Request.Method;

            if (httpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase) || httpMethod.Equals("PUT", StringComparison.OrdinalIgnoreCase)) 
            {
                StreamReader stream = new StreamReader(HttpContext.Current.Request.Body);
                vo.OperateContent = stream.ReadToEndAsync().GetAwaiter().GetResult();              
            }
            else
            {
                vo.OperateContent = HttpContext.Current.Request.QueryString.ToString();
            }

            dal.Save(vo);
        }

    }
}
