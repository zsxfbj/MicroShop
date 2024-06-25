using MicroShop.IDAL.Permission;
using MicroShop.Utility.Cache;
using MicroShop.Utility;
using MicroShop.Utility.Common;

namespace MicroShop.DALFactory.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleMenuRelationFactory
    {
        /// <summary>
        /// 创建实际的DAL类
        /// </summary>
        /// <returns>MicroShop.IDAL.Permission.IRoleMenuRelation</returns>
        public static IRoleMenuRelation Create()
        {
            string className = StaticGlobalVariables.MicroShopDAL + ".Permission.RoleMenuRelationDAL";
            return MemcacheClient.CreateObject<IRoleMenuRelation>(string.IsNullOrWhiteSpace(StaticGlobalVariables.MicroShopDAL) ? Constants.MICRO_SHOP_DAL : StaticGlobalVariables.MicroShopDAL, className);
        }
    }
}
