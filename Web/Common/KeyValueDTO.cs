namespace MicroShop.Web.Common
{
    /// <summary>
    /// 键值对
    /// </summary>
    [Serializable]
    public class KeyValueDTO
    {
        /// <summary>
        /// 键名
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// 键值
        /// </summary>
        public string? Value { get; set; }
    }
}
