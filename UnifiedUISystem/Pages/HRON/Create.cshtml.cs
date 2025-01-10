using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    // PageModel class for handling job advert creation.
    public class CreateModel : PageModel
    {
        // The database context used to interact with the HRON database.
        private readonly HRONNewDbContext _context;

        // Constructor that initializes the CreateModel with the provided DbContext.
        // This allows interaction with the HRON database.
        public CreateModel(HRONNewDbContext context)
        {
            _context = context;
        }

        // Property bound to the JobAdvert form input.
        // This allows the form data to be automatically populated in the JobAdvert object.
        [BindProperty]
        public JobAdvert JobAdvert { get; set; }

        // OnGet method handles GET requests to this page.
        // This method simply returns the page to render the form for creating a new job advert.
        public IActionResult OnGet()
        {
            return Page();
        }

        // OnPostAsync method handles the form submission when the user submits the job advert form.
        // It processes the posted data and saves it to the database if the form is valid.
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model state is valid (form validation).
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, re-render the page with validation errors.
                return Page();
            }

            // Add the new JobAdvert object to the database context.
            _context.JobAdverts.Add(JobAdvert);

            // Save changes to the database asynchronously.
            await _context.SaveChangesAsync();

            // Redirect to the Index page of the HRON section with the active tab set to "hron".
            return RedirectToPage("../Index", new { activeTab = "hron" });
        }
    }
}
