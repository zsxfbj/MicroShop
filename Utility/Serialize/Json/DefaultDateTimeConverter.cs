using Newtonsoft.Json.Converters;

namespace MicroShop.Utility.Serialize.Json
{
    /// <summary>
    /// 默认日期时间格式转化类
    /// </summary>
    public class DefaultDateTimeConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DefaultDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
