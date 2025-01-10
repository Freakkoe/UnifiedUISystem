using HRONSystem.Models; // Import namespace for model classes.
using Microsoft.EntityFrameworkCore; // Import namespace for Entity Framework Core functionalities.

namespace HRONSystem.Data
{
    public class HRONDbContext : DbContext
    {
        // Constructor to initialize DbContext with configuration options.
        public HRONDbContext(DbContextOptions<HRONDbContext> options)
            : base(options)
        {
        }

        // Represents the Employment table in the database.
        public DbSet<Employment> Employment { get; set; }
    }
}
