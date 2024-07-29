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
        public int Id { get; set; } = 0;

        /// <summary>
        /// 类型编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; } = true;
    }
}
