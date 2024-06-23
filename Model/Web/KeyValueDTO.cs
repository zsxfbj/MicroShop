using System.Diagnostics.CodeAnalysis;

namespace MicroShop.Model.Web
{
    /// <summary>
    /// 键值对
    /// </summary>
    [Serializable]
    public class KeyValueDTO<T>
    {
        /// <summary>
        /// 键名
        /// </summary>
        public T Key { get; set; }

        /// <summary>
        /// 键值
        /// </summary>       
        public string Value { get; set; }


    }
}
