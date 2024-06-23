using MicroShop.Product.Enums;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;
using Microsoft.Extensions.Configuration;

namespace MicroShop.Product.BLL
{
    public class BCommon : Singleton<BCommon>
    {
        /// <summary>
        /// 货币类型缓存Key
        /// </summary>
        private const string CurrencyTypesCacheKey = "ProductCurrencyTypes";

        private const string MediaTypesCacheKey = "ProductMediaTypes";

        private const string ProductStatusCacheKey = "ProductStatusList";

        #region public List<KeyValueDTO>? GetCurrencyTypes()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Int32, string> GetCurrencyTypes()
        {
            if (RedisClient.KeyExists(CurrencyTypesCacheKey))
            {
                return RedisClient.StringGet<Dictionary<Int32, string>>(CurrencyTypesCacheKey);
            }

            Dictionary<Int32, string> dicts = new Dictionary<Int32, string>();

            foreach (CurrencyTypeEnum currencyType in Enum.GetValues(typeof(CurrencyTypeEnum)))
            {
                dicts.Add((int)currencyType, currencyType.GetDescription());
            }
            RedisClient.StringSet(CurrencyTypesCacheKey, dicts, TimeSpan.FromDays(Constants.FIFTEEN));
            return dicts;
        }
        #endregion public List<KeyValueDTO>? GetCurrencyTypes()

        #region public List<KeyValueDTO>? GetMediaTypes()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Int32, string>? GetMediaTypes()
        {
            if (RedisClient.KeyExists(MediaTypesCacheKey))
            {
                return RedisClient.StringGet<Dictionary<Int32, string>>(MediaTypesCacheKey);
            }

            Dictionary<Int32, string> keyValues = new               Dictionary<Int32, string>();

            foreach (MediaTypeEnum mediaType in Enum.GetValues(typeof(MediaTypeEnum)))
            {
                keyValues.Add((int)mediaType, mediaType.GetDescription());
            }
            RedisClient.StringSet(MediaTypesCacheKey, keyValues, TimeSpan.FromDays(7));
            return keyValues;
        }
        #endregion public List<KeyValueDTO>? GetMediaTypes()

        #region public List<KeyValueDTO>? GetProductStatusList()
        /// <summary>
        /// 产品状态枚举
        /// </summary>
        /// <returns></returns>
        public Dictionary<Int32, string> GetProductStatusList()
        {
            if (RedisClient.KeyExists(ProductStatusCacheKey))
            {
                return RedisClient.StringGet<Dictionary<Int32, string>>(ProductStatusCacheKey);
            }

            Dictionary<Int32, string> keyValues = new Dictionary<Int32, string>();

            foreach (ProductStatusEnum productStatus in Enum.GetValues(typeof(ProductStatusEnum)))
            {
                keyValues.Add((int)productStatus, productStatus.GetDescription());
            }
            RedisClient.StringSet(ProductStatusCacheKey, keyValues, TimeSpan.FromDays(7));
            return keyValues;
        }
        #endregion public List<KeyValueDTO>? GetProductStatusList()

        #region public string GetImageDomain()
        /// <summary>
        /// 获取图片对外显示的域名
        /// </summary>
        /// <returns></returns>
        public string GetImageDomain()
        {
            IConfigurationSection configurationSection = new ConfigurationManager().GetSection("ImageDomain");
            if(configurationSection != null)
            {
                return configurationSection.Value;
            }
            return string.Empty;
        }
        #endregion public string GetImageDomain()
    }
}
