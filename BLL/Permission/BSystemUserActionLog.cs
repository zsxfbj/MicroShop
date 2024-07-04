using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BSystemUserActionLog
    {
        private readonly static ISystemUserActionLog dal = SystemUserActionLogFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static PageResultVO<SystemUserActionLogVO> GetPageResult(SystemUserActionPageReqDTO req)
        {
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

    }
}
