using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Model.DTO.Web
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
        [Range(1, int.MaxValue, ErrorMessage = "页面索引从1开始")]
        [DefaultValue(1)]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页记录数
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "每页记录数不能少于1")]
        [DefaultValue(15)]
        public int PageSize { get; set; } = 15;

        #region public virtual void InitData()
        /// <summary>
        /// 初始化数据
        /// </summary>
        public virtual void InitData()
        {
            if (PageIndex < 1) { PageIndex = 1; }

            if ( PageSize < 1) { PageSize = 15; }
        }
        #endregion public virtual void InitData()
    }
}
