﻿using MicroShop.Model.Permission;

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
        bool IsExist(int roleId, int menuId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleMenuRelation"></param>
        void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<RoleMenuDTO> GetRoleMenus(int roleId = 0);
    }
}
