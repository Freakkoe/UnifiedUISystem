using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace SofdCoreSystem.Pages.AccountCreation
{
    // PageModel class for displaying the details of an AccountCreation record.
    public class DetailsModel : PageModel
    {
        // Database context to interact with the database.
        private readonly SofdCoreDbContext _context;

        // Constructor to inject the database context into the page model.
        public DetailsModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        // Property to hold the AccountCreation entity.
        public Models.AccountCreation Account { get; set; }

        // Property to hold the list of related relations.
        public List<Relation> Relations { get; set; }

        // GET request handler to retrieve and display the details of an AccountCreation.
        public IActionResult OnGet(int id)
        {
            // Query to find the AccountCreation record along with its related relations.
            Account = _context.AccountCreation
                .Include(a => a.Relations) // Include related relations data.
                .FirstOrDefault(a => a.Id == id); // Find the AccountCreation with the specified id.

            // If no AccountCreation record is found, return a NotFound response.
            if (Account == null)
            {
                return NotFound();
            }

            // Store the relations for display.
            Relations = Account.Relations.ToList();

            // Return the page to display the details.
            return Page();
        }
    }
}
