using Newtonsoft.Json.Converters;

namespace MicroShop.Utility.Serialize.Json
{
    /// <summary>
    /// 中文日期格式
    /// </summary>
    public class ChineseDateConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ChineseDateConverter()
        {
            DateTimeFormat = "yyyy年M月d日";
        }
    }
}
