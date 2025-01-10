using System; // Provides base class definitions and fundamental types.
using System.Collections.Generic; // Provides classes for working with collections of objects.
using System.Linq; // Provides LINQ (Language Integrated Query) methods for querying data.
using System.Threading.Tasks; // Provides types for asynchronous programming.
using Microsoft.AspNetCore.Mvc; // Provides classes for MVC (Model-View-Controller) functionality.
using Microsoft.AspNetCore.Mvc.RazorPages; // Provides classes for Razor Pages functionality.
using Microsoft.EntityFrameworkCore; // Provides methods for interacting with a database using Entity Framework.
using SDLoenSystem.Data; // Namespace for the data context.
using SDLoenSystem.Models; // Namespace for the models (e.g., EmployeeInfo).

namespace SDLoenSystem.Pages.EmployeeInfo
{
    // Represents the Razor Page for deleting an EmployeeInfo entry.
    public class DeleteModel : PageModel
    {
        private readonly SDLoenSystem.Data.SDLOENDbContext _context; // The context used to interact with the database.

        // Constructor for injecting the database context into the PageModel.
        public DeleteModel(SDLoenSystem.Data.SDLOENDbContext context)
        {
            _context = context;
        }

        [BindProperty] // Binds the EmployeeInfo model to the page.
        public Models.EmployeeInfo EmployeeInfo { get; set; } = default!; // The EmployeeInfo model object that will be used to bind data for deletion.

        // Handles the GET request for the Delete page.
        // Retrieves the EmployeeInfo record to be deleted by its ID.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) // If no ID is provided, return a "Not Found" response.
            {
                return NotFound();
            }

            // Fetch the EmployeeInfo record from the database based on the provided ID.
            var employeeinfo = await _context.EmployeeInfos.FirstOrDefaultAsync(m => m.Id == id);

            if (employeeinfo is not null) // If the employee is found, set the EmployeeInfo property and return the page.
            {
                EmployeeInfo = employeeinfo;
                return Page();
            }

            return NotFound(); // If no record is found, return a "Not Found" response.
        }

        // Handles the POST request for deleting an EmployeeInfo entry.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) // If no ID is provided, return a "Not Found" response.
            {
                return NotFound();
            }

            // Find the EmployeeInfo record to delete using the provided ID.
            var employeeinfo = await _context.EmployeeInfos.FindAsync(id);
            if (employeeinfo != null) // If the record is found, remove it from the database.
            {
                EmployeeInfo = employeeinfo;
                _context.EmployeeInfos.Remove(EmployeeInfo); // Remove the entity from the context.
                await _context.SaveChangesAsync(); // Asynchronously save the changes to the database.
            }

            // Redirect to the Index page after successfully deleting the record.
            return RedirectToPage("./Index");
        }
    }
}
