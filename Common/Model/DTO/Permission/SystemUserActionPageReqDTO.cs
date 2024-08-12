using System;
using System.ComponentModel.DataAnnotations;
using MicroShop.Common.Enum.Permission;
using MicroShop.Common.Model.DTO.Web;

namespace MicroShop.Common.Model.DTO.Permission
{
    /// <summary>
    /// 查询系统用户操作日志
    /// </summary>
    [Serializable]
    public class SystemUserActionPageReqDTO : PageRequestDTO
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(30, ErrorMessage = "用户名最多30个字")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 其他关键词
        /// </summary>
        public string Keyword { get; set; } = string.Empty;

        /// <summary>
        /// 访问ip地址
        /// </summary>
        public string RemoteIp { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        public ActionTypes? ActionType { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "起始日期格式错误")]
        public string StartDate { get; set; } = string.Empty;

        /// <summary>
        /// 结束日期
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "结束日期格式错误")]
        public string EndDate { get; set; } = string.Empty;

    }
}
