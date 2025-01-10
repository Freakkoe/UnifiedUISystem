using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace SofdCoreSystem.Pages.AccountCreation
{
    // PageModel class for handling account creation functionality.
    public class CreateModel : PageModel
    {
        // Database context to interact with the database.
        private readonly SofdCoreSystem.Data.SofdCoreDbContext _context;

        // Constructor to inject the database context into the page model.
        public CreateModel(SofdCoreSystem.Data.SofdCoreDbContext context)
        {
            _context = context;
        }

        // GET request handler to load the page.
        public IActionResult OnGet()
        {
            return Page(); // Returns the page view when the user accesses the page.
        }

        // Property to bind the form input to the AccountCreation model.
        [BindProperty]
        public Models.AccountCreation AccountCreation { get; set; } = default!;

        // POST request handler to create a new AccountCreation record.
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model state is valid (form data is correct).
            if (!ModelState.IsValid)
            {
                return Page(); // If invalid, return the page with error messages.
            }

            // Add the new AccountCreation object to the context.
            _context.AccountCreation.Add(AccountCreation);

            // Save the changes to the database asynchronously.
            await _context.SaveChangesAsync();

            // Redirect to the Index page after successful creation.
            return RedirectToPage("./Index");
        }
    }
}
