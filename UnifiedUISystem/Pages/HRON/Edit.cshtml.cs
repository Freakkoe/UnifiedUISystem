using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    // The EditModel handles editing an existing job advertisement.
    public class EditModel : PageModel
    {
        // The database context for interacting with the HRON database.
        private readonly HRONNewDbContext _context;

        // Constructor that injects the HRON database context into the page model.
        public EditModel(HRONNewDbContext context)
        {
            _context = context;
        }

        // Property that holds the job advert details to be edited.
        [BindProperty]
        public JobAdvert JobAdvert { get; set; }

        // OnGetAsync handles GET requests to fetch the job advert details.
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the job advert from the database using the ID provided in the URL.
            JobAdvert = await _context.JobAdverts.FirstOrDefaultAsync(j => j.Id == id);

            // If no matching job advert is found, return a NotFound result.
            if (JobAdvert == null)
            {
                return NotFound();
            }

            // Return the page with the job advert details.
            return Page();
        }

        // OnPostAsync handles the form submission when editing the job advert.
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model state is valid before proceeding.
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, log the errors and return the page.
                Console.WriteLine("Modelstate is invalid");

                // Log each field error for debugging purposes.
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Field: {key}, Error: {error.ErrorMessage}");
                    }
                }

                return Page();  // Return the page with validation errors.
            }

            // Retrieve the existing job advert from the database.
            var jobFromDb = await _context.JobAdverts.FirstOrDefaultAsync(j => j.Id == JobAdvert.Id);

            // If no matching job advert is found, return a NotFound result.
            if (jobFromDb == null)
            {
                return NotFound();
            }

            // Update the properties of the existing job advert with the new values.
            jobFromDb.JobTitle = JobAdvert.JobTitle;
            jobFromDb.PublishingDate = JobAdvert.PublishingDate;
            jobFromDb.ApplicationDeadline = JobAdvert.ApplicationDeadline;
            jobFromDb.Media = JobAdvert.Media;
            jobFromDb.Status = JobAdvert.Status;
            jobFromDb.IsArchived = JobAdvert.IsArchived;
            jobFromDb.Responsible = JobAdvert.Responsible;
            jobFromDb.Department = JobAdvert.Department;
            jobFromDb.Comments = JobAdvert.Comments;

            // Save the changes to the database.
            await _context.SaveChangesAsync();

            // Redirect the user to the Index page after successfully updating the job advert.
            return RedirectToPage("../Index", new { activeTab = "hron" });
        }
    }
}
