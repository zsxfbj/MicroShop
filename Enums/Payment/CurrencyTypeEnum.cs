using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Payment
{
    /// <summary>
    /// 货币类型
    /// </summary>
    [Serializable]
    public enum CurrencyTypeEnum
    {
        /// <summary>
        /// 人民币
        /// </summary>
        [Description("人民币")]
        [EnumMember(Value = "1")]
        RMB = 1,

        /// <summary>
        /// 韩元
        /// </summary>
        [Description("韩元")]
        [EnumMember(Value = "5")]
        KRW = 5,

        /// <summary>
        /// 日元
        /// </summary>
        [Description("日元")]
        [EnumMember(Value = "10")]
        JPY = 10,

        /// <summary>
        /// 纽币
        /// </summary>
        [Description("纽币")]
        [EnumMember(Value = "15")]
        NZD = 15,

        /// <summary>
        /// 美元
        /// </summary>
        [Description("美元")]
        [EnumMember(Value = "20")]
        USD = 20
    }
}
