using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MicroShop.Utility.Serialize.Json
{
    /// <summary>
    ///  JSON序列化时Long型转String类型
    /// </summary>
    public class LongToStringConverter : JsonConverter
    {
        /// <summary>
        /// 读取JSON
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {           
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Integer)
            {
                return token.ToObject<long>();
            }
            if (token.Type == JTokenType.String)
            {
                if (!long.TryParse(token.ToString(), out long value)) 
                {
                    value = 0;
                }
                return value;
            }
            if (token.Type == JTokenType.Null && objectType == typeof(long?))
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
            return (typeof(long) == objectType || typeof(long?) == objectType);
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
                serializer.Serialize(writer, value.ToString());
            }           
        }
    }

}
