using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Product.Enums
{
    /// <summary>
    /// 产品类型枚举
    /// </summary>
    public enum ProductTypeEnum
    {
        /// <summary>
        /// 商品
        /// </summary>
        [Description("实物")]
        [EnumMember(Value = "10")]
        Item = 10,

        /// <summary>
        /// 电子卡
        /// </summary>
        [Description("电子卡")]
        [EnumMember(Value = "20")]
        Card = 20,

        /// <summary>
        /// 服务
        /// </summary>
        [Description("服务")]
        [EnumMember(Value = "30")]
        Service = 30
    }
}
