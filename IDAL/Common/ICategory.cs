﻿using MicroShop.Model.DTO.Common;
using MicroShop.Model.VO.Common;

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
        CategoryVO Create(CreateCategoryReqDTO req);

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="req">修改请求</param>
        CategoryVO Modify(ModifyCategoryReqDTO req);

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
        CategoryVO GetCategory(int categoryId);

        /// <summary>
        /// 根据父级Id获取可用的分类列表
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <param name="categoryType">分类类型</param>
        /// <returns></returns>
        List<CategoryVO> GetCategories(int parentId, int? categoryType = null);

     
    }
}
