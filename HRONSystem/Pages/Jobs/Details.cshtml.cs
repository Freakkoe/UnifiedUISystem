using System; // Provides base class definitions and fundamental types.
using System.Collections.Generic; // Provides classes for working with collections.
using System.Linq; // Provides LINQ functionality for querying collections.
using System.Threading.Tasks; // Provides types that allow asynchronous programming.
using Microsoft.AspNetCore.Mvc; // Provides classes for ASP.NET Core MVC.
using Microsoft.AspNetCore.Mvc.RazorPages; // Provides classes for Razor Pages.
using Microsoft.EntityFrameworkCore; // Provides functionality for working with Entity Framework Core.
using HRONSystem.Data; // Provides access to the database context.
using HRONSystem.Models; // Provides the JobAdvert model.

namespace HRONSystem.Pages.Jobs
{
    // Page model for displaying details of a JobAdvert.
    public class DetailsModel : PageModel
    {
        // The database context to interact with the database.
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        // Constructor that accepts a database context and assigns it to the context variable.
        public DetailsModel(HRONSystem.Data.HRONNewDbContext context)
        {
            _context = context;
        }

        // Property to hold the JobAdvert that will be displayed.
        public JobAdvert JobAdvert { get; set; } = default!;

        // Handles the GET request to display the details of a specific JobAdvert.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // If no ID is provided, return a 404 (Not Found) error.
            if (id == null)
            {
                return NotFound();
            }

            // Asynchronously retrieves the JobAdvert from the database using the provided ID.
            var jobadvert = await _context.JobAdverts.FirstOrDefaultAsync(m => m.Id == id);

            // If a JobAdvert is found, assign it to the JobAdvert property and increment the view count.
            if (jobadvert is not null)
            {
                JobAdvert = jobadvert;

                // Increment the Views count by 1 for the JobAdvert.
                jobadvert.Views++;

                // Asynchronously saves the updated JobAdvert to the database.
                await _context.SaveChangesAsync();

                // Returns the page to display the details.
                return Page();
            }

            // If no JobAdvert is found, return a 404 (Not Found) error.
            return NotFound();
        }
    }
}
