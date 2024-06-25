using MicroShop.IDAL.Permission;
using MicroShop.Model.Permission;
using MicroShop.SQLServerDAL.Entity;

namespace MicroShop.SQLServerDAL.DAL.Permission
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
        /// <exception cref="NotImplementedException"></exception>
        public List<RoleMenuDTO> GetRoleMenus(int roleId = 0)
        {
            List<RoleMenuDTO> roleMenus = new List<RoleMenuDTO>();
            using (var context = new MicroShopContext())
            {
                if (roleId <= 0)
                {
                    roleMenus = GetMenus(0, context);
                    if (roleMenus.Count > 0)
                    {
                        foreach (var root in roleMenus)
                        {
                            List<RoleMenuDTO> subMeus = GetMenus(root.MenuId, context);
                            if (subMeus.Count > 0)
                            {
                                root.SubMenus = subMeus;
                            }
                        }
                    }
                }
                else
                {
                    roleMenus = GetMenus(roleId, 0, context);
                    if (roleMenus.Count > 0)
                    {
                        foreach (var root in roleMenus)
                        {
                            List<RoleMenuDTO> subMeus = GetMenus(roleId, root.MenuId, context);
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
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool IsExist(int roleId, int menuId)
        {
            using (var context = new MicroShopContext())
            {
                return context.RoleMenuRelations.Count(x => x.RoleId == roleId && x.MenuId == menuId) > 0;
            }
        }

        public void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation)
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
        private static List<RoleMenuDTO> GetMenus(int parentId, MicroShopContext context)
        {
            return (from m in context.Menus
                    where m.ParentId == parentId
                    orderby m.OrderValue ascending
                    select new RoleMenuDTO
                    {
                        MenuId = m.MenuId,
                        MenuName = m.MenuName,
                        ParentId = m.ParentId,
                        SubMenus = new List<RoleMenuDTO>()
                    }).ToList();
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
        private static List<RoleMenuDTO> GetMenus(int roleId, int parentId, MicroShopContext context)
        {
            return (from m in context.Menus
                    join rm in context.RoleMenuRelations on m.MenuId equals rm.MenuId
                    where rm.RoleId == roleId && m.ParentId == parentId
                    orderby m.OrderValue ascending
                    select new RoleMenuDTO
                    {
                        MenuId = m.MenuId,
                        MenuName = m.MenuName,
                        ParentId = m.ParentId,
                        SubMenus = new List<RoleMenuDTO>()
                    }).ToList();
        }
        #endregion private static List<RoleMenuDTO> GetMenus(int roleId, int parentId, MicroShopContext context)       

    }
}
