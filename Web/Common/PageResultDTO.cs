using MicroShop.Utility.Serialize.Json;
using Newtonsoft.Json;

namespace MicroShop.Web.Common
{
    /// <summary>
    /// 分页查询结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class PageResultDTO<T>
    {
        /// <summary>
        /// 具体列表数据
        /// </summary>
        public List<T>? Data { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long RecordCount { get; set; }

        /// <summary>
        /// 当前页面记录数
        /// </summary>
        [JsonConverter(typeof(LongToStringConverter))]
        public long CurrentCount
        {
            get
            {
                if (Data != null)
                {
                    return Data.Count;
                }
                return 0;
            }
        }

    }
}
