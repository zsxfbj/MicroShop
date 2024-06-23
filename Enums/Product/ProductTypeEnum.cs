using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Product
{
    /// <summary>
    /// 产品类型枚举
    /// </summary>
    [Serializable]
    public enum ProductTypeEnum
    {
        /// <summary>
        /// 实物商品
        /// </summary>
        [Description("实物商品")]
        [EnumMember(Value = "100")]
        PhysicalProduct = 100,

        /// <summary>
        /// 卡密类商品
        /// </summary>
        [Description("卡密类商品")]
        [EnumMember(Value = "200")]
        CardProduct = 200,


        /// <summary>
        /// 在线充值商品
        /// </summary>
        [Description("在线充值商品")]
        [EnumMember(Value = "300")]
        RechargeProduct = 300,

        /// <summary>
        /// 服务类商品
        /// </summary>
        [Description("服务类商品")]
        [EnumMember(Value = "400")]
        ServiceProduct = 400
    }
}
