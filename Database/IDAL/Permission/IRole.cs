using System.Collections.Generic;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using MicroShop.Common.Model.VO.Web;

namespace MicroShop.Database.IDAL.Permission
{
    /// <summary>
    /// Role数据访问接口
    /// </summary>
    public interface IRole
    {
        RoleVO GetRole(long roleId);

        RoleVO? GetRole(string roleName);

        RoleVO Create(CreateRoleReqDTO req);

        RoleVO Modify(ModifyRoleReqDTO req);
 
        void Delete(long roleId);

        PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req);

        List<RoleVO> GetRoles();
    }
}
