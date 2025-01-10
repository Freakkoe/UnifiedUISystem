using Microsoft.EntityFrameworkCore; // Provides functionality for interacting with Entity Framework Core.
using SDLoenSystem.Models; // Provides the model classes, such as EmployeeInfo.

namespace SDLoenSystem.Data
{
    // This class represents the database context for the SDLoan system, which is used to interact with the database.
    public class SDLOENDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions for configuring the context (e.g., database connection settings).
        public SDLOENDbContext(DbContextOptions<SDLOENDbContext> options)
            : base(options) // Passes the options to the base class constructor.
        {

        }

        // DbSet representing the EmployeeInfos table in the database.
        // It allows for querying and saving instances of EmployeeInfo.
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
