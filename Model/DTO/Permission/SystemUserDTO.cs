using MicroShop.Enums.Permission;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 系统用户视图
    /// </summary>
    [Serializable]
    public class SystemUserDTO
    {
        /// <summary>
        /// 系统用户编号
        /// </summary>
        public int UserId { get; set; } = 0;

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; } = 0;
                
        /// <summary>
        /// 登录名
        /// </summary>         
        public string LoginName { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>    
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 是否管理员
        /// </summary>       
        public bool IsAdmin { get; set; } = false;

        /// <summary>
        /// 登录状态
        /// </summary>
        public LoginStatusEnum LoginStatus { get; set; } = LoginStatusEnum.Forbidden;

        /// <summary>
        /// 登录次数
        /// </summary>        
        public int LoginCount { get; set; } = 0;

        /// <summary>
        /// 密钥加的盐，Json序列化不输出
        /// </summary>
        public string Salt { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword { get; set; } = string.Empty;

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 电子邮箱
        public string Email { get; set; } = string.Empty;
              
        /// <summary>
        /// 最近登录时间
        /// </summary>
        public string LastLogin { get; set; } = string.Empty;

    }
}
