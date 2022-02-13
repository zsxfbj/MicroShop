using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MicroShop.Permission.WebApi.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class HideOcelotControllersFilter : IDocumentFilter
    {
        private static readonly string[] _ignoredPaths = {
            "/configuration",
            "/outputcache/{region}"
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var ignorePath in _ignoredPaths)
            {
                swaggerDoc.Paths.Remove(ignorePath);
            }
        }
    }
}
