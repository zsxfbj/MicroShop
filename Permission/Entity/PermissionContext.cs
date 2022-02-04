using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MicroShop.Permission.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class PermissionContext : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PermissionContext() : base() { }

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
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("PermissionDbConnString"));

                //MySQL链接
                //optionsBuilder.UseMySql(builder.Build().GetConnectionString("AutoPssDb"), ServerVersion.AutoDetect(builder.Build().GetConnectionString("AutoPssDb")));

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
            //角色表
            modelBuilder.Entity<RoleEntity>(r =>
            {
                r.Property(i => i.RoleName).IsRequired().HasMaxLength(30);
                r.Property(i => i.Note).HasDefaultValue("").HasMaxLength(255);
                r.Property(i => i.CreatedAt).HasDefaultValue(DateTime.Now);
                r.Property(i => i.UpdatedAt).HasDefaultValue(DateTime.Now);
                r.HasIndex(i => i.RoleName).IsUnique();
                r.HasData(new RoleEntity { RoleId = 1, RoleName = "系统管理员", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
            });

            //菜单表
            modelBuilder.Entity<MenuEntity>(r =>
            {
                r.Property(i => i.MenuName).IsRequired().HasMaxLength(30);
                r.Property(i => i.Note).HasDefaultValue("").HasMaxLength(255);
                r.Property(i => i.MenuUrl).HasDefaultValue("").HasMaxLength(255);
                r.Property(i => i.CreatedAt).HasDefaultValue(DateTime.Now);
                r.Property(i => i.UpdatedAt).HasDefaultValue(DateTime.Now);
                r.HasIndex(i => i.ParentId);
                r.HasIndex(i => i.OrderValue);
                r.HasData(new MenuEntity { MenuId = 1, MenuName = "工作台", OrderValue = 1, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
                r.HasData(new MenuEntity { MenuId = 2, MenuName = "商品管理", OrderValue = 2, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
                r.HasData(new MenuEntity { MenuId = 3, MenuName = "订单管理", OrderValue = 3, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
                r.HasData(new MenuEntity { MenuId = 4, MenuName = "系统设置", OrderValue = 4, ParentId = 0, MenuUrl = "", CreatedAt = DateTime.Now, Note = "", UpdatedAt = DateTime.Now });
            });


            //系统用户
            modelBuilder.Entity<SystemUserEntity>(r =>
              {
                  r.Property(i => i.LoginName).IsRequired().HasMaxLength(50);
                  r.Property(i => i.LoginPassword).IsRequired().HasMaxLength(256).HasDefaultValue("6aee2767ea6575bc7e3cf613762fd27e81768c28c1942a5258b12e2b0175bc6e");
                  r.Property(i => i.UserName).IsRequired().HasMaxLength(30).HasDefaultValue("");
                  r.Property(i => i.CreatedAt).HasDefaultValue(DateTime.Now);
                  r.Property(i => i.UpdatedAt).HasDefaultValue(DateTime.Now);
                  r.Property(i => i.LoginStatus).HasConversion<int>();
                  r.Property(i => i.LoginCount).HasDefaultValue(0);
                  r.HasIndex(i => i.LoginName).IsUnique();
                  r.HasData(new SystemUserEntity { UserId = 1, LoginName = "admin", LoginPassword = "6aee2767ea6575bc7e3cf613762fd27e81768c28c1942a5258b12e2b0175bc6e", CreatedAt = DateTime.Now, LoginCount = 0, RoleId = 1, UpdatedAt = DateTime.Now, UserName = "管理员" });
              });

            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// 系统用户
        /// </summary>
        public DbSet<SystemUserEntity> SystemUsers { get; set; }

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
