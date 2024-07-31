using Microsoft.Extensions.Configuration;

namespace MicroShop.Utility.Common
{
    public class AppSettingHelper
    {
        private readonly static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static string? GetConfig(string sectionName)
        {
            return builder.Build().GetSection(sectionName).ToString();
        }
    }
}
