using MicroShop.Web.Common;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MicroShop.Web.AdminApi.Filter
{
    /// <summary>
    /// Head头参数
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
            {
                operation.Parameters = new List<OpenApiParameter> 
                {
                    new OpenApiParameter
                    {
                        Name = HeaderParameters.SYSTEM_USER_AUTH_TOKEN_KEY,
                        In = ParameterLocation.Header,
                        Description = "系统人员访问令牌",
                        Required = false,
                        Schema = new OpenApiSchema
                        {
                            Type = "String",
                            Default = new OpenApiString("d2b36e54476a4fbab2e3a64d27452ee7")
                        }
                    },
                    new OpenApiParameter
                    {
                        Name = HeaderParameters.USER_AUTH_TOKEN_KEY,
                        In = ParameterLocation.Header,
                        Description = "用户访问令牌",
                        Required = false,
                        Schema = new OpenApiSchema
                        {
                            Type = "String",
                            Default = new OpenApiString("d2b36e54476a4fbab2e3a64d27452ee7")
                        }
                    },
                    new OpenApiParameter
                    {
                        Name = HeaderParameters.CLIENT_TYPE_KEY,
                        In = ParameterLocation.Header,
                        Description = "客户端类型：100-PC网页端；200-手机网页端",
                        Required = false,
                        Schema = new OpenApiSchema
                        {
                            Type = "int",
                            Default = new OpenApiInteger(100)
                        }
                    },
                    new OpenApiParameter
                    {
                        Name = HeaderParameters.APP_CODE_KEY,
                        In = ParameterLocation.Header,
                        Description = "应用Code编码",
                        Required = false,
                        Schema = new OpenApiSchema
                        {
                            Type = "String",
                            Default = new OpenApiString("ltq-wx-mini")
                        }
                    }
                };
            }
        }
    }
}
