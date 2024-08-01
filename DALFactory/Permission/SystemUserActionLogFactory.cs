using MicroShop.IDAL.Permission;
using MicroShop.Utility.Cache;
using MicroShop.Utility;
using MicroShop.Utility.Common;

namespace MicroShop.DALFactory.Permission
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserActionLogFactory
    {
        /// <summary>
        /// 创建实际的DAL类
        /// </summary>
        /// <returns>MicroShop.IDAL.Permission.ISystemUserActionLog</returns>
        public static ISystemUserActionLog Create()
        {
            string className = StaticGlobalVariables.MicroShopDAL + ".Permission.SystemUserActionLogDAL";
            return MemcacheClient.CreateObject<ISystemUserActionLog>(StaticGlobalVariables.MicroShopDAL, className);
        }
    }
}
