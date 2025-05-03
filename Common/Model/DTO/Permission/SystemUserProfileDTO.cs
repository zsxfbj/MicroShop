using System;

namespace MicroShop.Model.DTO.Permission
{
    /// <summary>
    /// 系统用户扩展属性表
    /// </summary>
    [Serializable]
    public class SystemUserProfileDTO
    {
        /// <summary>
        /// 系统Id
        /// </summary>
        public long Id { get; set; } = 0L;

        /// <summary>
        /// 系统用户Id
        /// </summary>
        public int UserId { get; set; } = 0;

        /// <summary>
        /// 属性编码
        /// </summary>
        public string ProfileCode { get; set; } = string.Empty;

        /// <summary>
        /// 属性名称
        /// </summary>
        public string ProfileName {  get; set; } = string.Empty;

        /// <summary>
        /// 属性值
        /// </summary>
        public string ProfileValue { get; set; } = string.Empty;
    }
}
