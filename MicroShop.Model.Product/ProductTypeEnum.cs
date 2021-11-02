using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Model.Product
{
    /// <summary>
    /// 产品类型枚举
    /// </summary>
    public enum ProductTypeEnum
    {
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        [EnumMember(Value = "1")]
        Item = 1,

        /// <summary>
        /// 电子卡
        /// </summary>
        [Description("电子卡")]
        [EnumMember(Value = "2")]
        Card = 2,

        /// <summary>
        /// 服务
        /// </summary>
        [Description("服务")]
        [EnumMember(Value = "3")]
        Service = 3
    }
}
