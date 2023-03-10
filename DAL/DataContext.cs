using DAL.Entities;
using DAL.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Value> Values => Set<Value>();
        public DbSet<Entities.File> Files => Set<Entities.File>();
        public DbSet<Result> Results => Set<Result>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FileConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
