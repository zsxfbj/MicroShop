﻿using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;

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
        void SetRoleMenuRelation(SetRoleMenuRelationReqDTO roleMenuRelation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<RoleMenuVO> GetRoleMenus(int roleId = 0);
    }
}
