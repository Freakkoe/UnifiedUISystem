using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace SofdCoreSystem.Pages.AccountCreation
{
    // PageModel class for handling the deletion of an AccountCreation record.
    public class DeleteModel : PageModel
    {
        // Database context to interact with the database.
        private readonly SofdCoreSystem.Data.SofdCoreDbContext _context;

        // Constructor to inject the database context into the page model.
        public DeleteModel(SofdCoreSystem.Data.SofdCoreDbContext context)
        {
            _context = context;
        }

        // Property to bind the AccountCreation model to the form data.
        [BindProperty]
        public Models.AccountCreation AccountCreation { get; set; } = default!;

        // GET request handler to display the deletion confirmation page.
        // It retrieves the AccountCreation entity based on the provided id.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // If id is null, return a NotFound response.
            if (id == null)
            {
                return NotFound();
            }

            // Try to find the AccountCreation record using the id.
            var accountcreation = await _context.AccountCreation.FirstOrDefaultAsync(m => m.Id == id);

            // If the record is found, bind it to the AccountCreation property and return the page.
            if (accountcreation is not null)
            {
                AccountCreation = accountcreation;
                return Page(); // Show the page with the AccountCreation data.
            }

            // If the record is not found, return a NotFound response.
            return NotFound();
        }

        // POST request handler to delete the specified AccountCreation record.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // If id is null, return a NotFound response.
            if (id == null)
            {
                return NotFound();
            }

            // Try to find the AccountCreation record using the provided id.
            var accountcreation = await _context.AccountCreation.FindAsync(id);
            if (accountcreation != null)
            {
                // If the record is found, assign it to the AccountCreation property.
                AccountCreation = accountcreation;

                // Remove the found AccountCreation record from the database.
                _context.AccountCreation.Remove(AccountCreation);

                // Save the changes asynchronously to reflect the deletion in the database.
                await _context.SaveChangesAsync();
            }

            // Redirect to the Index page after the deletion.
            return RedirectToPage("./Index");
        }
    }
}
