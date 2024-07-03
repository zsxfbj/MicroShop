using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.Caching;
using MicroShop.Utility.Common;


namespace MicroShop.Utility.Cache
{
    /// <summary>
    /// 框架自带缓存业务类
    /// </summary>
    public class MemcacheClient
    {
        private readonly static MemoryCache DefaultCache = MemoryCache.Default;

        /// <summary>
        /// 类反射，自动创建，有则直接返回
        /// </summary>
        public static T CreateObject<T>(string path, string typeName)
        {
            if (MemcacheClient.isExist(path))
            {
                return GetValue<T>(typeName);
            }
            T? objType = (T?)Assembly.Load(path).CreateInstance(typeName);
            if (objType == null)
            {
                throw new NotImplementedException("请完成" + typeName + "类的编写");
            }
            SetValue(typeName, objType);
            return objType;
        }

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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        public static void SetValue<T>(string key, T value, DateTimeOffset expireTime)
        {
            DefaultCache.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = expireTime });
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
