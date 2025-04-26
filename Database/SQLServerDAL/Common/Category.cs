using MicroShop.Database.IDAL.Common;
using MicroShop.Common.Model.Common.Exception;
using MicroShop.Common.Model.DTO.Common;
using MicroShop.Common.Model.VO.Common;
using MicroShop.Common.Enum.Web;
using MicroShop.Common.Enum;
using MicroShop.Enum.Common;

namespace MicroShop.Database.SQLServerDAL.Common
{
    /// <summary>
    /// SQLServer的分类管理
    /// </summary>
    public class Category : ICategory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public CategoryVO Create(CreateCategoryReqDTO req)
        {
            Category category = new Category();
            ToEntity(req, category);
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;

            using (var context = new MicroShopContext())
            {
                if (category.ParentId == 0)
                {
                    category.FullPath = "0";
                }
                else
                {
                    Category? parent = context.Categories.FirstOrDefault(x => x.CategoryId == category.ParentId);
                    if (parent == null)
                    {
                        throw new ServiceException { ErrorCode = RequestResultCodes.NotFound, ErrorMessage = "上级分类记录未查询到" };
                    }

                    category.FullPath = parent.FullPath + ";" + category.ParentId;
                }
                context.Categories.Add(category);
                context.SaveChanges();
            }
            return ToDTO(category);
        }

        public void Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<CategoryVO> GetCategories(int parentId, int? categoryType = null)
        {
            throw new NotImplementedException();
        }

        public CategoryVO GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public CategoryVO Modify(ModifyCategoryReqDTO req)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private CategoryVO ToDTO(Category entity)
        {
            CategoryVO category = new CategoryVO
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                ParentId = entity.ParentId,
                FullPath = entity.FullPath,
                CategoryType = entity.CategoryType,
                CategoryTypeName = ((CategoryTypes)entity.CategoryType).GetDescription(),
                Note = entity.Note,
                ImageUrl = entity.ImageUrl,
                IconUrl = entity.IconUrl,
                OrderValue = entity.OrderValue,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };

            return category;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="category"></param>
        private void ToEntity(CreateCategoryReqDTO req, Category category)
        {
            category.CategoryName = string.IsNullOrEmpty(req.CategoryName) ? "" : req.CategoryName.Trim();
            category.CategoryType = req.CategoryType;
            category.ParentId = req.ParentId;
            category.OrderValue = req.OrderValue.HasValue ? req.OrderValue.Value : 1;
            category.IconUrl = string.IsNullOrEmpty(req.IconUrl) ? "" : req.IconUrl.Trim();
            category.Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim();
            category.ImageUrl = string.IsNullOrEmpty(req.ImageUrl) ? "" : req.ImageUrl.Trim();
        }
    }
}
