using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofdCoreSystem.Pages.AccountCreation
{
    // PageModel class for displaying the list of AccountCreation records on the Index page.
    public class IndexModel : PageModel
    {
        // Database context to interact with the database.
        private readonly SofdCoreDbContext _context;

        // Constructor to inject the SofdCoreDbContext.
        public IndexModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        // Property to store the list of AccountCreation records to be displayed on the page.
        public IList<Models.AccountCreation> Accounts { get; set; } = new List<Models.AccountCreation>();

        // Property to bind the search term passed as a query parameter from the URL.
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        // OnGetAsync method handles the GET request to retrieve the list of AccountCreation records.
        public async Task OnGetAsync()
        {
            // Initial query to fetch AccountCreation records.
            var query = _context.AccountCreation.AsQueryable();

            // Check if there is a search term provided.
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                // Filter the query based on the search term. It will search across FirstName, LastName, Position, and JobType.
                query = query.Where(a =>
                    a.FirstName.Contains(SearchTerm) ||
                    a.LastName.Contains(SearchTerm) ||
                    a.Position.Contains(SearchTerm) ||
                    a.JobType.Contains(SearchTerm));
            }

            // Execute the query asynchronously and assign the results to the Accounts property.
            Accounts = await query.ToListAsync();
        }
    }
}
