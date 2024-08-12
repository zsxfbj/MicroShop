namespace MicroShop.Common.Model.DTO.Permission
{
    /// <summary>
    /// 部门对象
    /// </summary>
    public class DepartmentDTO
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 上级部门编码，顶级为空字符串
        /// </summary>
        public string ParentCode { get; set; } = string.Empty;

        /// <summary>
        /// 部门编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 排序值
        /// </summary>
        public int SortValue { get; set; } = 1;

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Erp对应的编码
        /// </summary>
        public string ErpCode { get; set; } = string.Empty;

        /// <summary>
        /// Erp对应的名称
        /// </summary>
        public string ErpName { get; set; } = string.Empty;
    }
}
