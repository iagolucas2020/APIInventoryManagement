using APIInventoryManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace APICarRegistration.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Merchandise> Merchandises { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
