using GullyService.Domain.Entities;
using GullyService.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GullyService.Infrastructure.Persistence
{
    public class GullyDbContext : DbContext
    {
        public GullyDbContext(DbContextOptions<GullyDbContext> options) : base(options) { }

        public virtual DbSet<Gully> Gullies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GullyConfiguration());
        }
    }
}
