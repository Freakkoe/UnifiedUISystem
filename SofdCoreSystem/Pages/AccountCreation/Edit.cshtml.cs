using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace SofdCoreSystem.Pages.AccountCreation
{
    // PageModel class for editing an existing AccountCreation record.
    public class EditModel : PageModel
    {
        // Database context to interact with the database.
        private readonly SofdCoreSystem.Data.SofdCoreDbContext _context;

        // Constructor to inject the database context into the page model.
        public EditModel(SofdCoreSystem.Data.SofdCoreDbContext context)
        {
            _context = context;
        }

        // Bind the AccountCreation entity to the page, allowing it to be submitted from the form.
        [BindProperty]
        public Models.AccountCreation AccountCreation { get; set; } = default!;

        // GET request handler to retrieve the AccountCreation record for editing.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Check if the ID is provided; if not, return a NotFound response.
            if (id == null)
            {
                return NotFound();
            }

            // Query to find the AccountCreation record with the specified ID.
            var accountcreation = await _context.AccountCreation.FirstOrDefaultAsync(m => m.Id == id);

            // If no record is found, return a NotFound response.
            if (accountcreation == null)
            {
                return NotFound();
            }

            // Set the retrieved AccountCreation object to be edited in the form.
            AccountCreation = accountcreation;

            // Return the page for editing the details.
            return Page();
        }

        // POST request handler to save the edited AccountCreation record to the database.
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model is valid before saving the changes.
            if (!ModelState.IsValid)
            {
                // If invalid, return the page to allow the user to correct the errors.
                return Page();
            }

            // Attach the AccountCreation entity to the context and mark it as modified.
            _context.Attach(AccountCreation).State = EntityState.Modified;

            try
            {
                // Save the changes to the database asynchronously.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency issues, such as when the record is updated by another user before the changes are saved.
                if (!AccountCreationExists(AccountCreation.Id))
                {
                    // If the AccountCreation record does not exist, return NotFound.
                    return NotFound();
                }
                else
                {
                    // If concurrency error persists, re-throw the exception.
                    throw;
                }
            }

            // Redirect to the Index page after the successful update.
            return RedirectToPage("./Index");
        }

        // Helper method to check if an AccountCreation record exists in the database.
        private bool AccountCreationExists(int id)
        {
            // Return true if the AccountCreation record with the given ID exists in the database.
            return _context.AccountCreation.Any(e => e.Id == id);
        }
    }
}
