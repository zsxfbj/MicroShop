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
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 访问的客户端类型
        /// </summary>
        public ClientTypeEnum ClientType { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemUserTokenDTO()
        {
            AccessToken = Utility.Common.StringHelper.GetGuid();
            UserId = 0;
            RoleId = 0;
            UserName = string.Empty;
            Email = string.Empty;
            Mobile = string.Empty;
            ClientType = ClientTypeEnum.PCWeb;
            IsAdmin = false;
        }

    }
}
