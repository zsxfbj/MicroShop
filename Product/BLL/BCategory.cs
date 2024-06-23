using MicroShop.Product.Entity;
using MicroShop.Product.Model;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.Product.BLL
{
    /// <summary>
    /// 产品分类业务逻辑类
    /// </summary>
    public class BCategory : Singleton<BCategory>
    {
        /// <summary>
        /// 
        /// </summary>
        private const string CategoriesCacheKey = "Product-Categories-";

        /// <summary>
        /// 
        /// </summary>
        private const string CategoryCachKey = "Product-Category-";

        #region public ProductCategoryDTO Create(CreateProductCategoryDTO createProductCategory)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createProductCategory"></param>
        /// <returns></returns>
        public ProductCategoryDTO Create(CreateProductCategoryDTO createProductCategory)
        {
            createProductCategory.InitData();

            using var context = new ProductContext();

            if (context.Categories.Where(x => x.ParentId == createProductCategory.ParentId && x.CategoryName == createProductCategory.CategoryName).Count() > 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.CategoryNameIsExist, ErrorMessage = "产品分类名称重复" };
            }

            CategoryPO? parentCategory = null;

            if (createProductCategory.ParentId > 0)
            {
                parentCategory = context.Categories.FirstOrDefault(x => x.CategoryId == createProductCategory.ParentId);
                if (parentCategory == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "上级产品分类不存在" };
                }
            }

            CategoryPO po = new CategoryPO
            {
                CategoryName = createProductCategory.CategoryName,
                CategoryId = 0,
                CreatedAt = DateTime.Now,
                FullPath = "",
                IconUrl = createProductCategory.IconUrl,
                ImageUrl = createProductCategory.ImageUrl,
                Note = createProductCategory.Note,
                OrderValue = createProductCategory.OrderValue.HasValue ? createProductCategory.OrderValue.Value : 1,
                ParentId = createProductCategory.ParentId,
                UpdatedAt = DateTime.Now

            };
            context.Categories.Add(po);
            context.SaveChanges();
            if (parentCategory != null)
            {
                po.FullPath = parentCategory.FullPath + "," + po.CategoryId.ToString();
            }
            else
            {
                po.FullPath = po.CategoryId.ToString();
            }

            context.Categories.Update(po);
            context.SaveChanges();

            ProductCategoryDTO productCategory = GetProductCategoryDTO(po);
            Cache(productCategory);

            RedisClient.KeyDelete(CategoriesCacheKey + po.ParentId);
            //输出结果
            return productCategory;
        }
        #endregion public ProductCategoryDTO Create(CreateProductCategoryDTO createProductCategory)

        #region public void Modify(ModifyProductCategoryDTO modifyProductCategory)
        /// <summary>
        /// 修改产品分类
        /// </summary>
        /// <param name="modifyProductCategory"></param>
        public void Modify(ModifyProductCategoryDTO modifyProductCategory)
        {
            modifyProductCategory.InitData();

            using var context = new ProductContext();

            if(context.Categories.Where(x=>x.ParentId == modifyProductCategory.ParentId && x.CategoryId != modifyProductCategory.CategoryId && x.CategoryName == modifyProductCategory.CategoryName).Count() > 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.CategoryNameIsExist, ErrorMessage = "产品分类名称重复" };
            }

            CategoryPO? po = context.Categories.FirstOrDefault(x => x.CategoryId == modifyProductCategory.CategoryId);
            if(po == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "产品分类记录不存在" };
            }

            CategoryPO? parentCategory = null;
            if(modifyProductCategory.ParentId > 0)
            {
                parentCategory = context.Categories.FirstOrDefault(x=>x.CategoryId == modifyProductCategory.ParentId);
                if(parentCategory == null)
                {
                    throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "上级分类记录不存在" };
                }
            }


            po.CategoryName = modifyProductCategory.CategoryName;
            po.UpdatedAt = DateTime.Now;
            po.Note = modifyProductCategory.Note;
            po.OrderValue = modifyProductCategory.OrderValue.HasValue ? modifyProductCategory.OrderValue.Value : 1;
            if(parentCategory == null)
            {
                po.FullPath = po.CategoryId.ToString();
            }
            else
            {
                po.FullPath = parentCategory.FullPath + "," + po.CategoryId;
            }
            po.ParentId = modifyProductCategory.ParentId;
            po.IconUrl = modifyProductCategory.IconUrl;
            po.ImageUrl = modifyProductCategory.ImageUrl;

            context.Categories.Update(po);
            context.SaveChanges();
            //缓存
            Cache(GetProductCategoryDTO(po));

            RedisClient.KeyDelete(CategoriesCacheKey + po.ParentId);
        }
        #endregion public void Modify(ModifyProductCategoryDTO modifyProductCategory)

        #region public ProductCategoryDTO GetProductCategory(int categoryId)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ProductCategoryDTO GetProductCategory(int categoryId)
        {
            if (categoryId < 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "产品分类编号格式错误！" };
            }
            ProductCategoryDTO? productCategory = null;
            string cacheKey = CategoryCachKey + categoryId;
            if (RedisClient.KeyExists(cacheKey))
            {
                productCategory = RedisClient.StringGet<ProductCategoryDTO>(cacheKey);
                if(productCategory != null)
                {
                    return productCategory;
                }
            }

            using var context = new ProductContext();

            CategoryPO? category = context.Categories.FirstOrDefault(x=>x.CategoryId == categoryId);
            if (category == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "产品分类记录不存在" };
            }

            productCategory = GetProductCategoryDTO(category);
            RedisClient.StringSet(cacheKey, productCategory, TimeSpan.FromDays(30));
            return productCategory;
        }
        #endregion public ProductCategoryDTO GetProductCategory(int categoryId)

        #region public void Delete(int categoryId)
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="categoryId"></param>
        public void Delete(int categoryId)
        {
            if(categoryId < 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "产品分类编号格式错误！" };
            }

            using var context = new ProductContext();

            if(context.Categories.Count(x=>x.ParentId == categoryId)> 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.HasSubCategories, ErrorMessage = "还有子分类，请先删除子分类！" };
            }

            CategoryPO? po = context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(po == null)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.NotFound, ErrorMessage = "产品分类记录不存在" };
            }

            context.Categories.Remove(po);
            context.SaveChanges();
            RedisClient.KeyDelete(CategoryCachKey + categoryId);
            RedisClient.KeyDelete(CategoriesCacheKey + po.ParentId);
        }
        #endregion public void Delete(int categoryId)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setProductCategoryOrderValue"></param>
        public void SetOrderValue(SetProductCategoryOrderValueDTO setProductCategoryOrderValue)
        {

        }

        #region public List<ProductCategoryDTO> GetProductCategories(int parentId)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<ProductCategoryDTO> GetProductCategories(int parentId)
        {
            List<ProductCategoryDTO>? result = null;
            if(parentId < 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "父级编号格式错误" };
            }

            string cacheKey = CategoriesCacheKey + parentId;

            if (RedisClient.KeyExists(cacheKey))
            {
                result = RedisClient.StringGet<List<ProductCategoryDTO>>(cacheKey);                
            }
            else
            {
                using var context = new ProductContext();
                result = context.Categories.Where(x => x.ParentId == parentId).OrderByDescending(x => x.OrderValue).Select(po => GetProductCategoryDTO(po)).ToList();
                RedisClient.StringSet(cacheKey, result, TimeSpan.FromDays(30));
            }

            if (result == null)
            {
                result = new List<ProductCategoryDTO>();
            }
            return result;
        }
        #endregion public List<ProductCategoryDTO> GetProductCategories(int parentId)

        #region private static ProductCategoryDTO GetProductCategoryDTO(CategoryPO category)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private static ProductCategoryDTO GetProductCategoryDTO(CategoryPO category)
        {
            return new ProductCategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                ParentId = category.ParentId,
                CreatedAt = category.CreatedAt,
                FullPath = category.FullPath,
                IconUrl = category.IconUrl,
                ImageUrl = category.ImageUrl,
                Note = category.Note,
                OrderValue = category.OrderValue,
                UpdatedAt = category.UpdatedAt,
            };
        }
        #endregion private static ProductCategoryDTO GetProductCategoryDTO(CategoryPO category)

        #region private static void Cache(ProductCategoryDTO productCategory)
        /// <summary>
        /// 缓存
        /// </summary>
        /// <param name="productCategory"></param>
        private static void Cache(ProductCategoryDTO productCategory)
        {            
            RedisClient.StringSet(CategoryCachKey + productCategory.CategoryId, productCategory, TimeSpan.FromDays(30));
        }
        #endregion private static void Cache(ProductCategoryDTO productCategory)
    }
}
