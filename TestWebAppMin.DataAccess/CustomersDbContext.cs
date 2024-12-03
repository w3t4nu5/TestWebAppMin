using Microsoft.EntityFrameworkCore;
using TestWebAppMin.DataAccess.Entities;

namespace TestWebAppMin.DataAccess
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KRAFTWERK;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Database=CustomersDatabase;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
