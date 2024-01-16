using iQuest.VendingMachine.Entities;
using Microsoft.EntityFrameworkCore;

namespace VendingMachine.DataAccess.SqlServer
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
