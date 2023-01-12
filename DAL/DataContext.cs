using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Value> Values => Set<Value>();
        public DbSet<Entities.File> Files => Set<Entities.File>();
        public DbSet<Result> Results => Set<Result>();
    }
}
