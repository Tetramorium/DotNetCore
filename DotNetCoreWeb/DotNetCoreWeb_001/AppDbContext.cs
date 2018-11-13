using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWeb_001
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) 
            : base(options)
        {
    
        }

        public DbSet<Customer> Customers { get; set; }
    }
}