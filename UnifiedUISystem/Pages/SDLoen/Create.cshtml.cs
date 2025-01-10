using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Pages.SDLoen
{
    // The CreateModel handles creating a new employee info entry in the database.
    public class CreateModel : PageModel
    {
        // The database context for interacting with the SDLOEN database.
        private readonly SDLOENDbContext _context;

        // Constructor that injects the SDLOEN database context into the page model.
        public CreateModel(SDLOENDbContext context)
        {
            _context = context;
        }

        // Property that holds the employee info details to be added.
        [BindProperty]
        public EmployeeInfo EmployeeInfo { get; set; }

        // OnGetAsync handles GET requests when loading the create page.
        public IActionResult OnGetAsync()
        {
            // Set default values for non-required fields.
            EmployeeInfo = new EmployeeInfo
            {
                // You can uncomment and adjust this part if you want to initialize certain fields like EmploymentDate.
                // EmploymentDate = DateTime.Now, // FIX THIS - SHOULD BE STRING TO DATETIME OR DATETIME TO STRING......  
                CreationDate = DateTime.Now,  // Automatically set the creation date to the current time.
                // StartDate = DateTime.Now, // Leave this for now (StartDate can be set later).
            };

            // Return the page with the new employee info instance.
            return Page();
        }

        // OnPostAsync handles the POST request when the form is submitted to create a new employee entry.
        public IActionResult OnPostAsync()
        {
            // Validate the model state before proceeding with the operation.
            if (!ModelState.IsValid)
            {
                // If the model state is invalid (e.g., required fields are missing), re-render the page with error messages.
                return Page();
            }

            // Add the new EmployeeInfo to the database context.
            _context.EmployeeInfos.Add(EmployeeInfo);

            // Save the changes to the database.
            _context.SaveChanges();

            // Redirect the user to the Index page after successfully adding the employee info.
            return RedirectToPage("../Index", new { activeTab = "sdloen" });
        }
    }
}
