using MicroShop.Enum.Common;
using MicroShop.Enum.Payment;
using MicroShop.Enum.Permission;
using MicroShop.Enum;
using MicroShop.Model.VO.Common;
using MicroShop.Enum.Product;


namespace MicroShop.BLL.Common
{
    /// <summary>
    /// 枚举业务相关方法
    /// </summary>
    public class BEnum
    {
        private const string LoginStatusCacheKey = "enum-login-status-list";

        private const string UserActionTypeCacheKey = "enum-user-action-list";

        private const string CurrencyTypeCacheKey = "enum-currency-type-list";

        private const string MediaTypeCacheKey = "enum-media-type-list";

        private const string ProductStatusCacheKey = "enum-product-status-list";

        #region public static List<KeyValueVO<int>> GetLoginStatusList()
        /// <summary>
        /// 获取登录状态列表
        /// </summary>
        /// <returns>List of KeyValueVO</returns>
        public static List<KeyValueVO<int>> GetLoginStatusList()
        {
            if (BCache.IsExist(LoginStatusCacheKey))
            {
                return BCache.GetValue<List<KeyValueVO<int>>>(LoginStatusCacheKey);
            }
            List<KeyValueVO<int>> keyValues = new List<KeyValueVO<int>>();

            foreach (LoginStatuses loginStatus in System.Enum.GetValues(typeof(LoginStatuses)))
            {
                keyValues.Add(new KeyValueVO<int> { Key = (int)loginStatus, Value = loginStatus.GetDescription() });
            }
            //设置缓存
            BCache.SetValue(LoginStatusCacheKey, keyValues);
            return keyValues;
        }
        #endregion public List<KeyValueVO<int>> GetLoginStatusList()

        #region public static List<KeyValueVO<int>> GetUserActionTypeList()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<KeyValueVO<int>> GetUserActionTypeList()
        {
            if (BCache.IsExist(UserActionTypeCacheKey))
            {
                return BCache.GetValue<List<KeyValueVO<int>>>(UserActionTypeCacheKey);
            }
            List<KeyValueVO<int>> keyValues = new List<KeyValueVO<int>>();

            foreach (ActionTypes actionType in System.Enum.GetValues(typeof(ActionTypes)))
            {
                keyValues.Add(new KeyValueVO<int> { Key = (int)actionType, Value = actionType.GetDescription() });
            }
            //设置缓存
            BCache.SetValue(UserActionTypeCacheKey, keyValues);
            return keyValues;
        }
        #endregion public List<KeyValueVO<int>> GetUserActionTypeList()

        #region public List<KeyValueVO<int>> GetCurrencyTypeList()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<KeyValueVO<int>> GetCurrencyTypeList()
        {
            if (BCache.IsExist(CurrencyTypeCacheKey))
            {
                return BCache.GetValue<List<KeyValueVO<int>>>(CurrencyTypeCacheKey);
            }
            List<KeyValueVO<int>> keyValues = new List<KeyValueVO<int>>();

            foreach (CurrencyTypes currencyType in System.Enum.GetValues(typeof(CurrencyTypes)))
            {
                keyValues.Add(new KeyValueVO<int> { Key = (int)currencyType, Value = currencyType.GetDescription() });
            }
            //设置缓存
            BCache.SetValue(CurrencyTypeCacheKey, keyValues);
            return keyValues;
        }
        #endregion public List<KeyValueVO<int>> GetCurrencyTypeList()

        #region public List<KeyValueVO<int>> GetMediaTypeList()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<KeyValueVO<int>> GetMediaTypeList()
        {
            if (BCache.IsExist(MediaTypeCacheKey))
            {
                return BCache.GetValue<List<KeyValueVO<int>>>(MediaTypeCacheKey);
            }
            List<KeyValueVO<int>> keyValues = new List<KeyValueVO<int>>();

            foreach (MediaTypes mediaType in System.Enum.GetValues(typeof(MediaTypes)))
            {
                keyValues.Add(new KeyValueVO<int> { Key = (int)mediaType, Value = mediaType.GetDescription() });
            }
            //设置缓存
            BCache.SetValue(MediaTypeCacheKey, keyValues);
            return keyValues;
        }
        #endregion public List<KeyValueVO<int>> GetMediaTypeList()

        #region public List<KeyValueVO<int>> GetProductStatusList()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<KeyValueVO<int>> GetProductStatusList()
        {
            if (BCache.IsExist(ProductStatusCacheKey))
            {
                return BCache.GetValue<List<KeyValueVO<int>>>(ProductStatusCacheKey);
            }
            List<KeyValueVO<int>> keyValues = new List<KeyValueVO<int>>();

            foreach (ProductStatuses productStatus in System.Enum.GetValues(typeof(ProductStatuses)))
            {
                keyValues.Add(new KeyValueVO<int> { Key = (int)productStatus, Value = productStatus.GetDescription() });
            }
            //设置缓存
            BCache.SetValue(ProductStatusCacheKey, keyValues);
            return keyValues;
        }
        #endregion public List<KeyValueVO<int>> GetProductStatusList()
    }
}
