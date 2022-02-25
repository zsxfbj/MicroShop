using MicroShop.Permission.Entity;
using MicroShop.Permission.Model.Request;
using MicroShop.Web.Common;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 角色菜单关系
    /// </summary>
    public class BRoleMenuRelation : Utility.Common.Singleton<BRoleMenuRelation>
    {
        #region public void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation, PermissionContext context)
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="roleMenuRelation"></param>
        public void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation, PermissionContext context)
        {
            if(roleMenuRelation == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "请求参数不能为空" };
            }

            if(roleMenuRelation.RoleId < 1)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "角色编号格式错误" };
            }

            if(context == null)
            {
                context = new PermissionContext();
            }

            List<RoleMenuRelationEntity> roleMenuRelations = context.RoleMenuRelations.Where(x => x.RoleId == roleMenuRelation.RoleId).ToList();
            if (roleMenuRelations.Count > 0)
            {
                context.RoleMenuRelations.RemoveRange(roleMenuRelations);
                context.SaveChanges();
            }

            if (roleMenuRelation.MenuIds != null && roleMenuRelation.MenuIds.Count(x=>x> 0) > 0)
            {
                roleMenuRelations = roleMenuRelation.MenuIds.Select(x => new RoleMenuRelationEntity { MenuId = x, CreatedAt = DateTime.Now, RoleId = roleMenuRelation.RoleId }).ToList();
                context.RoleMenuRelations.AddRange(roleMenuRelations);
                context.SaveChanges();
            }             
        }
        #endregion public void SetRoleMenuRelation(RoleMenuRelationDTO roleMenuRelation, PermissionContext context)
    }
}