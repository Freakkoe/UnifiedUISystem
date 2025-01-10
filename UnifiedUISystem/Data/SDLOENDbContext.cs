using Microsoft.EntityFrameworkCore;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Data
{
    // DbContext class for interacting with the SDLOEN database context.
    public class SDLOENDbContext : DbContext
    {
        // Constructor to initialize the context with provided options.
        // These options determine how the context connects to the database.
        public SDLOENDbContext(DbContextOptions<SDLOENDbContext> options) : base(options)
        {
        }

        // DbSet property representing the 'EmployeeInfos' table in the database.
        // This allows querying and saving EmployeeInfo entities.
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
