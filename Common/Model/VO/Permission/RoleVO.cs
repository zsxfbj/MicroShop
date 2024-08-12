/*********************************************************************************
 * 版权所有 (C) 2024 ShengXiongFeng
 * 
 * 文件名：RoleDTO.cs
 * 作者：ShengXiongFeng
 * 创建日期：2024-06-23
 * 最后修改：2023-02-02
 * 描述：角色数据视图
 *
 *********************************************************************************/

using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using MicroShop.Common.Model.Serialize.Json;

namespace MicroShop.Common.Model.VO.Permission
{
    /// <summary>
    /// 角色数据视图
    /// </summary>
    [Serializable]
    public class RoleVO
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Description("角色编号")]
        [JsonConverter(typeof(LongToStringConverter))]
        public long RoleId { get; set; } = 0L;

        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 是否可用
        /// </summary>
        [Description("是否可用")]
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        [Description("创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonConverter(typeof(DefaultDateTimeConverter))]
        [Description("更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
