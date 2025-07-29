using Microsoft.EntityFrameworkCore;
using Sandhata.eCommerce.Models;

namespace Sandhata.eCommerce.Repositories
{
    public class SandhataDbContext:DbContext
    {
        public SandhataDbContext()
        {
            
        }
        public SandhataDbContext(DbContextOptions<SandhataDbContext>options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }     
        public DbSet<Product> Products {  get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer
                    (@"Server=(localdb)\MSSQLLocalDB;Database=SandhataEComDb;Trusted_Connection=true;TrustServerCertificate=True;");
            }
        }

    }
}
