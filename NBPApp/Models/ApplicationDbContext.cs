using Microsoft.EntityFrameworkCore;

namespace NBPApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CurrencyDto> Currency { get; set; }
    }
}
