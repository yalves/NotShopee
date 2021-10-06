using Microsoft.EntityFrameworkCore;
using NotShopee.Api.Entities;

namespace NotShopee.Api.Data
{
    public class StandardContext : DbContext
    {
        public StandardContext(DbContextOptions<StandardContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}