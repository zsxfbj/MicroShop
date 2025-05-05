using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroShop.SQLServerDAL.Common
{
    /// <summary>
    /// 分类表
    /// </summary>
    [Table("t_category")]   
    public class CategoryPO
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("分类Id")]
        public long Id { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        [Column("category_code", TypeName = "nvarchar(64)"), MaxLength(60, ErrorMessage = "分类编码字数不能超过60个"), Required, Description("分类编码")]
        public string CategoryCode { get; set; } = string.Empty;

        /// <summary>
        /// 分类名称
        /// </summary>
        [Column("category_name", TypeName = "nvarchar(64)"), MaxLength(60, ErrorMessage = "分类名称字数不能超过60个"), Required, Description("分类名称")]
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// 分类类型
        /// </summary>
        [Column("category_type", TypeName = "int"), Description("分类类型")]
        public int CategoryType { get; set; } = 1;

        /// <summary>
        /// 父级分类Id
        /// </summary>
        [Column("parent_id", TypeName = "bigint"), Description("父级分类Id")]
        public long ParentId { get; set; } = 0L;

        /// <summary>
        /// 级别全路径
        /// </summary>
        [Column("full_path", TypeName = "varchar(256)"), MaxLength(256, ErrorMessage = "级别全路径不能超过256个字符"), Description("级别全路径")]
        public string FullPath { get; set; } = string.Empty;

        /// <summary>
        /// 缩略图地址
        /// </summary> 
        [Column("image_url", TypeName = "varchar(256)"), MaxLength(256, ErrorMessage = "缩略图地址不能超过256个字符"), Description("缩略图地址")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// ICON图地址
        /// </summary>
        [Column("icon_url", TypeName = "varchar(256)"), MaxLength(256, ErrorMessage = "ICON图地址不能超过256个字符"), Description("ICON图地址")]
        public string IconUrl { get; set; } = string.Empty;

    }
}
