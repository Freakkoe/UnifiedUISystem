using Microsoft.EntityFrameworkCore;
using HRONSystem.Models;

namespace HRONSystem.Data
{
    public class HRONNewDbContext : DbContext
    {
        public HRONNewDbContext(DbContextOptions<HRONNewDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobAdvert> JobAdverts { get; set; }
    }
}
