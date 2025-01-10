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

        public CreateModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountCreation Account { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Tilføj oprettelsesdato
            Account.CreationDate = DateTime.Now;

            // Gem data i databasen
            _context.AccountCreation.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index", new { activeTab = "sofdcore" });
        }
    }
}
