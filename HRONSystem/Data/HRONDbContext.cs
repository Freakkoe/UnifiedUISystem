using HRONSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HRONSystem.Data
{
    public class HRONDbContext : DbContext
    {
        public HRONDbContext(DbContextOptions<HRONDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employment> Employment { get; set; }
    }

}
