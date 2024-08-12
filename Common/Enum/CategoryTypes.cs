using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Common.Enum
{
    /// <summary>
    /// 分类类型枚举
    /// </summary> 
    public enum CategoryTypes
    {
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        [EnumMember(Value = "1")]
        Product = 1,

        /// <summary>
        /// 文章
        /// </summary>
        [Description("文章")]
        [EnumMember(Value = "10")]
        Article = 10
    }
}
