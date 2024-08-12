using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MicroShop.Common.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class StringHelper
    {
        #region public static string GetGuid()
        /// <summary>
        /// 获取系统的GUID字符串
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
        #endregion public static string GetGuid()

        #region public static string GetRandNum(int length)
        /// <summary>
        /// 取得随机数
        /// </summary>
        /// <param name="length">随机数的长度</param>
        /// <returns></returns>
        public static string GetRandNum(int length)
        {
            Random randNum = new Random(unchecked((int)DateTime.Now.Ticks));
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(randNum.Next(0, 9));
            }
            return sb.ToString();
        }
        #endregion

        #region public static bool IsVehicleNumber(string vehicleNumber)
        /// <summary>
        /// 正则表达式验证车牌号,新能源车牌号
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns></returns>
        public static bool IsVehicleNumber(string vehicleNumber)
        {
            string carnumRegex = "([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}(([0-9]{5}[DF])|([DF]([A-HJ-NP-Z0-9])[0-9]{4})))|([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-HJ-NP-Z0-9]{4}[A-HJ-NP-Z0-9学警港澳]{1})";
            return Regex.IsMatch(vehicleNumber, carnumRegex); 
        }
        #endregion public static bool IsVehicleNumber(string vehicleNumber)
    }
}
