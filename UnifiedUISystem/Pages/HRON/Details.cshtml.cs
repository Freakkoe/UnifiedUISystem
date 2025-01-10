using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    // PageModel class to display details of a job advert and increment its views.
    public class DetailsModel : PageModel
    {
        // The database context used to interact with the HRON database.
        private readonly HRONNewDbContext _context;

        // Constructor that initializes the DetailsModel with the provided DbContext.
        // This allows interaction with the HRON database.
        public DetailsModel(HRONNewDbContext context)
        {
            _context = context;
        }

        // Property to hold the JobAdvert details retrieved from the database.
        public JobAdvert JobAdvert { get; set; }

        // OnGet method handles GET requests for this page.
        // It retrieves the job advert details by its ID and increments its view count.
        public IActionResult OnGet(int id)
        {
            // Retrieve the JobAdvert object by its ID.
            JobAdvert = _context.JobAdverts.FirstOrDefault(j => j.Id == id);

            // If no matching JobAdvert is found, return a 404 Not Found result.
            if (JobAdvert == null)
            {
                return NotFound();
            }

            // Increment the view count of the job advert by 1.
            JobAdvert.Views++;

            // Attempt to save the updated view count to the database.
            try
            {
                _context.SaveChanges();  // Save changes to persist the updated view count.
            }
            catch (Exception ex)
            {
                // Log the error if saving the changes fails and redirect to an error page.
                Console.WriteLine($"Error incrementing views: {ex.Message}");
                return RedirectToPage("/Error");  // Redirect to a generic error page (optional).
            }

            // Return the page displaying the job advert details.
            return Page();
        }
    }
}
