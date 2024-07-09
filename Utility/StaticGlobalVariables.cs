namespace MicroShop.Utility
{
    /// <summary>
    /// 静态全局变量，不处理执行默认值
    /// 开发人员：ShengXiongFeng
    /// 创建日期：2024-06-24
    /// </summary>
    public class StaticGlobalVariables
    {
        /// <summary>
        /// 数据访问层
        /// </summary>
        public static string? MicroShopDAL { get; set; } = "MicroShop.SQLServerDAL";

        /// <summary>
        /// 数据库访问链接
        /// </summary>
        public static string? SQLConnectionString { get; set; } = "Server=.\\SQLEXPRESS;Database=micro_shop;User ID=sa;Password=sheng@123;Trusted_Connection=True";

        /// <summary>
        /// 缓存类型
        /// </summary>
        public static string CacheType { get; set; } = "system";
        
        /// <summary>
        /// 是否Debug模式
        /// </summary>
        public static bool? IsDebug { get; set; } = true;

    }
}
