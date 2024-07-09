﻿using MicroShop.IDAL.Permission;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.SQLServerDAL.Entity;

namespace MicroShop.SQLServerDAL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleMenuRelationDAL : IRoleMenuRelation
    {
        /// <summary>
        /// 根据角色Id获取菜单树
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>     
        public List<RoleMenuVO> GetRoleMenus(int roleId, bool showHidden)
        {
            List<RoleMenuVO> roleMenus = new List<RoleMenuVO>();
            using (var context = new MicroShopContext())
            {
                if (roleId <= 0)
                {
                    roleMenus = GetMenus(0, showHidden, context);
                    if (roleMenus.Count > 0)
                    {
                        foreach (var root in roleMenus)
                        {
                            List<RoleMenuVO> subMeus = GetMenus(root.MenuId, showHidden, context);
                            if (subMeus.Count > 0)
                            {
                                root.SubMenus = subMeus;
                            }
                        }
                    }
                }
                else
                {
                    roleMenus = GetMenus(roleId, 0, showHidden, context);
                    if (roleMenus.Count > 0)
                    {
                        foreach (var root in roleMenus)
                        {
                            List<RoleMenuVO> subMeus = GetMenus(roleId, root.MenuId, showHidden, context);
                            if (subMeus.Count > 0)
                            {
                                root.SubMenus = subMeus;
                            }
                        }
                    }
                }
            }
            return roleMenus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool HasPermission(int roleId, string permission)
        {
            using (var context = new MicroShopContext())
            {
                return context.RoleMenuRelations.Count(x => x.RoleId == roleId && x.Permission == permission) > 0;
            }
        }

        public void SetRoleMenuRelation(SetRoleMenuRelationReqDTO roleMenuRelation)
        {

        }

        #region private static List<RoleMenuDTO> GetMenus(int parentId, MicroShopContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="parentId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static List<RoleMenuVO> GetMenus(int parentId, bool showHidden, MicroShopContext context)
        {
            if (showHidden)
            {
                return (from m in context.Menus
                        where m.ParentId == parentId && m.IsDeleted == false
                        orderby m.OrderValue ascending
                        select new RoleMenuVO
                        {
                            MenuId = m.MenuId,
                            MenuName = m.MenuName,
                            ParentId = m.ParentId,
                            SubMenus = new List<RoleMenuVO>()
                        }).ToList();
            }
            else
            {
                return (from m in context.Menus
                        where m.ParentId == parentId && m.Hidden == false && m.IsDeleted == false
                        orderby m.OrderValue ascending
                        select new RoleMenuVO
                        {
                            MenuId = m.MenuId,
                            MenuName = m.MenuName,
                            ParentId = m.ParentId,
                            SubMenus = new List<RoleMenuVO>()
                        }).ToList();
            }
            
        }
        #endregion private static List<RoleMenuDTO> GetMenus(int parentId, MicroShopContext context)

        #region private static List<RoleMenuDTO> GetMenus(int roleId, int parentId, MicroShopContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="parentId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static List<RoleMenuVO> GetMenus(int roleId, int parentId, bool showHidden, MicroShopContext context)
        {
            if (showHidden)
            {
                return (from m in context.Menus
                        join rm in context.RoleMenuRelations on m.MenuId equals rm.MenuId
                        where rm.RoleId == roleId && m.ParentId == parentId && m.IsDeleted == false
                        orderby m.OrderValue ascending
                        select new RoleMenuVO
                        {
                            MenuId = m.MenuId,
                            MenuName = m.MenuName,
                            ParentId = m.ParentId,
                            SubMenus = new List<RoleMenuVO>()
                        }).ToList();
            }
            else
            {
                return (from m in context.Menus
                        join rm in context.RoleMenuRelations on m.MenuId equals rm.MenuId
                        where rm.RoleId == roleId && m.ParentId == parentId && m.Hidden == false && m.IsDeleted == false
                        orderby m.OrderValue ascending
                        select new RoleMenuVO
                        {
                            MenuId = m.MenuId,
                            MenuName = m.MenuName,
                            ParentId = m.ParentId,
                            SubMenus = new List<RoleMenuVO>()
                        }).ToList();
            }
        }
        #endregion private static List<RoleMenuDTO> GetMenus(int roleId, int parentId, MicroShopContext context)       

    }
}
