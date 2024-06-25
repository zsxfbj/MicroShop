using MicroShop.Model.Common.Category;
using MicroShop.Model.Web;

namespace MicroShop.IDAL.Common
{
    /// <summary>
    /// 分类接口
    /// </summary>
    public interface ICategory
    {
        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="req">新增请求</param>
        /// <returns></returns>
        CategoryDTO Create(CreateCategoryReqDTO req);

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="req">修改请求</param>
        CategoryDTO Modify(ModifyCategoryReqDTO req);

        /// <summary>
        /// 根据Id删除记录
        /// </summary>
        /// <param name="categoryId">分类Id</param>
        void Delete(int categoryId);

        /// <summary>
        /// 根据Id获取记录
        /// </summary>
        /// <param name="categoryId">分类Id</param>
        /// <returns></returns>
        CategoryDTO GetCategory(int categoryId);

        /// <summary>
        /// 根据父级Id获取可用的分类列表
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <param name="categoryType">分类类型</param>
        /// <returns></returns>
        List<CategoryDTO> GetCategories(int parentId, int? categoryType = null);

     
    }
}
