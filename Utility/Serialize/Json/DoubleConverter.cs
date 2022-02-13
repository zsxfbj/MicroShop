using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MicroShop.Utility.Serialize.Json
{
    /// <summary>
    ///  Double数据类JSON序列化和反序列化的约定
    /// </summary>
    public class DoubleConverter : JsonConverter
    {
        /// <summary>
        ///     读取JSON
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Null && objectType == typeof(double?))
            {
                return null;
            }
            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                return token.ToObject<double>();
            }
            if (token.Type == JTokenType.String)
            {
                // customize this to suit your needs
                if(!double.TryParse(token.ToString(), out double value))
                {
                    value = 0;
                }
                return value;
                
            }
            throw new JsonSerializationException("Unexpected token type: " + token.Type);
        }

        /// <summary>
        ///     判断是否可以转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(double) || objectType == typeof(double?));
        }

        /// <summary>
        ///     写到JSON里
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                if(double.TryParse(value.ToString(), out double destValue))
                {
                    serializer.Serialize(writer, destValue.ToString("#0.###"));
                }
                else
                {
                    serializer.Serialize(writer, "");
                }
            }
            else
            {
                serializer.Serialize(writer, "");
            }
        }
    }

}
