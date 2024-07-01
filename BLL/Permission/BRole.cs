using MicroShop.BLL.Auth;
using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Auth;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BRole : Singleton<BRole>
    {
        /// <summary>
        /// 获取DAL访问的实例
        /// </summary>
        private readonly static IRole dal = RoleFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public RoleVO Create(CreateRoleReqDTO req)
        {            
            return dal.Create(req); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleVO Modify(ModifyRoleReqDTO req)
        {    
            return dal.Modify(req);
        }

        public void Delete(int roleId)
        {
            dal.Delete(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleVO GetRole(int roleId)
        {
            return dal.GetRole(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        {
            return dal.GetPageResult(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<RoleVO> GetRoles() { return dal.GetRoles(); }
    }
}
