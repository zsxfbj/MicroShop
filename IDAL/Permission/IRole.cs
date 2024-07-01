
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;

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
        RoleVO GetRole(int roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        RoleVO Create(CreateRoleReqDTO req);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        RoleVO Modify(ModifyRoleReqDTO req);

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
        PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<RoleVO> GetRoles();
    }
}
