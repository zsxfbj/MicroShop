using System.Collections.Generic;
using MicroShop.Model.VO.Common;
using MicroShop.Model.DTO.Common;

namespace MicroShop.IDAL.Common
{
    /// <summary>
    /// 分类接口
    /// </summary>
    public interface ICategoryDAL
    {
        /// <summary>
        /// 创建分类记录
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        long Create(CategoryVO category);

        /// <summary>
        /// 修改分类记录
        /// </summary>
        /// <param name="category"></param>
        void Modify(CategoryVO category);


        /// <summary>
        /// 删除分类记录
        /// </summary>
        /// <param name="categoryId">分类Id</param>
        void Delete(long categoryId);


    }
}
