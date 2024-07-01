using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.DTO.Permission;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class BRoleMenuRelation : Singleton<BRoleMenuRelation>
    {
        private readonly static IRoleMenuRelation dal = RoleMenuRelationFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool IsExist(int roleId, int menuId)
        {
           if(roleId < 0 || menuId < 0) { return false; }
            
           return dal.IsExist(roleId, menuId);
        }

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="req"></param>
        public void SetRoleMenuRelation(SetRoleMenuRelationReqDTO req)
        {
            dal.SetRoleMenuRelation(req);
        }
    }
}
