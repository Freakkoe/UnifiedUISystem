using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace UnifiedUISystem.Pages.SofdCore
{
    public class DeleteModel : PageModel
    {
        private readonly SofdCoreDbContext _context;

        // Constructor to inject the database context
        public DeleteModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        // Property to bind the form data
        [BindProperty]
        public AccountCreation Account { get; set; }

        // Handles the GET request to display the delete confirmation page
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Attempt to find the AccountCreation record with the given id
            Account = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == id);

            // If the record is not found, return a 404 (Not Found) response
            if (Account == null)
            {
                return NotFound();
            }

            // Return the page to display the deletion confirmation
            return Page();
        }

        // Handles the POST request to delete the account from the database
        public async Task<IActionResult> OnPostAsync()
        {
            // Find the account in the database using the provided Id
            var accountInDb = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == Account.Id);

            // If the account is not found, return a 404 (Not Found) response
            if (accountInDb == null)
            {
                return NotFound();
            }

            // Remove the account from the database
            _context.AccountCreation.Remove(accountInDb);
            await _context.SaveChangesAsync();

            // After deletion, redirect to the Index page with the active tab set to "sofdcore"
            return RedirectToPage("../Index", new { activeTab = "sofdcore" });
        }
    }
}
