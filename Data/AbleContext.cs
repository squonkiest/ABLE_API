using Microsoft.EntityFrameworkCore;

namespace ABLE_API.Data
{
    public class AbleContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExperimentData>().HasNoKey();
        }
        public required DbSet<ExperimentData> ExperimentData { get; set; }
    }
}
