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
    public class EditModel : PageModel
    {
        private readonly SofdCoreSystem.Data.SofdCoreDbContext _context;

        public EditModel(SofdCoreSystem.Data.SofdCoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.AccountCreation AccountCreation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountcreation =  await _context.AccountCreation.FirstOrDefaultAsync(m => m.Id == id);
            if (accountcreation == null)
            {
                return NotFound();
            }
            AccountCreation = accountcreation;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AccountCreation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountCreationExists(AccountCreation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AccountCreationExists(int id)
        {
            return _context.AccountCreation.Any(e => e.Id == id);
        }
    }
}
