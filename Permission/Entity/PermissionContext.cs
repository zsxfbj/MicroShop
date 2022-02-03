using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
                optionsBuilder.LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);


        }

        /// <summary>
        /// 模型创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<RoleEntity> Roles { get; set; }

    }
}
