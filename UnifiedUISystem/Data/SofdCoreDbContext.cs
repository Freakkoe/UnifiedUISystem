using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Models;

namespace UnifiedUISystem.Data
{
    public class SofdCoreDbContext : DbContext
    {
        public SofdCoreDbContext(DbContextOptions<SofdCoreDbContext> options) : base(options)
        {
        }

        public DbSet<AccountCreation> AccountCreation { get; set; }
        public DbSet<Relation> Relations { get; set; }
    }
}
