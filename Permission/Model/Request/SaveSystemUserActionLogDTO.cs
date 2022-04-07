using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Permission.Model.Request
{
    /// <summary>
    /// 保存系统用户操作日志
    /// </summary>
    [Serializable]
    public class SaveSystemUserActionLogDTO
    {
        /// <summary>
        /// 系统用户编号
        /// </summary>
        public long UserId { get; set; }
    }
}
