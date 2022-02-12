namespace MicroShop.Web.Common
{
    /// <summary>
    /// 分页请求
    /// </summary>
    [Serializable]
    public class PageRequestDTO
    {
        /// <summary>
        /// 当前索引，默认1开始
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (!PageIndex.HasValue || PageIndex.Value < 1) { PageIndex = 1; }

            if (!PageSize.HasValue || PageSize.Value < 1) { PageSize = 10; }
        }
    }
}
