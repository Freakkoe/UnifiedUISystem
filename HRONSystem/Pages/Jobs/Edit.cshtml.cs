using System; // Provides base class definitions and fundamental types.
using System.Collections.Generic; // Provides classes for working with collections.
using System.Linq; // Provides LINQ functionality for querying collections.
using System.Threading.Tasks; // Provides types that allow asynchronous programming.
using Microsoft.AspNetCore.Mvc; // Provides classes for ASP.NET Core MVC.
using Microsoft.AspNetCore.Mvc.RazorPages; // Provides classes for Razor Pages.
using Microsoft.AspNetCore.Mvc.Rendering; // Provides classes for rendering HTML elements.
using Microsoft.EntityFrameworkCore; // Provides functionality for working with Entity Framework Core.
using HRONSystem.Data; // Provides access to the database context.
using HRONSystem.Models; // Provides the JobAdvert model.

namespace HRONSystem.Pages.Jobs
{
    // Page model for editing a JobAdvert in the system.
    public class EditModel : PageModel
    {
        // The database context to interact with the database.
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        // Constructor that accepts a database context and assigns it to the context variable.
        public EditModel(HRONSystem.Data.HRONNewDbContext context)
        {
            _context = context;
        }

        // Property to bind the incoming JobAdvert data for editing.
        [BindProperty] // Binds the JobAdvert property to the incoming form data.
        public JobAdvert JobAdvert { get; set; } = default!;

        // Handles the GET request to retrieve the JobAdvert that will be edited.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // If no ID is provided, return a 404 (Not Found) error.
            if (id == null)
            {
                return NotFound();
            }

            // Asynchronously retrieves the JobAdvert from the database using the provided ID.
            var jobadvert = await _context.JobAdverts.FirstOrDefaultAsync(m => m.Id == id);

            // If the JobAdvert is not found, return a 404 (Not Found) error.
            if (jobadvert == null)
            {
                return NotFound();
            }

            // Assign the retrieved JobAdvert to the JobAdvert property for editing.
            JobAdvert = jobadvert;

            // Return the page to display the form with the current data of the JobAdvert.
            return Page();
        }

        // Handles the POST request when the form is submitted to save the changes.
        public async Task<IActionResult> OnPostAsync()
        {
            // If the model state is invalid, re-render the page to show validation errors.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Attach the JobAdvert to the context and mark it as modified.
            _context.Attach(JobAdvert).State = EntityState.Modified;

            try
            {
                // Asynchronously saves the changes to the database.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If there is a concurrency issue, check if the JobAdvert still exists in the database.
                if (!JobAdvertExists(JobAdvert.Id))
                {
                    return NotFound();
                }
                else
                {
                    // If the JobAdvert exists but there's another issue, throw the exception again.
                    throw;
                }
            }

            // After successfully saving, redirect to the Index page to display the updated list of JobAdverts.
            return RedirectToPage("./Index");
        }

        // Checks if a JobAdvert exists in the database based on the provided ID.
        private bool JobAdvertExists(int id)
        {
            return _context.JobAdverts.Any(e => e.Id == id);
        }
    }
}
