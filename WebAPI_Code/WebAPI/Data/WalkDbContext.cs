using Microsoft.EntityFrameworkCore;
using WebAPI.Model.Domain;

namespace WebAPI.Data
{
    public class WalkDbContext :DbContext
    {
        public WalkDbContext(DbContextOptions<WalkDbContext>options):base(options)

        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
    }
}
