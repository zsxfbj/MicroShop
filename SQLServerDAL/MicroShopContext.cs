using MicroShop.Entity.Common;
using MicroShop.Entity.Permission;
using MicroShop.Entity.Mall;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MicroShop.SQLServerDAL
{
    /// <summary>
    /// 数据库虚拟类
    /// </summary>
    public class MicroShopContext : DbContext
    {
        /// <summary>
        /// 重载读取配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");              

                optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("CONNECTION_STRING_NON_DTC"));

                //允许打开SQL日志
                if (builder.Build().GetSection("debug").Equals("true"))
                {
                    optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug).EnableDetailedErrors();
                }
            }
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMenuRelation>().HasKey(t => new { t.RoleId, t.MenuId });
        }

        #region Permission部分的表
        /// <summary>
        /// 菜单表
        /// </summary>
        public DbSet<Menu> Menus { get; set; } = default!;

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Role> Roles { get; set; } = default!;

        /// <summary>
        /// 系统用户表
        /// </summary>
        public DbSet<SystemUser> SystemUsers { get; set; } = default!;

        /// <summary>
        /// 角色菜单关系
        /// </summary>
        public DbSet<RoleMenuRelation> RoleMenuRelations { get; set; } = default!;

        /// <summary>
        /// 系统人员操作日志表
        /// </summary>
        public DbSet<SystemUserActionLog> SystemUserActionLogs { get; set; } = default!;

        #endregion Permission部分的表

        /// <summary>
        /// 品牌表
        /// </summary>
        public DbSet<Brand> Brands { get; set; } = default!;

        /// <summary>
        /// 分类表
        /// </summary>
        public DbSet<Category> Categories { get; set; } = default!;

        /// <summary>
        /// 产品主表
        /// </summary>
        public DbSet<Product> Products { get; set; } = default!;

        /// <summary>
        /// 产品轮播图
        /// </summary>
        public DbSet<ProductCarousel> ProductCarousels { get; set; } = default!;
    }
}
