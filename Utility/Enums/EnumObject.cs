
namespace MicroShop.Utility.Enums
{
    /// <summary>
    /// 枚举、类型的值
    /// </summary>
    public struct EnumObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="um"></param>       
        public EnumObject(Enum um)
        {
            this.Id = (int)Convert.ChangeType(um, typeof(int));
            this.Name = um.ToString();
            this.Description = um.GetDescription();
          
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public EnumObject(int id, string name)
        {
            this.Id = id;
            this.Name = this.Description = name;          
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public EnumObject(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;            
        }

        /// <summary>
        /// 枚举的数值
        /// </summary>
        public int Id;

        /// <summary>
        /// 枚举的Key值
        /// </summary>
        public string Name;

        /// <summary>
        /// 枚举的描述值
        /// </summary>
        public string Description;

      
    }
}
