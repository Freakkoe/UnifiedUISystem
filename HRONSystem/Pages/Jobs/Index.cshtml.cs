using Microsoft.AspNetCore.Mvc.RazorPages; // Provides classes for Razor Pages functionality.
using Microsoft.EntityFrameworkCore; // Provides functionality for working with Entity Framework Core.
using HRONSystem.Data; // Provides access to the database context.
using HRONSystem.Models; // Provides the JobAdvert model.
using System.Collections.Generic; // Provides classes for working with collections.
using System.Linq; // Provides LINQ functionality for querying collections.
using System.Threading.Tasks; // Provides types that allow asynchronous programming.

namespace HRONSystem.Pages.Jobs
{
    // Page model for displaying and filtering a list of JobAdverts.
    public class IndexModel : PageModel
    {
        // The database context to interact with the database.
        private readonly HRONNewDbContext _context;

        // Constructor that accepts a database context and assigns it to the context variable.
        public IndexModel(HRONNewDbContext context)
        {
            _context = context;
        }

        // Property to hold the list of JobAdverts that will be displayed.
        public List<JobAdvert> JobAdverts { get; set; } = new List<JobAdvert>();

        // Property to hold the search term entered by the user.
        public string SearchTerm { get; set; }

        // Property to indicate whether to show archived job adverts.
        public bool ShowArchived { get; set; }

        // Handles the GET request to retrieve and filter JobAdverts based on the search term and show archived flag.
        public async Task OnGetAsync(string searchTerm, bool showArchived)
        {
            // Set the search term and showArchived flag based on user input.
            SearchTerm = searchTerm;
            ShowArchived = showArchived;

            // Start with the base query to retrieve all JobAdverts.
            var query = _context.JobAdverts.AsQueryable();

            // If a search term is provided, filter the JobAdverts based on the search term.
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(j => j.JobTitle.Contains(SearchTerm) || // Filter by JobTitle
                                         j.Media.Contains(SearchTerm) || // Filter by Media
                                         j.Responsible.Contains(SearchTerm) || // Filter by Responsible person
                                         j.Department.Contains(SearchTerm)); // Filter by Department
            }

            // If ShowArchived is false, filter out the archived JobAdverts.
            if (!ShowArchived)
            {
                query = query.Where(j => !j.IsArchived); // Filter out archived JobAdverts
            }

            // Asynchronously retrieve the filtered list of JobAdverts from the database.
            JobAdverts = await query.ToListAsync();
        }
    }
}
