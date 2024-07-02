using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.SQLServerDAL.Entity.Permission;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BSystemUserActionLog : Singleton<BSystemUserActionLog>
    {
        private readonly static ISystemUserActionLog dal = SystemUserActionLogFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PageResultVO<SystemUserActionLogVO> GetPageResult(SystemUserActionPageReqDTO req)
        {
            return dal.GetPageResult(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        public void BatchDelete(BatchDeleteLogReqDTO req)
        {
            if(req.LogIds != null && req.LogIds.Count > 0)
            {
                dal.BatchDelete(req.LogIds);
            }          
        }

    }
}
