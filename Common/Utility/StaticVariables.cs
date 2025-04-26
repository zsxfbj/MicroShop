namespace MicroShop.Common.Utility
{
    /// <summary>
    /// 全局静态变量
    /// </summary>
    public class StaticVariables
    {
        /// <summary>
        /// 数据访问层
        /// </summary>
        public static string MicroShopDAL { get; set; } = "MicroShop.Database.SQLServerDAL";

        /// <summary>
        /// 数据库访问链接
        /// </summary>
        public static string SQLConnectionString { get; set; } = "Server=.\\SQLEXPRESS;Database=micro_shop;User ID=sa;Password=sheng@123;Trusted_Connection=True";

        /// <summary>
        /// 缓存类型
        /// </summary>
        public static string CacheType { get; set; } = "system";

        /// <summary>
        /// Redis链接字符串
        /// </summary>
        public static string RedisConnectionString { get; set; } = "127.0.0.1:6379,password=,DefaultDatabase=1";

        /// <summary>
        /// 是否Debug模式
        /// </summary>
        public static bool IsDebug { get; set; } = true;
    }
}
