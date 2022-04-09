using System.Collections.Concurrent;
using StackExchange.Redis;

namespace MicroShop.Utility.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public class RedisClient : Common.Singleton<RedisClient>
    {
        /// <summary>
        /// 
        /// </summary>
        private ConnectionMultiplexer? redisMultiplexer;

        /// <summary>
        /// 
        /// </summary>
        private static IDatabase? _db;

        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="redisConnectionString"></param>
        public void InitConnect(string redisConnectionString)
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
        public async Task<bool> StringSetAsync<T>(string key, T value)
        {
            if (_db != null)
            {
                await _db.StringSetAsync(key, value.ToRedisValue());
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
        public bool StringSet<T>(string key, T value, TimeSpan? expiry = null, When when = When.Always, CommandFlags commandFlags = CommandFlags.None)
        {
            if (_db != null)
            {
                _db.StringSet(key, value.ToRedisValue(), expiry, when, commandFlags);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T?> StringGetAsync<T>(string key) where T : class
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
        public T? StringGet<T>(string key) where T : class
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
        public async Task<long> StringIncrementAsync(string key, int value = 1)
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
        public long StringIncrement(string key, int value = 1)
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
        public async Task<long> StringDecrementAsync(string key, int value = 1)
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
        public long StringDecrement(string key, int value = 1)
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
        public async Task<long> EnqueueAsync<T>(string key, T value) => await _db.ListRightPushAsync(key, value.ToRedisValue());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Enqueue<T>(string key, T value) => _db.ListRightPush(key, value.ToRedisValue());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> DequeueAsync<T>(string key) where T : class => (await _db.ListLeftPopAsync(key)).ToObject<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Dequeue<T>(string key) where T : class => _db.ListLeftPop(key).ToObject<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> PeekRangeAsync<T>(string key, long start = 0, long stop = -1) where T : class => (await _db.ListRangeAsync(key, start, stop)).ToObjects<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public IEnumerable<T> PeekRange<T>(string key, long start = 0, long stop = -1) where T : class => _db.ListRange(key, start, stop).ToObjects<T>();

        #endregion

        #region Set

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> SetAddAsync<T>(string key, T value) => await _db.SetAddAsync(key, value.ToRedisValue());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAdd<T>(string key, T value) => _db.SetAdd(key, value.ToRedisValue());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public async Task<long> SetRemoveAsync<T>(string key, IEnumerable<T> values) => await _db.SetRemoveAsync(key, values.ToRedisValues());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public long SetRemove<T>(string key, IEnumerable<T> values) => _db.SetRemove(key, values.ToRedisValues());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SetMembersAsync<T>(string key) where T : class => (await _db.SetMembersAsync(key)).ToObjects<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<T> SetMembers<T>(string key) where T : class => _db.SetMembers(key).ToObjects<T>();


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> SetContainsAsync<T>(string key, T value) => await _db.SetContainsAsync(key, value.ToRedisValue());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetContains<T>(string key, T value) => _db.SetContains(key, value.ToRedisValue());

        #endregion

        #region Sortedset

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public async Task<bool> SortedSetAddAsync(string key, string member, double score) => await _db.SortedSetAddAsync(key, member, score);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public async Task<long> SortedSetRemoveAsync(string key, IEnumerable<string> members) => await _db.SortedSetRemoveAsync(key, members.ToRedisValues());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<double> SortedSetIncrementAsync(string key, string member, double value) => await _db.SortedSetIncrementAsync(key, member, value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<double> SortedSetDecrementAsync(string key, string member, double value) => await _db.SortedSetDecrementAsync(key, member, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<ConcurrentDictionary<string, double>> SortedSetRangeByRankWithScoresAsync(string key,
            long start = 0,
            long stop = -1,
            Order order = Order.Ascending) =>
            (await _db.SortedSetRangeByRankWithScoresAsync(key, start, stop, order)).ToConcurrentDictionary();

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
        public async Task<ConcurrentDictionary<string, double>> SortedSetRangeByScoreWithScoresAsync(string key,
            double start = double.NegativeInfinity, double stop = double.PositiveInfinity,
            Exclude exclude = Exclude.None, Order order = Order.Ascending, long skip = 0, long take = -1) =>
            (await _db.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, take))
            .ToConcurrentDictionary();

        #endregion

        #region Hash

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<ConcurrentDictionary<string, string>> HashGetAsync(string key) =>
            (await _db.HashGetAllAsync(key)).ToConcurrentDictionary();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<ConcurrentDictionary<string, string>> HashGetFieldsAsync(string key,
            IEnumerable<string> fields) =>
            (await _db.HashGetAsync(key, fields.ToRedisValues())).ToConcurrentDictionary(fields);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public async Task HashSetAsync(string key, ConcurrentDictionary<string, string> entries)
        {
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
        public async Task HashSetFieldsAsync(string key, ConcurrentDictionary<string, string> fields)
        {
            if (fields == null || !fields.Any())
                return;

            var hs = await HashGetAsync(key);
            foreach (var field in fields)
            {

                hs[field.Key] = field.Value;
            }

            await HashSetAsync(key, hs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> HashDeleteAsync(string key) =>
            await KeyDeleteAsync(new string[] { key }) > 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<bool> HashDeleteFieldsAsync(string key, IEnumerable<string> fields)
        {
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
        public IEnumerable<string> GetAllKeys() =>
            redisMultiplexer.GetEndPoints().Select(endPoint => redisMultiplexer.GetServer(endPoint))
                .SelectMany(server => server.Keys().ToStrings());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public IEnumerable<string> GetAllKeys(System.Net.EndPoint endPoint) =>
            redisMultiplexer.GetServer(endPoint).Keys().ToStrings();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> KeyExistsAsync(string key)
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
        public bool KeyExists(string key)
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
        public async Task<long> KeyDeleteAsync(IEnumerable<string> keys)
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
        public long KeyDelete(IEnumerable<string> keys)
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
        public bool KeyDelete(string key)
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
        public async Task<bool> KeyDeleteAsync(string key)
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
        public async Task<bool> KeyExpireAsync(string key, TimeSpan? expiry)
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
        public bool KeyExpire(string key, TimeSpan? expiry)
        {
            if (_db != null)
            {
                return _db.KeyExpire(key, expiry);
            }
            throw new NullReferenceException("redis connection is not init, redis database is null.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public async Task<bool> KeyExpireAsync(string key, DateTime? expiry) => await _db.KeyExpireAsync(key, expiry);

        #endregion

        #region Advanced

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> PublishAsync(string channel, string msg)
        {
            if (this.redisMultiplexer != null)
            {
                return await redisMultiplexer.GetSubscriber().PublishAsync(channel, msg);
            }
            throw new NullReferenceException("redis connection is not init, redisMultiplexer is null.");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public async Task SubscribeAsync(string channel, Action<string, string> handler) =>
            await redisMultiplexer.GetSubscriber().SubscribeAsync(channel, (chn, msg) => handler(chn, msg));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public Task ExecuteBatchAsync(params Action[] operations) =>
            Task.Run(() =>
            {
                var batch = _db.CreateBatch();

                foreach (var operation in operations)
                    operation();

                batch.Execute();
            });

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="del"></param>
        /// <param name="expiry"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<(bool, object?)> LockExecuteAsync(string key, string value, Delegate del,
            TimeSpan expiry, params object[] args)
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
        public bool LockExecute(string key, string value, Delegate del, out object? result, TimeSpan expiry,
            int timeout = 0, params object[] args)
        {
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
        public bool LockExecute(string key, string value, Action action, TimeSpan expiry, int timeout = 0)
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
        public bool LockExecute<T>(string key, string value, Action<T> action, T arg, TimeSpan expiry, int timeout = 0)
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
        public bool LockExecute<T>(string key, string value, Func<T> func, out T result, TimeSpan expiry,
            int timeout = 0)
        {
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
        public bool LockExecute<T, TResult>(string key, string value, Func<T, TResult> func, T arg, out TResult result,
            TimeSpan expiry, int timeout = 0)
        {
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

        private bool GetLock(string key, string value, TimeSpan expiry, int timeout)
        {
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
    /// 
    /// </summary>
    public static class StackExchangeRedisExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IEnumerable<string> ToStrings(this IEnumerable<RedisKey> keys)
        {
            var redisKeys = keys as RedisKey[] ?? keys.ToArray();
            return !redisKeys.Any() ? null : redisKeys.Select(k => (string)k);
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
                dict[entry.Name] = entry.Value;
            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashValues"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static ConcurrentDictionary<string, string> ToConcurrentDictionary(this RedisValue[] hashValues,
            IEnumerable<string> fields)
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
        public static ConcurrentDictionary<string, double> ToConcurrentDictionary(
            this IEnumerable<SortedSetEntry> entries)
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
