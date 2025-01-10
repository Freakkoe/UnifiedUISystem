using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Models;

namespace UnifiedUISystem.Data
{
    // DbContext class for interacting with the SofdCore database context.
    public class SofdCoreDbContext : DbContext
    {
        // Constructor to initialize the context with provided options.
        // These options determine how the context connects to the database.
        public SofdCoreDbContext(DbContextOptions<SofdCoreDbContext> options) : base(options)
        {
        }

        // DbSet property representing the 'AccountCreation' table in the database.
        // This allows querying and saving AccountCreation entities.
        public DbSet<AccountCreation> AccountCreation { get; set; }

        // DbSet property representing the 'Relations' table in the database.
        // This allows querying and saving Relation entities.
        public DbSet<Relation> Relations { get; set; }
    }
}
