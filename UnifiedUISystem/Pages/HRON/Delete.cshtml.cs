using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    // PageModel class to handle deletion of a job advert.
    public class DeleteModel : PageModel
    {
        // The database context used to interact with the HRON database.
        private readonly HRONNewDbContext _context;

        // Constructor that initializes the DeleteModel with the provided DbContext.
        // This allows interaction with the HRON database.
        public DeleteModel(HRONNewDbContext context)
        {
            _context = context;
        }

        // Property bound to the JobAdvert form.
        // This allows the form data to be automatically populated with the job advert to be deleted.
        [BindProperty]
        public JobAdvert JobAdvert { get; set; }

        // OnGet method handles GET requests for this page.
        // It retrieves the job advert from the database based on the provided ID.
        public IActionResult OnGet(int id)
        {
            // Retrieve the JobAdvert object by its ID.
            JobAdvert = _context.JobAdverts.FirstOrDefault(j => j.Id == id);

            // If no matching JobAdvert is found, return a 404 Not Found result.
            if (JobAdvert == null)
            {
                return NotFound();
            }

            // Return the page with the job advert details for confirmation before deletion.
            return Page();
        }

        // OnPost method handles POST requests to delete the job advert.
        // It deletes the job advert and then saves changes to the database.
        public IActionResult OnPost(int id)
        {
            // Retrieve the JobAdvert object by its ID for deletion.
            var jobAdvert = _context.JobAdverts.FirstOrDefault(j => j.Id == id);

            // If no matching JobAdvert is found, return a 404 Not Found result.
            if (jobAdvert == null)
            {
                return NotFound();
            }

            // Remove the JobAdvert object from the database context.
            _context.JobAdverts.Remove(jobAdvert);

            // Save the changes to the database to complete the deletion.
            _context.SaveChanges();

            // Redirect the user back to the Index page with the active tab set to "hron".
            return RedirectToPage("../Index", new { activeTab = "hron" });
        }
    }
}
