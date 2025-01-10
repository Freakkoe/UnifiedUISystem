using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Pages.SDLoen
{
    // The DetailsModel class is responsible for showing the details of an employee.
    public class DetailsModel : PageModel
    {
        // The context for accessing the SDLOEN database.
        private readonly SDLOENDbContext _context;

        // Constructor that initializes the context to interact with the database.
        public DetailsModel(SDLOENDbContext context)
        {
            _context = context;
        }

        // Property that holds the employee info to be displayed on the details page.
        public EmployeeInfo EmployeeInfo { get; set; }

        // OnGet handles the GET request to retrieve the employee details.
        public IActionResult OnGet(int id)
        {
            // Attempt to find the employee based on the provided ID.
            EmployeeInfo = _context.EmployeeInfos.FirstOrDefault(e => e.Id == id);

            // If the employee record is not found, return a NotFound response.
            if (EmployeeInfo == null)
            {
                return NotFound();
            }

            // Return the page to display the employee details if found.
            return Page();
        }
    }
}
