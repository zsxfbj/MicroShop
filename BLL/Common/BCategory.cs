using MicroShop.DALFactory.Common;
using MicroShop.IDAL.Common;
using MicroShop.Model.DTO.Common;
using MicroShop.Model.VO.Common;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Common
{
    /// <summary>
    /// 分类的业务逻辑类
    /// </summary>
    public class BCategory : Singleton<BCategory>
    {
        /// <summary>
        /// 数据访问工厂
        /// </summary>
        private readonly static ICategory dal = CategoryFactory.Create();

        /// <summary>
        /// 缓存Key
        /// </summary>
        private const string CACHE_KEY = "category-";
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CategoryVO Create(CreateCategoryReqDTO req)
        {            
            CategoryVO category = dal.Create(req);

            //缓存
            RedisClient.SetAdd(CACHE_KEY + category.CategoryId, System.Text.Json.JsonSerializer.Serialize(category));
           
            return category;
        }         
    }
}
