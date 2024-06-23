using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Product.Model
{
    /// <summary>
    /// 创建产品分类
    /// </summary>
    [Serializable]
    public class s
    {
        /// <summary>
        /// 目录名称
        /// </summary>
        [DefaultValue("食品")]
        [Description("目录名称")]
        [Required(ErrorMessage = "分类名称必须填写")]
        [StringLength(30, ErrorMessage = "分类名称最多30个字")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 分类类型：1-商品
        /// </summary>
        [Required(ErrorMessage = "请选择一个分类类型")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择一个分类类型")]
        [Description("分类类型")]
        public int CategoryType { get; set; } = 1;

        /// <summary>
        /// 上级编号
        /// </summary>        
        [DefaultValue(0)]
        [Description("上级编号")]
        [Range(0, int.MaxValue, ErrorMessage = "上级编号格式错误")]
        public int ParentId { get; set; }

        /// <summary>
        /// 缩略图地址
        /// </summary>
        [Description("缩略图地址")]
        [DefaultValue("")]
        [StringLength(250, ErrorMessage = "缩略图地址最多250个字")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// ICON图地址
        /// </summary>
        [Description("ICON图地址")]
        [DefaultValue("")]
        [StringLength(250, ErrorMessage = "ICON图地址最多250个字")]
        public string IconUrl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        [DefaultValue("")]
        [StringLength(250, ErrorMessage = "备注最多250个字")]
        public string Note { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Description("排序值")]
        [DefaultValue(1)]
        public int? OrderValue { get; set; }

        #region public void InitData()
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (!string.IsNullOrEmpty(CategoryName))
            {
                CategoryName = CategoryName.Trim();
            }
            else
            {
                CategoryName = "";
            }

            if (!string.IsNullOrEmpty(ImageUrl))
            {
                ImageUrl = ImageUrl.Trim();
            }
            else
            {
                ImageUrl = "";
            }

            if (!string.IsNullOrEmpty(IconUrl))
            {
                IconUrl = IconUrl.Trim();
            }
            else
            {
                IconUrl = "";
            }

            if (!string.IsNullOrEmpty(Note))
            {
                Note = Note.Trim();
            }
            else
            {
                Note = "";
            }

            if (!OrderValue.HasValue)
            {
                OrderValue = 1;
            }
        }
        #endregion public void InitData()

    }
}
