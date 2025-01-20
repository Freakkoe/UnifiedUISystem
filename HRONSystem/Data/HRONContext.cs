using HRONSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HRONSystem.Data
{
    public class HRONContext : DbContext
    {
        public HRONContext(DbContextOptions<HRONContext> options) : base(options) { }

        public DbSet<JobAdvert> JobAdverts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
    }
}
