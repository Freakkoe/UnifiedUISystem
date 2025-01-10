using Microsoft.EntityFrameworkCore; // Provides methods and classes for working with databases using Entity Framework.
using SofdCoreSystem.Models; // Namespace for models (e.g., AccountCreation, Relation).
using System.Collections.Generic; // Provides classes for working with collections of objects.

namespace SofdCoreSystem.Data
{
    // Represents the database context class for SofdCoreSystem.
    // This class is responsible for managing the connection to the database and the entities.
    public class SofdCoreDbContext : DbContext
    {
        // Constructor to initialize the DbContext with the given options.
        // The options parameter contains the configuration for connecting to the database.
        public SofdCoreDbContext(DbContextOptions<SofdCoreDbContext> options) : base(options)
        {
        }

        // DbSet for AccountCreation entity. This property represents the table for account creation records in the database.
        public DbSet<AccountCreation> AccountCreation { get; set; }

        // DbSet for Relation entity. This property represents the table for relation records in the database.
        public DbSet<Relation> Relations { get; set; }
    }
}
