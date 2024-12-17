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
    public class DetailsModel : PageModel
    {
        private readonly SofdCoreSystem.Data.SofdCoreDbContext _context;

        public DetailsModel(SofdCoreSystem.Data.SofdCoreDbContext context)
        {
            _context = context;
        }

        public Models.AccountCreation AccountCreation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountcreation = await _context.AccountCreation.FirstOrDefaultAsync(m => m.Id == id);

            if (accountcreation is not null)
            {
                AccountCreation = accountcreation;

                return Page();
            }

            return NotFound();
        }
    }
}
