using MicroShop.IDAL.Permission;
using MicroShop.Utility.Cache;
using MicroShop.Utility;
using MicroShop.Utility.Common;

namespace MicroShop.DALFactory.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleFactory
    {
        /// <summary>
        /// 创建实际的DAL类
        /// </summary>
        /// <returns>MicroShop.IDAL.Permission.IRole</returns>
        public static IRole Create()
        {
            string className = StaticGlobalVariables.MicroShopDAL + ".Permission.RoleDAL";
            return MemcacheClient.CreateObject<IRole>(string.IsNullOrWhiteSpace(StaticGlobalVariables.MicroShopDAL) ? Constants.MICRO_SHOP_DAL : StaticGlobalVariables.MicroShopDAL, className);
        }
    }
}
