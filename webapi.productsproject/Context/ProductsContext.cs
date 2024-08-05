using Microsoft.EntityFrameworkCore;
using webapi.productsproject.Domains;

namespace webapi.productsproject.Context
{
    public class ProductsContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE07-S21; Database=products_database; user Id=sa; pwd=Senai@134; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
