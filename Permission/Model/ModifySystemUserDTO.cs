using System;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Permission.Model
{
    /// <summary>
    /// 修改系统用户请求
    /// </summary>
    [Serializable]
    public class ModifySystemUserDTO : CreateSystemUserDTO
    {
        /// <summary>
        /// 系统用户编号
        /// </summary>
        [Required(ErrorMessage = "系统用户编号不能为空")]
        [Range(1, int.MaxValue, ErrorMessage = "请指定要修改的系统用户")]
        public int UserId { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ModifySystemUserDTO() : base()
        {
           UserId = 0;
        }        
    }
}
