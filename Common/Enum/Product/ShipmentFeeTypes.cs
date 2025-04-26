using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Product
{
    /// <summary>
    /// 运费类型
    /// </summary>    
    public enum ShipmentFeeTypes
    {
        /// <summary>
        /// 按重量
        /// </summary>
        [Description("按重量")]
        [EnumMember(Value = "100")]
        ByWeight = 100,

        /// <summary>
        /// 按体积
        /// </summary>
        [Description("按体积")]
        [EnumMember(Value = "200")]
        ByVolume = 200
    }
}
