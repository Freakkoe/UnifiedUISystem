using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace UnifiedUISystem.Pages.SofdCore
{
    public class DetailsModel : PageModel
    {
        private readonly SofdCoreDbContext _context;

        public DetailsModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        public AccountCreation Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Account = await _context.AccountCreation.FirstOrDefaultAsync(ac => ac.Id == id);

            if (Account == null)
            {
                Console.WriteLine($"No account found with ID: {id}");
                return NotFound();
            }

            return Page();
        }
    }
}
