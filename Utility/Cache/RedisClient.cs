using System.Collections.Concurrent;
using StackExchange.Redis;

namespace MicroShop.Utility.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public class RedisClient
    {
        /// <summary>
        /// 
        /// </summary>
        private static ConnectionMultiplexer? redisMultiplexer;

        /// <summary>
        /// 
        /// </summary>
        private static IDatabase? _db;

        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="redisConnectionString"></param>
        public static void InitConnect(string redisConnectionString)
        {
            try
            {
                redisMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
                _db = redisMultiplexer.GetDatabase();
            }
            catch
            {
                redisMultiplexer = null;
                _db = null;
            }
        }

        #region String

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<bool> StringSetAsync<T>(string key, T value)
        {
            if (_db != null)
            {
                return await _db.StringSetAsync(key, value.ToRedisValue());
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiry"></param>
        /// <param name="when"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public static bool StringSet<T>(string key, T value, TimeSpan? expiry = null, When when = When.Always, CommandFlags commandFlags = CommandFlags.None)
        {
            if (_db != null)
            {
               return _db.StringSet(key, value.ToRedisValue(), expiry, when, commandFlags);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<T> StringGetAsync<T>(string key) where T : class
        {
            if (_db != null)
            {
                return (await _db.StringGetAsync(key)).ToObject<T>();
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T StringGet<T>(string key) where T : class
        {
            if (_db != null)
            {
                return _db.StringGet(key).ToObject<T>();
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<long> StringIncrementAsync(string key, int value = 1)
        {
            if (_db != null)
            {
                return await _db.StringIncrementAsync(key, value);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long StringIncrement(string key, int value = 1)
        {
            if (_db != null)
            {
                return _db.StringIncrement(key, value);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<long> StringDecrementAsync(string key, int value = 1)
        {
            if (_db != null)
            {
                return await _db.StringDecrementAsync(key, value);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long StringDecrement(string key, int value = 1)
        {
            if (_db != null)
            {
                return _db.StringDecrement(key, value);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        #endregion

        #region List

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<long> EnqueueAsync<T>(string key, T value)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return await _db.ListRightPushAsync(key, value.ToRedisValue());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long Enqueue<T>(string key, T value)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return _db.ListRightPush(key, value.ToRedisValue());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<T?> DequeueAsync<T>(string key) where T : class
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return (await _db.ListLeftPopAsync(key)).ToObject<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Dequeue<T>(string key) where T : class
        {
            if (_db != null)
            {
                return _db.ListLeftPop(key).ToObject<T>();
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> PeekRangeAsync<T>(string key, long start = 0, long stop = -1) where T : class
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return (await _db.ListRangeAsync(key, start, stop)).ToObjects<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public static IEnumerable<T> PeekRange<T>(string key, long start = 0, long stop = -1) where T : class
        {
            if (_db != null)
            {
                return _db.ListRange(key, start, stop).ToObjects<T>();
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        #endregion

        #region Set

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<bool> SetAddAsync<T>(string key, T value)
        {
            if (_db != null)
            {
                return await _db.SetAddAsync(key, value.ToRedisValue());
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetAdd<T>(string key, T value)
        {
            if (_db != null)
            {
                return _db.SetAdd(key, value.ToRedisValue());
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static async Task<long> SetRemoveAsync<T>(string key, IEnumerable<T> values)
        {
            if (_db != null)
            {
                return await _db.SetRemoveAsync(key, values.ToRedisValues());
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static long SetRemove<T>(string key, IEnumerable<T> values)
        {
            if (_db != null)
            {
                return _db.SetRemove(key, values.ToRedisValues());
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T?>?> SetMembersAsync<T>(string key) where T : class
        {
            if (_db != null)
            {
                return (await _db.SetMembersAsync(key)).ToObjects<T>();
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IEnumerable<T> SetMembers<T>(string key) where T : class
        {
            if (_db != null)
            {
                return _db.SetMembers(key).ToObjects<T>();
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<bool> SetContainsAsync<T>(string key, T value)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return await _db.SetContainsAsync(key, value.ToRedisValue());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetContains<T>(string key, T value)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return _db.SetContains(key, value.ToRedisValue());
        }

        #endregion

        #region Sortedset

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static async Task<bool> SortedSetAddAsync(string key, string member, double score)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return await _db.SortedSetAddAsync(key, member, score);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public static async Task<long> SortedSetRemoveAsync(string key, IEnumerable<string> members)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return await _db.SortedSetRemoveAsync(key, members.ToRedisValues());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<double> SortedSetIncrementAsync(string key, string member, double value)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return await _db.SortedSetIncrementAsync(key, member, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<double> SortedSetDecrementAsync(string key, string member, double value)
        {
            if(_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return await _db.SortedSetDecrementAsync(key, member, value);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task<ConcurrentDictionary<string, double>?> SortedSetRangeByRankWithScoresAsync(string key, long start = 0, long stop = -1, Order order = Order.Ascending)
        {
            if(_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return (await _db.SortedSetRangeByRankWithScoresAsync(key, start, stop, order)).ToConcurrentDictionary();
        }
           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="exclude"></param>
        /// <param name="order"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static async Task<ConcurrentDictionary<string, double>?> SortedSetRangeByScoreWithScoresAsync(string key,
            double start = double.NegativeInfinity, double stop = double.PositiveInfinity,
            Exclude exclude = Exclude.None, Order order = Order.Ascending, long skip = 0, long take = -1)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return (await _db.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, take))
            .ToConcurrentDictionary();
        }
            

        #endregion

        #region Hash

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<ConcurrentDictionary<string, string>?> HashGetAsync(string key)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return (await _db.HashGetAllAsync(key)).ToConcurrentDictionary();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static async Task<ConcurrentDictionary<string, string>?> HashGetFieldsAsync(string key, IEnumerable<string> fields)
        {
            if(_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return (await _db.HashGetAsync(key, fields.ToRedisValues())).ToConcurrentDictionary(fields);
        }
           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static async Task HashSetAsync(string key, ConcurrentDictionary<string, string> entries)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            var val = entries.ToHashEntries();
            if (val != null)
                await _db.HashSetAsync(key, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static async Task HashSetFieldsAsync(string key, ConcurrentDictionary<string, string> fields)
        {
            if (fields == null || !fields.Any())
                return;

            ConcurrentDictionary<string, string>? hs = await HashGetAsync(key);
            if(hs != null)
            {
                foreach (var field in fields)
                {

                    hs[field.Key] = field.Value;
                }
                await HashSetAsync(key, hs);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> HashDeleteAsync(string key)
        {
            if(_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }

            return await KeyDeleteAsync(new string[] { key }) > 0;
        }
          

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static async Task<bool> HashDeleteFieldsAsync(string key, IEnumerable<string> fields)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }

            if (fields == null || !fields.Any())
                return false;

            var success = true;
            foreach (var field in fields)
            {
                if (!await _db.HashDeleteAsync(key, field))
                    success = false;
            }

            return success;
        }

        #endregion

        #region Key

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string?>? GetAllKeys()
        {
            if (redisMultiplexer != null)
            {
                IServer? server = redisMultiplexer.GetEndPoints().Select(endPoint => redisMultiplexer.GetServer(endPoint)).FirstOrDefault();
                if(server != null)
                {
                    return server.Keys().ToStrings();
                }      
                else
                {
                    return new List<string>();
                }
            }
            throw new NullReferenceException("redis connection is not init, redisMultiplexer is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public static IEnumerable<string?>? GetAllKeys(System.Net.EndPoint endPoint)
        {
            if (redisMultiplexer != null)
            {
                return redisMultiplexer.GetServer(endPoint).Keys().ToStrings();
            }
            throw new NullReferenceException("redis connection is not init, redisMultiplexer is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> KeyExistsAsync(string key)
        {
            if (_db != null)
            {
                return await _db.KeyExistsAsync(key);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 判断key的缓存是否存在
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns>true or false</returns>
        public static bool KeyExists(string key)
        {
            if (_db != null)
            {
                return _db.KeyExists(key);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static async Task<long> KeyDeleteAsync(IEnumerable<string> keys)
        {
            if (_db != null)
            {
                return await _db.KeyDeleteAsync(keys.Select(k => (RedisKey)k).ToArray());
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 批量根据KEY移除缓存
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>移除的数量</returns>
        public static long KeyDelete(IEnumerable<string> keys)
        {
            if (_db != null)
            {
                return _db.KeyDelete(keys.Select(k => (RedisKey)k).ToArray());
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyDelete(string key)
        {
            if (_db != null)
            {
                return _db.KeyDelete(key);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> KeyDeleteAsync(string key)
        {
            if (_db != null)
            {
                return await _db.KeyDeleteAsync(key);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public static async Task<bool> KeyExpireAsync(string key, TimeSpan? expiry)
        {
            if (_db != null)
            {
                return await _db.KeyExpireAsync(key, expiry);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 设置Key过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public static bool KeyExpire(string key, TimeSpan? expiry)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return _db.KeyExpire(key, expiry);
        }

        /// <summary>
        /// 设置Key过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public static async Task<bool> KeyExpireAsync(string key, DateTime? expiry)
        {
            if (_db != null)
            {
                return await _db.KeyExpireAsync(key, expiry);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        #endregion

        #region Advanced

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static async Task<long> PublishAsync(string channelName, string msg)
        {
            if (redisMultiplexer != null)
            {                
                return await redisMultiplexer.GetSubscriber().PublishAsync(new RedisChannel(channelName, RedisChannel.PatternMode.Literal), msg);
            }
            throw new NullReferenceException("redis connection is not init, redisMultiplexer is null.");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static async Task SubscribeAsync(string channelName, Action<string, string> handler)
        {
            if (redisMultiplexer != null)
            {               
                await redisMultiplexer.GetSubscriber().SubscribeAsync(new RedisChannel(channelName, RedisChannel.PatternMode.Literal), (chn, msg) => handler(chn, msg));
            }
            else
            {
                throw new NullReferenceException("redis connection is not init, redisMultiplexer is null.");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static Task ExecuteBatchAsync(params Action[] operations)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            return Task.Run(() =>
            {
                var batch = _db.CreateBatch();

                foreach (var operation in operations)
                    operation();

                batch.Execute();
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="del"></param>
        /// <param name="expiry"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<(bool, object?)> LockExecuteAsync(string key, string value, Delegate del, TimeSpan expiry, params object?[]? args)
        {
            if (_db == null || !await _db.LockTakeAsync(key, value, expiry))
            {
                return (false, null);
            }

            try
            {
                return (true, del.DynamicInvoke(args));
            }
            finally
            {
                _db.LockRelease(key, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="del"></param>
        /// <param name="result"></param>
        /// <param name="expiry"></param>
        /// <param name="timeout"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool LockExecute(string key, string value, Delegate del, out object? result, TimeSpan expiry, int timeout = 0, params object?[] args)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }
            result = null;
            if (!GetLock(key, value, expiry, timeout))
                return false;

            try
            {
                result = del.DynamicInvoke(args);
                return true;
            }
            finally
            {
                if (_db != null)
                {
                    _db.LockRelease(key, value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <param name="expiry"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool LockExecute(string key, string value, Action action, TimeSpan expiry, int timeout = 0)
        {
            return LockExecute(key, value, action, out var _, expiry, timeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <param name="arg"></param>
        /// <param name="expiry"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool LockExecute<T>(string key, string value, Action<T> action, T? arg, TimeSpan expiry, int timeout = 0)
        {
            return LockExecute(key, value, action, out var _, expiry, timeout, arg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="result"></param>
        /// <param name="expiry"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool LockExecute<T>(string key, string value, Func<T> func, out T? result, TimeSpan expiry, int timeout = 0)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }

            result = default;
            if (!GetLock(key, value, expiry, timeout))
                return false;
            try
            {
                result = func();
                return true;
            }
            finally
            {
                _db.LockRelease(key, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="arg"></param>
        /// <param name="result"></param>
        /// <param name="expiry"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool LockExecute<T, TResult>(string key, string value, Func<T, TResult> func, T arg, out TResult? result, TimeSpan expiry, int timeout = 0)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }

            result = default;
            if (!GetLock(key, value, expiry, timeout))
                return false;
            try
            {
                result = func(arg);
                return true;
            }
            finally
            {
                _db.LockRelease(key, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiry"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        private static bool GetLock(string key, string value, TimeSpan expiry, int timeout)
        {
            if (_db == null)
            {
                throw new NullReferenceException("redis connection is not init, redis database is null.");
            }

            using (var waitHandle = new AutoResetEvent(false))
            {
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += (s, e) =>
                {
                    if (!_db.LockTake(key, value, expiry))
                        return;
                    try
                    {
                        waitHandle.Set();
                        timer.Stop();
                    }
                    catch
                    {
                    }
                };
                timer.Start();

                if (timeout > 0)
                    waitHandle.WaitOne(timeout);
                else
                    waitHandle.WaitOne();

                timer.Stop();
                timer.Close();
                timer.Dispose();
                return _db.LockQuery(key) == value;
            }

        }
        #endregion
    }

    /// <summary>
    /// Redis扩展类
    /// </summary>
    public static class StackExchangeRedisExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IEnumerable<string?>? ToStrings(this IEnumerable<RedisKey> keys)
        {
            var redisKeys = keys as RedisKey[] ?? keys.ToArray();
            return !redisKeys.Any() ? null : redisKeys.Select(k => k.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static RedisValue ToRedisValue<T>(this T value)
        {
            if (value == null)
                return RedisValue.Null;

            return value is ValueType || value is string
                ? value as string
                : System.Text.Json.JsonSerializer.Serialize(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static RedisValue[]? ToRedisValues<T>(this IEnumerable<T> values)
        {
            var enumerable = values as T[] ?? values.ToArray();
            return enumerable.Any() ? enumerable.Select(v => v.ToRedisValue()).ToArray() : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToObject<T>(this RedisValue value) where T : class
        {
            if (value == RedisValue.Null)
                return null;

            return typeof(T) == typeof(string)
                ? value.ToString() as T
                : System.Text.Json.JsonSerializer.Deserialize<T>(value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<T?>? ToObjects<T>(this IEnumerable<RedisValue> values) where T : class
        {
            var redisValues = values as RedisValue[] ?? values.ToArray();
            if (redisValues != null && redisValues.Any())
            {
                return redisValues.Select(v => v.ToObject<T>());
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static HashEntry[]? ToHashEntries(this ConcurrentDictionary<string, string> entries)
        {
            if (entries == null || !entries.Any())
                return null;

            var es = new HashEntry[entries.Count];
            for (var i = 0; i < entries.Count; i++)
            {
                var name = entries.Keys.ElementAt(i);
                var value = entries[name];
                es[i] = new HashEntry(name, value);
            }
            return es;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static ConcurrentDictionary<string, string>? ToConcurrentDictionary(this IEnumerable<HashEntry> entries)
        {
            var hashEntries = entries as HashEntry[] ?? entries.ToArray();
            if (!hashEntries.Any())
                return null;

            var dict = new ConcurrentDictionary<string, string>();
            foreach (var entry in hashEntries)
            {
                if(!string.IsNullOrEmpty(entry.Name) && !string.IsNullOrEmpty(entry.Value))
                {
                    dict.TryAdd(entry.Name, entry.Value);                   
                }                
            }
            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashValues"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static ConcurrentDictionary<string, string>? ToConcurrentDictionary(this RedisValue[] hashValues, IEnumerable<string> fields)
        {
            var enumerable = fields as string[] ?? fields.ToArray();
            if (hashValues == null || !hashValues.Any() || !enumerable.Any())
                return null;

            var dict = new ConcurrentDictionary<string, string>();
            for (var i = 0; i < enumerable.Count(); i++)
                dict[enumerable.ElementAt(i)] = hashValues[i];

            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static ConcurrentDictionary<string, double>? ToConcurrentDictionary(this IEnumerable<SortedSetEntry> entries)
        {
            var sortedSetEntries = entries as SortedSetEntry[] ?? entries.ToArray();
            if (!sortedSetEntries.Any())
                return null;
            var dict = new ConcurrentDictionary<string, double>();
            foreach (var entry in sortedSetEntries)
                dict[entry.Element] = entry.Score;

            return dict;
        }
    }
}
