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
    // Page model for deleting a JobAdvert in the system.
    public class DeleteModel : PageModel
    {
        // The database context to interact with the database.
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        // Constructor that accepts a database context and assigns it to the context variable.
        public DeleteModel(HRONSystem.Data.HRONNewDbContext context)
        {
            _context = context;
        }

        // Property to bind the incoming JobAdvert data.
        [BindProperty] // Binds the JobAdvert property to the incoming data.
        public JobAdvert JobAdvert { get; set; } = default!;

        // Handles the GET request to retrieve the JobAdvert to delete.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // If no ID is provided, return a 404 (Not Found) error.
            if (id == null)
            {
                return NotFound();
            }

            // Asynchronously retrieves the JobAdvert from the database using the provided ID.
            var jobadvert = await _context.JobAdverts.FirstOrDefaultAsync(m => m.Id == id);

            // If a JobAdvert is found, assign it to the JobAdvert property and render the page.
            if (jobadvert is not null)
            {
                JobAdvert = jobadvert;

                return Page();
            }

            // If no JobAdvert is found, return a 404 (Not Found) error.
            return NotFound();
        }

        // Handles the POST request to delete the JobAdvert.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // If no ID is provided, return a 404 (Not Found) error.
            if (id == null)
            {
                return NotFound();
            }

            // Asynchronously retrieves the JobAdvert from the database using the provided ID.
            var jobadvert = await _context.JobAdverts.FindAsync(id);
            if (jobadvert != null)
            {
                // If the JobAdvert is found, assign it to the JobAdvert property.
                JobAdvert = jobadvert;

                // Removes the JobAdvert from the database.
                _context.JobAdverts.Remove(JobAdvert);

                // Asynchronously saves the changes to the database.
                await _context.SaveChangesAsync();
            }

            // Redirects to the Index page after deleting the JobAdvert.
            return RedirectToPage("./Index");
        }
    }
}
