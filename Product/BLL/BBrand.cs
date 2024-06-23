using MicroShop.Product.Entity;
using MicroShop.Product.Model;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.Product.BLL
{
    /// <summary>
    /// 产品品牌业务逻辑类
    /// </summary>
    public class BBrand : Singleton<BBrand>
    {
        /// <summary>
        /// 品牌的缓存Key头部
        /// </summary>
        private const string ProductBrandCacheKey = "ProductBrand-";

        #region public ProductBrandDTO? GetProductBrand(int brandId)
        /// <summary>
        /// 获取品牌详情
        /// </summary>
        /// <param name="brandId">品牌编号</param>
        /// <returns></returns>
        public ProductBrandDTO? GetProductBrand(int brandId)
        {
            if (brandId == 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.RequestParameterError, ErrorMessage = "品牌编号格式错误" };
            }
            string cacheKey = GetCacheKey(brandId);

            ProductBrandDTO? productBrand = null;
            if (RedisClient.KeyExists(cacheKey))
            {
                productBrand = RedisClient.StringGet<ProductBrandDTO>(cacheKey);
            }
            if (productBrand == null)
            {
                using var context = new ProductContext();

                BrandPO? po = context.Brands.FirstOrDefault(x => x.BrandId == brandId);
                if (po == null)
                {
                    po = new BrandPO { BrandId = brandId, BrandName = "", CreatedAt = DateTime.Now, Description = "", BrandEnglishName = "", IsRecommend = false, LogoUrl = "", Prefix = "", UpdatedAt = DateTime.Now };
                    productBrand = GetProductBrandDTO(po);
                    RedisClient.StringSet(cacheKey, productBrand, TimeSpan.FromMinutes(10));
                }
                else
                {
                    productBrand = GetProductBrandDTO(po);
                    RedisClient.StringSet(cacheKey, productBrand, TimeSpan.FromDays(30));
                }
            }
            return productBrand;
        }
        #endregion public ProductBrandDTO? GetProductBrand(int brandId)

        #region public ProductBrandDTO Create(CreateProductBrandDTO createProductBrand)
        /// <summary>
        /// 新增品牌信息
        /// </summary>
        /// <param name="createProductBrand">创建品牌的请求</param>   
        /// <returns></returns>
        public ProductBrandDTO Create(CreateProductBrandDTO createProductBrand)
        {
            //数据清洗
            createProductBrand.InitData();
            using var context = new ProductContext();
            if (context.Brands.Where(x => x.BrandName == createProductBrand.BrandName.Trim()).Count() > 0)
            {
                throw new ServiceException { ErrorCode = RequestResultCodeEnum.BrandNameIsExist, ErrorMessage = "该品牌名已存在" };
            }

            BrandPO po = new BrandPO
            {
                BrandEnglishName = createProductBrand.BrandEnglishName,
                BrandName = createProductBrand.BrandName,
                Prefix = createProductBrand.Prefix,
                CreatedAt = DateTime.Now,
                Description = createProductBrand.Description,
                IsRecommend = createProductBrand.IsRecommend == 1 ? true : false,
                LogoUrl = string.IsNullOrEmpty(createProductBrand.LogoUrl) ? "" : BCommon.GetInstance().GetImageDomain() + createProductBrand.LogoUrl,
                UpdatedAt = DateTime.Now
            };
            context.Brands.Add(po);
            ProductBrandDTO productBrand = GetProductBrandDTO(po);
            RedisClient.StringSet(GetCacheKey(po.BrandId), productBrand, TimeSpan.FromDays(30));
            return productBrand;
        }
        #endregion public ProductBrandDTO Create(CreateProductBrandDTO createProductBrand)

        #region private static string GetCacheKey(int brandId)
        /// <summary>
        /// 获取缓存的Key
        /// </summary>
        /// <param name="brandId">品牌编号</param>
        /// <returns></returns>
        private static string GetCacheKey(int brandId)
        {
            return ProductBrandCacheKey + brandId.ToString();
        }
        #endregion private static string GetCacheKey(int brandId)

        #region private static ProductBrandDTO GetProductBrandDTO(BrandPO po)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        private static ProductBrandDTO GetProductBrandDTO(BrandPO po)
        {
            return new ProductBrandDTO
            {
                BrandId = po.BrandId,
                BrandName = po.BrandName.Trim(),
                BrandEnglishName = po.BrandEnglishName.Trim(),
                IsRecommend = po.IsRecommend ? 1 :0,
                LogoUrl = string.IsNullOrEmpty(po.LogoUrl) ? "" : po.LogoUrl.Trim(),
                Prefix = po.Prefix.Trim(),
                UpdatedAt = DateTime.Now,
                Description = string.IsNullOrEmpty(po.Description) ? "" : po.Description.Trim(),
                CreatedAt = DateTime.Now
            };
        }
        #endregion private static ProductBrandDTO GetProductBrandDTO(BrandPO po)

        #region public PageResultDTO<ProductBrandDTO> GetPagedProductBrand(QueryProductBrandDTO queryProductBrand)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryProductBrand"></param>
        /// <returns></returns>
        public PageResultDTO<ProductBrandDTO> GetPagedProductBrand(QueryProductBrandDTO queryProductBrand)
        {
            //初始化数据
            queryProductBrand.InitData();

            var pageResult = new PageResultDTO<ProductBrandDTO>()
            {
                Data = new List<ProductBrandDTO>(),
                PageIndex = queryProductBrand.PageIndex.HasValue ? queryProductBrand.PageIndex.Value : 1,
                PageSize = queryProductBrand.PageSize.HasValue ? queryProductBrand.PageSize.Value : 10,
                RecordCount = 0L
            };

            using var context = new ProductContext();

            var query = context.Brands.Where(x=> x.BrandId>0);


            if (!string.IsNullOrEmpty(queryProductBrand.Keyword))
            {
                query = query.Where(x => x.BrandName.Contains(queryProductBrand.Keyword));               
            }

            if (!string.IsNullOrEmpty(queryProductBrand.Prefix))
            {
                query = query.Where(x => x.Prefix == queryProductBrand.Prefix);
            }

            if (queryProductBrand.IsRecommend.HasValue)
            {
                if(queryProductBrand.IsRecommend.Value == 0)
                {
                    query = query.Where(x=>x.IsRecommend == false);
                }
                else
                {
                    query = query.Where(x => x.IsRecommend == true);
                }
            }
            
            pageResult.RecordCount = query.Count();
            pageResult.Data = query.OrderBy(x => x.Prefix).ThenBy(x=>x.BrandName).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => GetProductBrandDTO(entity)).ToList();
            return pageResult;
        }
        #endregion public PageResultDTO<ProductBrandDTO> GetPagedProductBrand(QueryProductBrandDTO queryProductBrand)

    }
}
