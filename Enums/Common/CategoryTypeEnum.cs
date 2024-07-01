using System.ComponentModel;
using System.Runtime.Serialization;

namespace MicroShop.Enums.Common
{
    /// <summary>
    /// 分类类型枚举
    /// </summary>
    [Serializable]
    public enum CategoryTypeEnum
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
