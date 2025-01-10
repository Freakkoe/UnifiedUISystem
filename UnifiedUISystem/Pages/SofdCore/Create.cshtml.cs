using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;
using System.Threading.Tasks;

namespace UnifiedUISystem.Pages.SofdCore
{
    public class CreateModel : PageModel
    {
        private readonly SofdCoreDbContext _context;

        // Constructor to inject the database context
        public CreateModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        // Property to bind the form data
        [BindProperty]
        public AccountCreation Account { get; set; }

        // Handles the GET request to display the create page
        public IActionResult OnGet()
        {
            return Page();
        }

        // Handles the POST request to save the new account creation data
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add the current creation date
            Account.CreationDate = DateTime.Now;

            // Add the account to the database context
            _context.AccountCreation.Add(Account);
            await _context.SaveChangesAsync();

            // Redirect to the Index page with the active tab set to "sofdcore"
            return RedirectToPage("../Index", new { activeTab = "sofdcore" });
        }
    }
}
