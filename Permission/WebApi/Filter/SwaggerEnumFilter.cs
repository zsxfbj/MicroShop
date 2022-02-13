
using Microsoft.OpenApi.Any;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;

namespace MicroShop.Permission.WebApi.Filter
{
    /// <summary>
    /// 向Swagger添加枚举值说明
    /// </summary>
    public class SwaggerEnumFilter : IDocumentFilter
    {

        #region public void Apply(Microsoft.OpenApi.Models.OpenApiDocument swaggerDoc, DocumentFilterContext context)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(Microsoft.OpenApi.Models.OpenApiDocument swaggerDoc, DocumentFilterContext context)

        {
            Dictionary<string, Type> dict = GetAllEnum();

            foreach (var item in swaggerDoc.Components.Schemas)            
            {
                var property = item.Value;
                var typeName = item.Key;
                Type? itemType;
                if (property.Enum != null && property.Enum.Count > 0)
                {
                    if (dict.ContainsKey(typeName))
                    {
                        itemType = dict[typeName];
                    }
                    else
                    {
                        itemType = null;
                    }
                    if(itemType != null)
                    {
                        List<OpenApiInteger> list = new List<OpenApiInteger>();
                        foreach (var val in property.Enum)
                        {
                            list.Add((OpenApiInteger)val);
                        }
                        property.Description += DescribeEnum(itemType, list);
                    }                    
                }
            }
        }
        #endregion public void Apply(Microsoft.OpenApi.Models.OpenApiDocument swaggerDoc, DocumentFilterContext context)

        #region private static Dictionary<string, Type> GetAllEnum()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, Type> GetAllEnum()
        {
            Assembly ass = Assembly.Load("MicroShop.Permission.Enums");
            Type[] types = ass.GetTypes();
            Dictionary<string, Type> dict = new Dictionary<string, Type>();

            foreach (Type item in types)
            {
                if (item.IsEnum)
                {
                    dict.Add(item.Name, item);
                }
            }
            return dict;
        }
        #endregion private static Dictionary<string, Type> GetAllEnum()

        #region private static string DescribeEnum(Type type, List<OpenApiInteger> enums)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="enums"></param>
        /// <returns></returns>
        private static string DescribeEnum(Type type, List<OpenApiInteger> enums)
        {
            var enumDescriptions = new List<string>();
            foreach (var item in enums)
            {               
                var value = Enum.Parse(type, item.Value.ToString());
                var desc = GetDescription(type, value);

                if (string.IsNullOrEmpty(desc))
                    enumDescriptions.Add($"{item.Value}:{Enum.GetName(type, value)}; ");
                else
                    enumDescriptions.Add($"{item.Value}:{Enum.GetName(type, value)},{desc}; ");

            }
            return $"<br/>{Environment.NewLine}{string.Join("<br/>" + Environment.NewLine, enumDescriptions)}";
        }
        #endregion private static string DescribeEnum(Type type, List<OpenApiInteger> enums)

        #region private static string GetDescription(Type t, object value)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetDescription(Type t, object value)
        {
            foreach (MemberInfo mInfo in t.GetMembers())
            {
                if (mInfo.Name == t.GetEnumName(value))
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(DescriptionAttribute))
                        {
                            return ((DescriptionAttribute)attr).Description;
                        }
                    }
                }
            }
            return string.Empty;
        }
        #endregion private static string GetDescription(Type t, object value)
    }
}
