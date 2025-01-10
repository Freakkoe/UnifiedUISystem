using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Pages.SDLoen
{
    // The DeleteModel is responsible for handling the deletion of an employee record.
    public class DeleteModel : PageModel
    {
        // The database context for interacting with the SDLOEN database.
        private readonly SDLOENDbContext _context;

        // Constructor that injects the SDLOEN database context into the page model.
        public DeleteModel(SDLOENDbContext context)
        {
            _context = context;
        }

        // Property that holds the employee info to be deleted.
        [BindProperty]
        public EmployeeInfo EmployeeInfo { get; set; }

        // OnGetAsync handles GET requests when loading the delete confirmation page.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // If no ID is provided, return a NotFound result.
            if (id == null)
            {
                return NotFound();
            }

            // Attempt to find the employee record by its ID.
            EmployeeInfo = await _context.EmployeeInfos.FindAsync(id);

            // If the employee record is not found, return a NotFound result.
            if (EmployeeInfo == null)
            {
                return NotFound();
            }

            // Return the page if the employee record is found.
            return Page();
        }

        // OnPostAsync handles POST requests when the user confirms the deletion.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // If no ID is provided, return a NotFound result.
            if (id == null)
            {
                return NotFound();
            }

            // Attempt to find the employee record by its ID for deletion.
            var employee = await _context.EmployeeInfos.FindAsync(id);

            // If the employee record is not found, return a NotFound result.
            if (employee == null)
            {
                return NotFound();
            }

            // Remove the found employee record from the database.
            _context.EmployeeInfos.Remove(employee);

            // Save the changes to the database.
            await _context.SaveChangesAsync();

            // Redirect the user back to the Index page, passing an active tab of "sdloen".
            return RedirectToPage("../Index", new { activeTab = "sdloen" });
        }
    }
}
