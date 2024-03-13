using iQuest.VendingMachine.Entities;
using Microsoft.EntityFrameworkCore;

namespace VendingMachine.DataAccess.SqlServer
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new Product {Id = 1, ColumnId = 11, Name = "Apple", Price = 2.0f, Quantity = 1 },
                    new Product {Id = 2, ColumnId = 12, Name = "Orange", Price = 4.0f, Quantity = 7 },
                    new Product {Id = 3, ColumnId = 13, Name = "Grape", Price = 2.99f, Quantity = 12 },
                    new Product {Id = 4, ColumnId = 14, Name = "Banana", Price = 2.5f, Quantity = 10 }
                });
        }
    }
}
