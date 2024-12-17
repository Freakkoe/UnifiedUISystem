using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace SofdCoreSystem.Pages.AccountCreation
{
    public class CreateModel : PageModel
    {
        private readonly SofdCoreSystem.Data.SofdCoreDbContext _context;

        public CreateModel(SofdCoreSystem.Data.SofdCoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.AccountCreation AccountCreation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AccountCreation.Add(AccountCreation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
