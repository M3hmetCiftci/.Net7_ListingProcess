using listing_process.Web.Models.ModelView;
using Microsoft.EntityFrameworkCore;

namespace listing_process.Web.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
    }
}
