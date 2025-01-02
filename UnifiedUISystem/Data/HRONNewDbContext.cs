using Microsoft.EntityFrameworkCore;
using HRONSystem.Models;

namespace UnifiedUISystem.Data
{
    public class HRONNewDbContext : DbContext
    {
        public HRONNewDbContext(DbContextOptions<HRONNewDbContext> options) : base(options)
        {
        }

        public DbSet<JobAdvert> JobAdverts { get; set; }
    }
}
