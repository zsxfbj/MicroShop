using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
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

    }
}
