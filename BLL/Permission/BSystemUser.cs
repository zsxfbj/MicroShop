using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BSystemUser : Singleton<BSystemUser>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly static ISystemUser dal = SystemUserFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SystemUserVO Create(CreateSystemUserReqDTO req)
        {
            return dal.Create(req);
        }
            

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SystemUserVO Modify(ModifySystemUserReqDTO req) { return dal.Modify(req); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SystemUserVO GetSystemUser(int userId ) { return dal.GetSystemUser(userId); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void Delete(int userId) { dal.Delete(userId); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void SetLoginStatus(int userId)
        {
            dal.SetLoginStatus(userId);
        }

        public PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req)
        {
            return dal.GetPageResult(req);
        }
    }
}
