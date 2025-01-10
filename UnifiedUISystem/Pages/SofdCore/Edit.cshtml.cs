using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace UnifiedUISystem.Pages.SofdCore
{
    public class EditModel : PageModel
    {
        private readonly SofdCoreDbContext _context;

        // Constructor to inject the database context
        public EditModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        // Property to bind the form data (this will be populated when posting data)
        [BindProperty]
        public AccountCreation Account { get; set; }

        // Handles the GET request to fetch the data of the record to be edited
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Attempt to fetch the AccountCreation record based on the provided id
            Account = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == id);

            // If the account doesn't exist, return a 404 error
            if (Account == null)
            {
                return NotFound();
            }

            // Return the page to edit the details
            return Page();
        }

        // Handles the POST request to save the edited data
        public async Task<IActionResult> OnPostAsync()
        {
            // If the model state is invalid (e.g., missing required fields), stay on the page
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Modelstate is invalid");
                return Page();
            }

            // Retrieve the existing account from the database
            var accountInDb = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == Account.Id);

            // If the account does not exist, return a 404 error
            if (accountInDb == null)
            {
                Console.WriteLine($"Account with ID {Account.Id} not found.");
                return NotFound();
            }

            // Update the fields of the existing account
            accountInDb.FirstName = Account.FirstName;
            accountInDb.LastName = Account.LastName;
            accountInDb.Position = Account.Position;
            accountInDb.JobType = Account.JobType;
            accountInDb.EmployeeNumber = Account.EmployeeNumber;
            accountInDb.WorkHours = Account.WorkHours;
            accountInDb.StartDate = Account.StartDate;
            accountInDb.EndDate = Account.EndDate;
            accountInDb.LastUpdated = DateTime.Now;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Log success and redirect to the index page
            Console.WriteLine("Changes saved successfully. Redirecting to index.");
            return RedirectToPage("../Index", new { activeTab = "sofdcore" });
        }
    }
}
