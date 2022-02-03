using Microsoft.EntityFrameworkCore;
using System;

namespace MicroShop.Permission.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class PermissionContext : DbContext
    {
        private readonly string connectionString;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PermissionContext() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public PermissionContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options">数据库访问选项</param>
        public PermissionContext(DbContextOptions<PermissionContext> options)
        : base(options)
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
                optionsBuilder.UseSqlServer(connectionString);
                //允许打开SQL日志              
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 模型创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>(r =>
            {
                r.HasIndex(i => i.RoleName).IsUnique();
                r.HasData(new RoleEntity { RoleId = 1, RoleName = "管理员", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
            });

            modelBuilder.Entity<MenuEntity>(r =>
            {
                r.HasIndex(i => i.ParentId);
                r.HasIndex(i => i.OrderValue);
                r.HasData(new MenuEntity { MenuId = 1, MenuName = "工作台", OrderValue = 1, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
                r.HasData(new MenuEntity { MenuId = 2, MenuName = "商品管理", OrderValue = 2, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
                r.HasData(new MenuEntity { MenuId = 3, MenuName = "订单管理", OrderValue = 3, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
                r.HasData(new MenuEntity { MenuId = 4, MenuName = "系统设置", OrderValue = 4, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });              
            });

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<RoleEntity> Roles { get; set; }

        /// <summary>
        /// 菜单表
        /// </summary>
        public DbSet<MenuEntity> Menus { get; set; }

    }
}
