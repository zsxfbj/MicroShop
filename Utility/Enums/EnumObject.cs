
namespace MicroShop.Utility.Enums
{
    /// <summary>
    /// 枚举、类型的值
    /// 备注：网上看到的示例，暂时没使用
    /// </summary>
    public struct EnumObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="um"></param>       
        public EnumObject(Enum um)
        {
            Id = (int)Convert.ChangeType(um, typeof(int));
            Name = um.ToString();
            Description = um.GetDescription();          
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public EnumObject(int id, string name)
        {
            Id = id;
            Name = Description = name;          
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public EnumObject(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;            
        }

        /// <summary>
        /// 枚举的数值
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 枚举的Key值
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 枚举的描述值
        /// </summary>
        public string Description { get; private set; }
      
    }
}
