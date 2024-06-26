﻿using MicroShop.IDAL.Common;
using MicroShop.Utility;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;

namespace MicroShop.DALFactory.Common
{
    /// <summary>
    /// 分类数据工厂类
    /// </summary>
    public class CategoryFactory
    {
        /// <summary>
        /// 创建实际的DAL类
        /// </summary>
        /// <returns>MicroShop.IDAL.Common.ICategory</returns>
        public static ICategory Create()
        {         
            string className = StaticGlobalVariables.MicroShopDAL + ".Common.CategoryDAL";
            return MemcacheClient.CreateObject<ICategory>(string.IsNullOrWhiteSpace(StaticGlobalVariables.MicroShopDAL) ? Constants.MICRO_SHOP_DAL : StaticGlobalVariables.MicroShopDAL, className);
        }
        
    }
}
