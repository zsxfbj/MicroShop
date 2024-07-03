using MicroShop.Enums.Web;

namespace MicroShop.Model.Auth
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
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; } = 0;

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }   = false;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; } = string.Empty;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 最新的缓存时间
        /// </summary>
        public string CacheTime {  get; set; } = string.Empty;
    }
}
