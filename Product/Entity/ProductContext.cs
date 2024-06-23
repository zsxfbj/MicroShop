using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MicroShop.Product.Entity
{
    /// <summary>
    /// 产品库
    /// </summary>
    public class ProductContext : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProductContext() : base() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options">数据库访问选项</param>
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        /// <summary>
        /// 重载读取配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("ProductDb"));

                //允许打开SQL日志              
                //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 模型创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //品牌表
            modelBuilder.Entity<BrandPO>(r =>
            {
                r.Property(i => i.BrandName).IsRequired().HasMaxLength(30);
                r.Property(i => i.CreatedAt).HasDefaultValue(DateTime.Now);
                r.Property(i => i.UpdatedAt).HasDefaultValue(DateTime.Now);
                r.HasIndex(i => i.BrandName).IsUnique();
            });

            //产品表
            modelBuilder.Entity<ProductPO>(r =>
            {
                r.Property(i => i.ProductType).HasConversion<int>();
                r.Property(i => i.CurrencyType).HasConversion<int>();
                r.Property(i => i.ProductStatus).HasConversion<int>();
                r.Property(i => i.CreatedAt).HasDefaultValue(DateTime.Now);
                r.Property(i => i.UpdatedAt).HasDefaultValue(DateTime.Now);
                r.HasIndex(i => i.ProductName);
            });

            //产品轮播图表
            modelBuilder.Entity<ProductCarouselPO>(p =>
            {
                p.Property(i => i.MediaType).HasConversion<int>();
                p.HasIndex(i => i.ProductId);
            });

            //产品表
            modelBuilder.Entity<ProductSpecDetailPO>(r =>
            {                 
                r.HasIndex(i => i.ProductId);
            });

            //产品SKU名称表
            modelBuilder.Entity<ProductSpecPO>(r =>
            {               
                r.HasIndex(i => i.ProductId);
            });

            //产品SKU名称对应的值表
            modelBuilder.Entity<ProductSpecOptionPO>(r =>
            {
                r.HasIndex(i => i.ProductId);
                r.HasIndex(i => i.SpecId);
            });

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 品牌表
        /// </summary>
        public DbSet<BrandPO> Brands { get; set; }

        /// <summary>
        /// 产品目录
        /// </summary>
        public DbSet<CategoryPO> Categories { get; set; }

        /// <summary>
        /// 产品表
        /// </summary>
        public DbSet<ProductPO> Products { get; set; }

        /// <summary>
        /// 产品规格名称
        /// </summary>
        public DbSet<ProductSpecPO> ProductSpecs { get; set; }

        /// <summary>
        /// 产品单位值
        /// </summary>
        public DbSet<ProductSpecOptionPO> ProductSpecOptions { get; set; }

        /// <summary>
        /// 产品轮播资料
        /// </summary>
        public DbSet<ProductCarouselPO> ProductCarousels { get; set; }

        /// <summary>
        /// 产品SKU配置表
        /// </summary>
        public DbSet<ProductSpecDetailPO> ProductSpecDetails { get; set; }

        /// <summary>
        /// 产品模板表
        /// </summary>
        public DbSet<ProductTemplatePO> ProductTemplates { get; set; }

    }
}
