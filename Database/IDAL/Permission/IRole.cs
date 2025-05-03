using System.Collections.Generic;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using MicroShop.Model.Base;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// Role数据访问接口
    /// </summary>
    public interface IRole
    {
        RoleVO? GetRole(long roleId);

        RoleVO? GetRole(string roleName);

        RoleVO? Create(CreateRoleReqDTO req);

        RoleVO? Modify(ModifyRoleReqDTO req);
 
        int Delete(long roleId);

        PageResult<RoleVO> GetPageResult(RolePageReqDTO req);

        List<RoleVO> GetRoles();
    }
}
