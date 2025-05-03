namespace MicroShop.Model.Base
{
    /// <summary>
    /// 泛型键值对对象
    /// </summary>
    /// <typeparam name="T">泛型键</typeparam>
    /// <typeparam name="S">泛型值</typeparam>
    public class KeyValue<T, S>
    {
        /// <summary>
        /// 键
        /// </summary>
        public T Key { get; set; } = default!;

        /// <summary>
        /// 值
        /// </summary>
        public S Value { get; set; } = default!;
    }
}
