using System;

namespace MicroShop.Utility.Common.Snowflake
{
    /// <summary>
    /// 静态系统类
    /// </summary>
    public static class System
    {
        /// <summary>
        /// 
        /// </summary>
        private static Func<long> currentTimeFunc = InternalCurrentTimeMillis;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long CurrentTimeMillis()
        {
            return currentTimeFunc();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IDisposable StubCurrentTime(Func<long> func)
        {
            currentTimeFunc = func;
            return new DisposableAction(() =>
            {
                currentTimeFunc = InternalCurrentTimeMillis;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="millis"></param>
        /// <returns></returns>
        public static IDisposable StubCurrentTime(long millis)
        {
            currentTimeFunc = () => millis;
            return new DisposableAction(() =>
            {
                currentTimeFunc = InternalCurrentTimeMillis;
            });
        }

        private static readonly DateTime Jan1st1970 = new DateTime
           (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static long InternalCurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
    }

}
