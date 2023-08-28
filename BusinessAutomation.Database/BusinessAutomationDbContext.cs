using BusinessAutomation.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BusinessAutomationApp.Database
{
    public class BusinessAutomationDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand>Brands { get; set; }
        public DbSet<Category> Categorys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-S2I66C5\\MSSQLSERVER01;Database=BusinessAutomationDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True ";
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
