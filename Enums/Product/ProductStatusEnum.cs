using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Product
{
    /// <summary>
    /// 商品状态
    /// </summary>
    [Serializable]
    public enum ProductStatusEnum
    {
        /// <summary>
        /// 草稿状态
        /// </summary>
        [Description("草稿")]
        [EnumMember(Value = "0")]
        Draft = 0,

        /// <summary>
        /// 等待上架状态
        /// </summary>
        [Description("待上架")]
        [EnumMember(Value = "100")]
        WaitingForSale = 100,

        /// <summary>
        /// 销售中
        /// </summary>
        [Description("销售中")]
        [EnumMember(Value = "200")]
        OnSale = 200,

        /// <summary>
        /// 已下架
        /// </summary>
        [Description("已下架")]
        [EnumMember(Value = "300")]
        SoldOut = 300,

        /// <summary>
        /// 已废弃
        /// </summary>
        [Description("已废弃")]
        [EnumMember(Value = "400")]
        Discarded = 400
    }
}
