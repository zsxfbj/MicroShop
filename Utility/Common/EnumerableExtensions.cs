using System.ComponentModel;
using System.Reflection;

namespace MicroShop.Utility.Common
{
    /// <summary>
    /// 枚举类型扩展方法
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 枚举的类型个数
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static int Count(this System.Collections.IEnumerable items)
        {
            var result = 0;

            if (items != default)
            {
                var enumerator = items.GetEnumerator();
                result = enumerator.Count();
            }

            return result;
        }

        /// <summary>
        /// 计算枚举的个数
        /// </summary>
        /// <param name="enumerator"></param>
        /// <returns></returns>
        private static int Count(this System.Collections.IEnumerator enumerator)
        {
            var result = 0;

            if (enumerator != default)
            {
                while (enumerator.MoveNext())
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source is null || !source.Any();
        }

        /// <summary>
        /// get the description of enum.value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumerationValue">enum.value</param>
        /// <returns>description of enum.value</returns>
        public static string GetDescription<TEnum>(this TEnum enumerationValue)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString()!);
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString()!;
        }

    }
}
