using System.ComponentModel.DataAnnotations;
using MicroShop.Enums.Permission;
using MicroShop.Model.Web;

namespace MicroShop.Model.Permission
{
    /// <summary>
    /// 查询系统用户操作日志
    /// </summary>
    [System.Serializable]
    public class QuerySystemUserActionDTO : PageRequestDTO
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(30, ErrorMessage = "用户名最多30个字")]
        public string UserName { get; set; }

        /// <summary>
        /// 其他关键词
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 访问ip地址
        /// </summary>
        public string RemoteIp { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public ActionTypeEnum? ActionType { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "起始日期格式错误")]
        public string StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "结束日期格式错误")]
        public string EndDate { get; set; }

    }
}
