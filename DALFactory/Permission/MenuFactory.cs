using MicroShop.Utility.Cache;
using MicroShop.Utility;
using MicroShop.Utility.Common;
using MicroShop.IDAL.Permission;

namespace MicroShop.DALFactory.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuFactory
    {
        /// <summary>
        /// 创建实际的DAL类
        /// </summary>
        /// <returns>MicroShop.IDAL.Permission.IMenu</returns>
        public static IMenu Create()
        {
            string className = StaticGlobalVariables.MicroShopDAL + ".Permission.MenuDAL";
            return MemcacheClient.CreateObject<IMenu>(string.IsNullOrWhiteSpace(StaticGlobalVariables.MicroShopDAL) ? Constants.MICRO_SHOP_DAL : StaticGlobalVariables.MicroShopDAL, className);
        }
    }
}
