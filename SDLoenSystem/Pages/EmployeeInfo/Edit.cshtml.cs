using System; // Provides base class definitions and fundamental types.
using System.Collections.Generic; // Provides classes for working with collections of objects.
using System.Linq; // Provides LINQ (Language Integrated Query) methods for querying data.
using System.Threading.Tasks; // Provides types for asynchronous programming.
using Microsoft.AspNetCore.Mvc; // Provides classes for MVC (Model-View-Controller) functionality.
using Microsoft.AspNetCore.Mvc.RazorPages; // Provides classes for Razor Pages functionality.
using Microsoft.AspNetCore.Mvc.Rendering; // Provides helper classes for generating HTML elements like dropdown lists.
using Microsoft.EntityFrameworkCore; // Provides methods for interacting with a database using Entity Framework.
using SDLoenSystem.Data; // Namespace for the data context.
using SDLoenSystem.Models; // Namespace for the models (e.g., EmployeeInfo).

namespace SDLoenSystem.Pages.EmployeeInfo
{
    // Represents the Razor Page for editing an EmployeeInfo record.
    public class EditModel : PageModel
    {
        private readonly SDLoenSystem.Data.SDLOENDbContext _context; // The context used to interact with the database.

        // Constructor for injecting the database context into the PageModel.
        public EditModel(SDLoenSystem.Data.SDLOENDbContext context)
        {
            _context = context;
        }

        [BindProperty] // Binds the EmployeeInfo model to the page, making it accessible for binding to form fields.
        public Models.EmployeeInfo EmployeeInfo { get; set; } = default!; // The EmployeeInfo model object that will be edited.

        // Handles the GET request for the Edit page.
        // Retrieves the EmployeeInfo record by its ID to populate the form for editing.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) // If no ID is provided, return a "Not Found" response.
            {
                return NotFound();
            }

            // Fetch the EmployeeInfo record from the database based on the provided ID.
            var employeeinfo = await _context.EmployeeInfos.FirstOrDefaultAsync(m => m.Id == id);

            if (employeeinfo == null) // If the employee is not found, return a "Not Found" response.
            {
                return NotFound();
            }

            // Set the EmployeeInfo property with the fetched record to populate the form for editing.
            EmployeeInfo = employeeinfo;

            return Page(); // Return the page for editing the employee's details.
        }

        // Handles the POST request when the user submits the form after editing the EmployeeInfo record.
        // Updates the existing EmployeeInfo record in the database.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) // If the model is not valid, return the page for correcting errors.
            {
                return Page();
            }

            // Attach the modified EmployeeInfo entity to the context to mark it as modified.
            _context.Attach(EmployeeInfo).State = EntityState.Modified;

            try
            {
                // Save the changes to the database.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) // If a concurrency conflict occurs during update, handle it.
            {
                if (!EmployeeInfoExists(EmployeeInfo.Id)) // If the employee no longer exists, return a "Not Found" response.
                {
                    return NotFound();
                }
                else
                {
                    // If the error is not due to the record being missing, rethrow the exception.
                    throw;
                }
            }

            // Redirect to the Index page after successfully saving the changes.
            return RedirectToPage("./Index");
        }

        // Checks whether an EmployeeInfo record with the specified ID exists in the database.
        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfos.Any(e => e.Id == id); // Returns true if the record exists, false otherwise.
        }
    }
}
