using MicroShop.IDAL.Permission;
using MicroShop.Utility.Cache;
using MicroShop.Utility;
using MicroShop.Utility.Common;

namespace MicroShop.DALFactory.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserFactory
    {
        /// <summary>
        /// 创建实际的DAL类
        /// </summary>
        /// <returns>MicroShop.IDAL.Permission.ISystemUser</returns>
        public static ISystemUser Create()
        {
            string className = StaticGlobalVariables.MicroShopDAL + ".Permission.SystemUserDAL";
            return MemcacheClient.CreateObject<ISystemUser>(StaticGlobalVariables.MicroShopDAL, className);
        }
    }
}
