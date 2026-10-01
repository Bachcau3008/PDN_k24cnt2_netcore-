using Microsoft.EntityFrameworkCore;
using PdnLesson12.Models;

namespace PdnLesson12.PdnEntities
{
    public class PdnAppDbContext : DbContext
    {
        public PdnAppDbContext(DbContextOptions<PdnAppDbContext> options) : base(options) { }
        public DbSet<PdnCategory> Categories { get; set; }
        public DbSet<PdnProduct> Products { get; set; }
    }
}
