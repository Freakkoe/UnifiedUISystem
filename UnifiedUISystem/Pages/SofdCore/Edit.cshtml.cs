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

        public EditModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountCreation Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Account = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == id);

            if (Account == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Modelstate is invalid");
                return Page();
            }

            var accountInDb = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == Account.Id);

            if (accountInDb == null)
            {
                Console.WriteLine($"Account with ID {Account.Id} not found.");
                return NotFound();
            }

            // Opdater feltværdier
            accountInDb.FirstName = Account.FirstName;
            accountInDb.LastName = Account.LastName;
            accountInDb.Position = Account.Position;
            accountInDb.JobType = Account.JobType;
            accountInDb.EmployeeNumber = Account.EmployeeNumber;
            accountInDb.WorkHours = Account.WorkHours;
            accountInDb.StartDate = Account.StartDate;
            accountInDb.EndDate = Account.EndDate;
            accountInDb.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            Console.WriteLine("Changes saved successfully. Redirecting to index.");
            return RedirectToPage("../Index", new { activeTab = "sofdcore" });
        }

    }
}