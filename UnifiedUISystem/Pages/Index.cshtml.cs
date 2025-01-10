using Microsoft.AspNetCore.Mvc.RazorPages;
using HRONSystem.Models; // HRON Models
using SofdCoreSystem.Models; // SofdCore Models
using SDLoenSystem.Models; // SD Loen Models
using UnifiedUISystem.Data; // Unified UI Data Folder
using Microsoft.EntityFrameworkCore; 

namespace UnifiedUISystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HRONNewDbContext _hronContext;
        private readonly SofdCoreDbContext _sofdCoreContext;
        private readonly SDLOENDbContext _sdloenContext;

        public IndexModel(HRONNewDbContext hronContext, SofdCoreDbContext sofdCoreContext, SDLOENDbContext sdloenContext)
        {
            _hronContext = hronContext;
            _sofdCoreContext = sofdCoreContext;
            _sdloenContext = sdloenContext;
        }

        public List<JobAdvert> JobAdverts { get; set; }
        public List<AccountCreation> Accounts { get; set; }
        public List<EmployeeInfo> Employees { get; set; }

        public bool ShowArchived { get; set; }
        public string SearchTerm { get; set; }



        public async Task OnGetAsync(string searchTerm, bool showArchived)
        {
            SearchTerm = searchTerm;
            ShowArchived = showArchived;

            // Hent data fra alle tre systemer
            JobAdverts = await _hronContext.JobAdverts.ToListAsync();
            Accounts = await _sofdCoreContext.AccountCreation.ToListAsync();
            Employees = await _sdloenContext.EmployeeInfos.ToListAsync();

            var query = _hronContext.JobAdverts.AsQueryable();


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
