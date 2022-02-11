using Newtonsoft.Json.Converters;

namespace MicroShop.Utility.Serialize.Json
{
    /// <summary>
    /// 默认日期格式输出
    /// </summary>
    public class DefaultDateConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DefaultDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
