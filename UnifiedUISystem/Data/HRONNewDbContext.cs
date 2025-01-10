using Microsoft.EntityFrameworkCore;
using HRONSystem.Models;

namespace UnifiedUISystem.Data
{
    // DbContext class for interacting with the HRONNew database context.
    public class HRONNewDbContext : DbContext
    {
        // Constructor to pass the DbContextOptions to the base class constructor.
        public HRONNewDbContext(DbContextOptions<HRONNewDbContext> options) : base(options)
        {
        }

        // DbSet representing the 'JobAdverts' table in the database.
        // This will allow querying and saving JobAdvert entities.
        public DbSet<JobAdvert> JobAdverts { get; set; }
    }
}
