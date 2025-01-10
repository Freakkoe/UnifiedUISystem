using Microsoft.EntityFrameworkCore; // Import namespace for Entity Framework Core functionalities.
using HRONSystem.Models; // Import namespace for model classes.

namespace HRONSystem.Data
{
    public class HRONNewDbContext : DbContext
    {
        // Constructor to initialize DbContext with configuration options.
        public HRONNewDbContext(DbContextOptions<HRONNewDbContext> options)
            : base(options)
        {
        }

        // Represents the JobAdverts table in the database.
        public DbSet<JobAdvert> JobAdverts { get; set; }
    }
}
