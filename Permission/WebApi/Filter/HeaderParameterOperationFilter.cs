using MicroShop.Web.Common;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MicroShop.Permission.WebApi.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class HeaderParameterOperationFilter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY,
                In = ParameterLocation.Header,
                Description = "访问令牌",
                Required = false,                
                Schema = new OpenApiSchema
                {
                    Type = "String",
                    Default = new OpenApiString("d2b36e54-476a-4fba-b2e3-a64d27452ee7")
                }
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = HeaderParameters.CLIENT_TYPE_KEY,
                In = ParameterLocation.Header,
                Description = "客户端类型：100-PC网页端；200-手机网页端",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int",
                    Default = new OpenApiInteger(1)
                }
            });            
        }
    }
}