using System.Collections.Generic;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoleMenuRelation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        bool HasPermission(long roleId, string permission);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleMenuRelation"></param>
        void SetRoleMenuRelation(SetRoleMenuRelationReqDTO roleMenuRelation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<RoleMenuVO> GetRoleMenus(long roleId, bool showHidden);
    }
}
