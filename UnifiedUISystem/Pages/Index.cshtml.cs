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
        // Injecting the database contexts for the three systems
        private readonly HRONNewDbContext _hronContext;
        private readonly SofdCoreDbContext _sofdCoreContext;
        private readonly SDLOENDbContext _sdloenContext;

        public IndexModel(HRONNewDbContext hronContext, SofdCoreDbContext sofdCoreContext, SDLOENDbContext sdloenContext)
        {
            _hronContext = hronContext;
            _sofdCoreContext = sofdCoreContext;
            _sdloenContext = sdloenContext;
        }

        // Public properties for data binding in the view
        public List<JobAdvert> JobAdverts { get; set; }
        public List<AccountCreation> Accounts { get; set; }
        public List<EmployeeInfo> Employees { get; set; }

        // Properties for handling filtering and search functionality
        public bool ShowArchived { get; set; }
        public string SearchTerm { get; set; }

        // Handles GET requests, filtering the data based on search term and archived status
        public async Task OnGetAsync(string searchTerm, bool showArchived)
        {
            // Set the search term and archived flag based on query parameters
            SearchTerm = searchTerm;
            ShowArchived = showArchived;

            // Fetch data from the three systems
            JobAdverts = await _hronContext.JobAdverts.ToListAsync();
            Accounts = await _sofdCoreContext.AccountCreation.ToListAsync();
            Employees = await _sdloenContext.EmployeeInfos.ToListAsync();

            // Start a query for JobAdverts with LINQ
            var query = _hronContext.JobAdverts.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(j => j.JobTitle.Contains(SearchTerm) ||
                                         j.Media.Contains(SearchTerm) ||
                                         j.Responsible.Contains(SearchTerm) ||
                                         j.Department.Contains(SearchTerm));
            }

            // Filter by archived status
            if (!ShowArchived)
            {
                query = query.Where(j => !j.IsArchived);
            }

            // Execute the query and assign results to JobAdverts
            JobAdverts = await query.ToListAsync();
        }
    }
}
