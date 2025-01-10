using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace UnifiedUISystem.Pages.SofdCore
{
    public class DetailsModel : PageModel
    {
        private readonly SofdCoreDbContext _context;

        // Constructor to inject the database context
        public DetailsModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        // Property to hold the account information to be displayed
        public AccountCreation Account { get; set; }

        // Handles the GET request to display the account details
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Attempt to retrieve the AccountCreation record with the specified id
            Account = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == id);

            // If the account is not found, return a 404 (Not Found) response
            if (Account == null)
            {
                Console.WriteLine($"No account found with ID: {id}");
                return NotFound();
            }

            // If found, return the page to display the account details
            return Page();
        }
    }
}
