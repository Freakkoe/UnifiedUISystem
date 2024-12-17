using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Models;
using System.Collections.Generic;

namespace SofdCoreSystem.Data
{
    public class SofdCoreDbContext : DbContext
    {
        public SofdCoreDbContext(DbContextOptions<SofdCoreDbContext> options) : base(options)
        {
        }

        public DbSet<AccountCreation> AccountCreation { get; set; }
    }
}
