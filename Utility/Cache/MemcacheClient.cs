using System.Runtime.Caching;
using MicroShop.Utility.Common;


namespace MicroShop.Utility.Cache
{
    /// <summary>
    /// 框架缓存业务类
    /// </summary>
    public class MemcacheClient
    {
        private readonly static MemoryCache DefaultCache = MemoryCache.Default;

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetValue<T>(string key, T value)
        {
            DefaultCache.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.MaxValue, SlidingExpiration = TimeSpan.FromDays(Constants.ONE) });
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<T>(string key)
        {
            return (T)DefaultCache.Get(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            DefaultCache.Remove(key);
        }

        /// <summary>
        /// 判断是否存在key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool isExist(string key) { 
            return DefaultCache.Contains(key);
        }
    }
}
