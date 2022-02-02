using System.Text.RegularExpressions;

namespace MicroShop.Utility.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 正则表达式验证车牌号,新能源车牌号
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns></returns>
        public static bool IsVehicleNumber(string vehicleNumber)
        {
            bool result = false;
            string carnumRegex = @"([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}(([0-9]{5}[DF])|([DF]([A-HJ-NP-Z0-9])[0-9]{4})))|([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-HJ-NP-Z0-9]{4}[A-HJ-NP-Z0-9学警港澳]{1})";
            result = Regex.IsMatch(vehicleNumber, carnumRegex);
            return result;
        }
    }
}
