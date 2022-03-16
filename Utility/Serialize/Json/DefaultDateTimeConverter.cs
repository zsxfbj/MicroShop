using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace MicroShop.Utility.Serialize.Json
{
    /// <summary>
    /// 默认日期时间格式转化类
    /// </summary>
    public class DefaultDateTimeConverter : JsonConverter
    {
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Date)
            {
                return token.ToObject<DateTime>();
            }
            if (token.Type == JTokenType.String)
            {
                if (!DateTime.TryParse(token.ToString(), out DateTime value))
                {
                    value = DateTime.Now;
                }
                return value;
            }
            if (token.Type == JTokenType.Null && objectType == typeof(DateTime?))
            {
                return null;
            }
            throw new JsonSerializationException("Unexpected token type: " + token.Type);
        }

        /// <summary>
        /// 判断是否可以转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return (typeof(DateTime) == objectType || typeof(DateTime?) == objectType);
        }

        /// <summary>
        /// 写到JSON里
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, "");
            }
            else
            {
                serializer.Serialize(writer, ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
    }
}
