using System;
using System.ComponentModel;

namespace MicroShop.Model.Product
{
    /// <summary>
    /// 品牌视图
    /// </summary>
    [Serializable]
    public class BrandDTO
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        [Description("品牌编号，自增编号")]
        [DisplayName("品牌编号")]
        public Int32 BrandId { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [Description("品牌名称，最多30个字")]
        [DisplayName("品牌名称")]
        public String BrandName { get; set; }
    }
}
