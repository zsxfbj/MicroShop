using System;
using System.ComponentModel.DataAnnotations;
using MicroShop.Web.Common;

namespace MicroShop.Permission.Model
{
    /// <summary>
    /// /
    /// </summary>
    [Serializable]
    public class QuerySystemUserDTO : PageRequestDTO
    {
        /// <summary>
        /// 关键词（登录账号或者姓名）
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DataType(DataType.PhoneNumber, ErrorMessage = "手机号格式错误")]
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [DataType(DataType.EmailAddress, ErrorMessage = "电子邮箱格式错误")]
        public string Email { get; set; }

        /// <summary>
        /// 初始化参数
        /// </summary>
        public new void InitData()
        {
            base.InitData();
            if (!string.IsNullOrEmpty(Keyword))
            {
                Keyword = Keyword.Trim();
            }
            if (!string.IsNullOrEmpty(Mobile))
            {
                Mobile = Mobile.Trim();
            }
            if (!string.IsNullOrEmpty(Email))
            {
                Email = Email.Trim();
            }
        }
    }
}
