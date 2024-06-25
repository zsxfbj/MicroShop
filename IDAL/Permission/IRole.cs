
using MicroShop.Model.Permission;
using MicroShop.Model.Web;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRole
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        RoleDTO GetRole(int roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        RoleDTO Create(CreateRoleReqDTO req);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        RoleDTO Modify(ModifyRoleReqDTO req);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        void Delete(int roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryRole"></param>
        /// <returns></returns>
        PageResultDTO<RoleDTO> GetPageResult(QueryRoleReqDTO req);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<RoleDTO> GetRoles();
    }
}
