using System.ComponentModel.DataAnnotations;

namespace MicroShop.Web.Common.SystemUser
{
    /// <summary>
    /// 系统用户访问令牌
    /// </summary>
    [Serializable]
    public class SystemUserTokenDTO
    {
        /// <summary>
        /// 令牌
        /// </summary>
        [Key]
        [Required(ErrorMessage = "访问令牌不能为空")]
        public string? Token { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; } = 0;

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; } = false;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; } = string.Empty;

        /// <summary>
        /// 访问的客户端类型
        /// </summary>
        public ClientTypeEnum ClientType { get; set; }

    }
}
