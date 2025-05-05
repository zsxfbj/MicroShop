/*********************************************************************************
 * 版权所有 (C) 2024 ShengXiongFeng
 * 
 * 文件名：SysDictTypeDTO.cs
 * 作者：ShengXiongFeng
 * 创建日期：2024-06-23
 * 最后修改：2025-05-02
 * 描述：系统字典类型视图
 *
 *********************************************************************************/


using System.ComponentModel;

namespace MicroShop.Model.DTO.System
{
    /// <summary>
    /// 系统字典类型
    /// </summary>
    public class SysDictTypeDTO
    {
        /// <summary>
        /// 自增Id
        /// </summary>
        [Description("自增Id")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// 类型编码
        /// </summary>
        [Description("类型编码")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 类型名称
        /// </summary>
        [Description("类型名称")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public bool IsEnable { get; set; } = true;
    }
}
