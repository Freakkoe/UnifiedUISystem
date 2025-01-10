using System; // Provides base class definitions and fundamental types.
using System.Collections.Generic; // Provides classes for working with collections of objects.
using System.Linq; // Provides LINQ (Language Integrated Query) methods for querying data.
using System.Threading.Tasks; // Provides types for asynchronous programming.
using Microsoft.AspNetCore.Mvc; // Provides classes for MVC (Model-View-Controller) functionality.
using Microsoft.AspNetCore.Mvc.RazorPages; // Provides classes for Razor Pages functionality.
using Microsoft.AspNetCore.Mvc.Rendering; // Provides classes for generating HTML elements in Razor views.
using SDLoenSystem.Data; // Namespace for the data context.
using SDLoenSystem.Models; // Namespace for the models (e.g., EmployeeInfo).

namespace SDLoenSystem.Pages.EmployeeInfo
{
    // Represents the Razor Page for creating a new EmployeeInfo entry.
    public class CreateModel : PageModel
    {
        private readonly SDLoenSystem.Data.SDLOENDbContext _context; // The context used to interact with the database.

        // Constructor for injecting the database context into the PageModel.
        public CreateModel(SDLoenSystem.Data.SDLOENDbContext context)
        {
            _context = context;
        }

        // Called when the page is first accessed to render the page.
        // Displays the form for creating a new EmployeeInfo entry.
        public IActionResult OnGet()
        {
            return Page(); // Returns the current page (to display the form).
        }

        [BindProperty] // Binds the form input to the EmployeeInfo model.
        public Models.EmployeeInfo EmployeeInfo { get; set; } = default!; // The EmployeeInfo model object that will be used to bind the form data.

        // Handles the form submission to create a new EmployeeInfo entry.
        // Saves the data to the database if the model is valid.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) // Checks if the form data is valid (all required fields filled out correctly).
            {
                return Page(); // If the form data is invalid, return the page with validation errors.
            }

            _context.EmployeeInfos.Add(EmployeeInfo); // Adds the new EmployeeInfo object to the context.
            await _context.SaveChangesAsync(); // Asynchronously saves the new EmployeeInfo entry to the database.

            return RedirectToPage("./Index"); // Redirects to the Index page after successfully saving the entry.
        }
    }
}
