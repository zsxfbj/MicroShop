using MicroShop.Model.Common.Exception;
using MicroShop.Utility;
using MicroShop.Utility.Cache;
using Microsoft.Extensions.Configuration;

namespace MicroShop.BLL.Common
{
    /// <summary>
    /// 缓存类的使用
    /// </summary>
    public class BCache
    {
        private static bool isInit = false;

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <exception cref="ServiceException"></exception>
        private static void InitRedis()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            string? redisConnectionString = builder.Build().GetConnectionString("RedisConnectionString");
            if (string.IsNullOrEmpty(redisConnectionString))
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "请先配置Redis链接字符串" };
            }
            RedisClient.InitConnect(redisConnectionString);
            isInit = true;
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存的对象</param>
        public static void SetValue<T>(string key, T value)
        {
            if(StaticGlobalVariables.CacheType.Equals("system", StringComparison.OrdinalIgnoreCase))
            {
                MemcacheClient.SetValue(key, value);
            }
            else
            {
                if (!isInit)
                {
                    InitRedis();
                }
                RedisClient.StringSet(key, value);
            }
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存的对象</param>
        /// <param name="expiry">过期的时长</param>
        public static void SetValue<T>(string key, T value, TimeSpan expiry)
        {
            if (StaticGlobalVariables.CacheType.Equals("system", StringComparison.OrdinalIgnoreCase))
            {
                DateTimeOffset offset = DateTimeOffset.Now.AddTicks(expiry.Ticks);
                MemcacheClient.SetValue(key, value, offset);
            }
            else
            {
                if (!isInit)
                {
                    InitRedis();
                }
                RedisClient.StringSet(key, value, expiry);
            }
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static T GetValue<T>(string key) where T : class 
        {
            if (StaticGlobalVariables.CacheType.Equals("system", StringComparison.OrdinalIgnoreCase))
            {
                return MemcacheClient.GetValue<T>(key);
            }
            else
            {
                if (!isInit)
                {
                    InitRedis();
                }
                return RedisClient.StringGet<T>(key);
            }
        }

        /// <summary>
        /// 根据缓存Key删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        public static void Remove(string key)
        {
            if (StaticGlobalVariables.CacheType.Equals("system", StringComparison.OrdinalIgnoreCase))
            {
                MemcacheClient.Remove(key);
            }
            else
            {
                if (!isInit)
                {
                    InitRedis();
                }
                RedisClient.KeyDelete(key);
            }
        }

        /// <summary>
        /// 缓存Key是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static bool IsExist(string key)
        {
            if (StaticGlobalVariables.CacheType.Equals("system", StringComparison.OrdinalIgnoreCase))
            {
                return MemcacheClient.IsExist(key);
            }
            else
            {
                if (!isInit)
                {
                    InitRedis();
                }
                return RedisClient.KeyExists(key);
            }
        }
    }
}
