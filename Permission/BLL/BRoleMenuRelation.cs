using MicroShop.Permission.Entity;
using MicroShop.Permission.Model;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 角色菜单关系
    /// </summary>
    public class BRoleMenuRelation : Singleton<BRoleMenuRelation>
    {      
        #region public bool IsExist(int roleId, int menuId)
        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        public bool IsExist(int roleId, int menuId)
        {
            using (var context = new PermissionContext())
            {
                return context.RoleMenuRelations.Count(x => x.RoleId == roleId && x.MenuId == menuId) > 0;
            }
        }
        #endregion public bool IsExist(int roleId, int menuId)

        #region public void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation, PermissionContext context)
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="roleMenuRelation"></param>
        public void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation)
        {
            if (roleMenuRelation == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "请求参数不能为空" };
            }

            if (roleMenuRelation.RoleId < 1)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "角色编号格式错误" };
            }

            using (var context = new PermissionContext())
            {
                List<RoleMenuRelationEntity> roleMenuRelations = context.RoleMenuRelations.Where(x => x.RoleId == roleMenuRelation.RoleId).ToList();
                if (roleMenuRelations.Count > 0)
                {
                    context.RoleMenuRelations.RemoveRange(roleMenuRelations);
                    context.SaveChanges();
                }

                if (roleMenuRelation.MenuIds != null && roleMenuRelation.MenuIds.Count(x => x > 0) > 0)
                {
                    roleMenuRelations = roleMenuRelation.MenuIds.Select(x => new RoleMenuRelationEntity { MenuId = x, CreatedAt = DateTime.Now, RoleId = roleMenuRelation.RoleId }).ToList();
                    context.RoleMenuRelations.AddRange(roleMenuRelations);
                    context.SaveChanges();
                }
            }                 
        }
        #endregion public void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation, PermissionContext context)

        #region public List<RoleMenuDTO> GetRoleMenus(int roleId)
        /// <summary>
        /// 根据角色编号获取所有菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleMenuDTO> GetRoleMenus(int roleId)
        {
            List<RoleMenuDTO>? roleMenus = new List<RoleMenuDTO>();
            if (roleId > 0)
            {
                using (var context = new PermissionContext())
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
        #endregion public List<RoleMenuDTO> GetRoleMenus(int roleId)

        #region public List<RoleMenuDTO> GetAdminMenus()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RoleMenuDTO> GetAdminMenus()
        {
            using (var context = new PermissionContext())
            {
                List<RoleMenuDTO> roleMenus = GetMenus(0, context);
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
                return roleMenus;
            }
        }
        #endregion public List<RoleMenuDTO> GetAdminMenus()

        #region private static List<RoleMenuDTO> GetMenus(int parentId, PermissionContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="parentId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static List<RoleMenuDTO> GetMenus(int parentId, PermissionContext context)
        {
            return (from m in context.Menus
                    where m.ParentId == parentId
                    orderby m.OrderValue ascending
                    select new RoleMenuDTO
                    {
                        MenuId = m.MenuId,
                        MenuName = m.MenuName,
                        ParentId = m.ParentId,
                        SubMenus = null
                    }).ToList();
        }
        #endregion private static List<RoleMenuDTO> GetMenus(int parentId, PermissionContext context)

        #region private static List<RoleMenuDTO> GetMenus(int roleId, int parentId, PermissionContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="parentId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static List<RoleMenuDTO> GetMenus(int roleId, int parentId, PermissionContext context)
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
                        SubMenus = null
                    }).ToList();
        }
        #endregion private static List<RoleMenuDTO> GetMenus(int roleId, int parentId, PermissionContext context)       

    }
}