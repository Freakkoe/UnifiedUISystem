using System; // Provides base class definitions and fundamental types.
using System.Collections.Generic; // Provides classes for working with collections.
using System.Linq; // Provides LINQ functionality for querying collections.
using System.Threading.Tasks; // Provides types that allow asynchronous programming.
using Microsoft.AspNetCore.Mvc; // Provides classes for ASP.NET Core MVC.
using Microsoft.AspNetCore.Mvc.RazorPages; // Provides classes for Razor Pages.
using Microsoft.AspNetCore.Mvc.Rendering; // Provides classes for rendering HTML elements.
using HRONSystem.Data; // Provides access to the database context.
using HRONSystem.Models; // Provides the JobAdvert model.

namespace HRONSystem.Pages.Jobs
{
    // Page model for creating a new JobAdvert in the system.
    public class CreateModel : PageModel
    {
        // The database context to interact with the database.
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        // Constructor that accepts a database context and assigns it to the context variable.
        public CreateModel(HRONSystem.Data.HRONNewDbContext context)
        {
            _context = context;
        }

        // Method to handle GET requests when the page is loaded.
        public IActionResult OnGet()
        {
            // Returns the current page to render the view.
            return Page();
        }

        // Property to bind the incoming data from the form to the JobAdvert model.
        [BindProperty] // Binds the JobAdvert property to the incoming form data.
        public JobAdvert JobAdvert { get; set; } = default!;

        // Method to handle POST requests when the form is submitted.
        public async Task<IActionResult> OnPostAsync()
        {
            // Checks if the model state is valid, meaning the submitted form data passes validation.
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, re-render the page to display validation errors.
                return Page();
            }

            // Adds the new JobAdvert to the database context.
            _context.JobAdverts.Add(JobAdvert);

            // Asynchronously saves the changes to the database.
            await _context.SaveChangesAsync();

            // Redirects to the Index page after successfully saving the new JobAdvert.
            return RedirectToPage("./Index");
        }
    }
}
