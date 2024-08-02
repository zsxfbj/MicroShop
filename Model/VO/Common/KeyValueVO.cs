using System;

namespace MicroShop.Model.VO.Common
{
    /// <summary>
    /// 键值对
    /// </summary>
    [Serializable]
    public class KeyValueVO<T>
    {
        /// <summary>
        /// 键名
        /// </summary>
        public T Key { get; set; } = default(T)!;

        /// <summary>
        /// 键值
        /// </summary>       
        public string Value { get; set; } = string.Empty;

    }
}
