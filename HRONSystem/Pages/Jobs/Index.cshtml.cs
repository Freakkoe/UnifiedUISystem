using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using HRONSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRONSystem.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly HRONNewDbContext _context;

        public IndexModel(HRONNewDbContext context)
        {
            _context = context;
        }

        public List<JobAdvert> JobAdverts { get; set; } = new List<JobAdvert>();
        public string SearchTerm { get; set; }
        public bool ShowArchived { get; set; }

        public async Task OnGetAsync(string searchTerm, bool showArchived)
        {
            SearchTerm = searchTerm;
            ShowArchived = showArchived;

            // Start med alle jobannoncer
            var query = _context.JobAdverts.AsQueryable();

            // Filtrer baseret på søgeord
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(j => j.JobTitle.Contains(SearchTerm) ||
                                         j.Media.Contains(SearchTerm) ||
                                         j.Responsible.Contains(SearchTerm) ||
                                         j.Department.Contains(SearchTerm));
            }

            // Filtrer aktive og arkiverede job
            if (!ShowArchived)
            {
                query = query.Where(j => !j.IsArchived);
            }

            // Hent resultater fra databasen
            JobAdverts = await query.ToListAsync();
        }
    }
}
