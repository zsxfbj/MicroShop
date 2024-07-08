
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// Role数据访问接口
    /// </summary>
    public interface IRole
    {
        RoleVO GetRole(int roleId);

        RoleVO? GetRole(string roleName);

        RoleVO Save(RoleDTO role);
 
        void Delete(int roleId);

        PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req);

        List<RoleVO> GetRoles();
    }
}
