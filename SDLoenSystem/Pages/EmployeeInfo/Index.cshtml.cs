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
    // Represents the Razor Page for displaying a list of EmployeeInfo records.
    public class IndexModel : PageModel
    {
        private readonly SDLoenSystem.Data.SDLOENDbContext _context; // The context used to interact with the database.

        // Constructor for injecting the database context into the PageModel.
        public IndexModel(SDLoenSystem.Data.SDLOENDbContext context)
        {
            _context = context;
        }

        public IList<Models.EmployeeInfo> EmployeeInfo { get; set; } = default!; // List to hold EmployeeInfo records to be displayed.

        // Handles the GET request for the Index page.
        // Retrieves all EmployeeInfo records from the database to display in a list.
        public async Task OnGetAsync()
        {
            // Fetch all EmployeeInfo records from the database asynchronously.
            EmployeeInfo = await _context.EmployeeInfos.ToListAsync();
        }
    }
}
