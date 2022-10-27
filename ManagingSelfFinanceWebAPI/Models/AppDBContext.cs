using Microsoft.EntityFrameworkCore;

namespace ManagingSelfFinanceWebAPI.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<TypeOperation> TypeOperations { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<RegisterOperation> RegisterOperations { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
