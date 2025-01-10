using Microsoft.EntityFrameworkCore;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Data
{
    public class SDLOENDbContext : DbContext
    {
        public SDLOENDbContext(DbContextOptions<SDLOENDbContext> options) : base(options)
        {

        }

        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
