using Microsoft.EntityFrameworkCore;

namespace Aviation.DAL.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt)
            : base(opt)
        {

        }
        public DbSet<AirCraft> AirCrafts { get; set; }
    }
}
