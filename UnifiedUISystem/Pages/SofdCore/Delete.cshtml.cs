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

        public DeleteModel(SofdCoreDbContext context)
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
            var accountInDb = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == Account.Id);

            if (accountInDb == null)
            {
                return NotFound();
            }

            _context.AccountCreation.Remove(accountInDb);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index", new { activeTab = "sofdcore" });
        }
    }
}
