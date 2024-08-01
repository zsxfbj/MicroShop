using MicroShop.Utility.Enums;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace MicroShop.WebApi.Filter
{
    /// <summary>
    /// 向Swagger添加枚举值说明
    /// </summary>
    public class SwaggerEnumFilter : ISchemaFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                StringBuilder stringBuilder = new StringBuilder();
                schema.Enum.Clear();
                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(name =>
                    {
                        Enum e = (Enum)Enum.Parse(context.Type, name);
                        var data = $"{Convert.ToInt64(Enum.Parse(context.Type, name))}:{name}({e.GetDescription()})";

                        stringBuilder.AppendLine(data);
                    });

                schema.Description = stringBuilder.ToString();
                schema.Type = context.Type.Name;
                schema.Format = context.Type.Name;
            }
        }
    }
}
