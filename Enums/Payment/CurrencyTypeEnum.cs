using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Payment
{
    /// <summary>
    /// 货币类型枚举
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
        [EnumMember(Value = "10")]
        KRW = 10,

        /// <summary>
        /// 日元
        /// </summary>
        [Description("日元")]
        [EnumMember(Value = "20")]
        JPY = 20,

        /// <summary>
        /// 纽币
        /// </summary>
        [Description("纽币")]
        [EnumMember(Value = "30")]
        NZD = 30,

        /// <summary>
        /// 美元
        /// </summary>
        [Description("美元")]
        [EnumMember(Value = "90")]
        USD = 90
    }
}
