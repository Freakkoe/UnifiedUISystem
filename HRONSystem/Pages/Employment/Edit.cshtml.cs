using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using HRONSystem.Models;

namespace HRONSystem.Pages.Employment
{
    public class EditModel : PageModel
    {
        private readonly HRONSystem.Data.HRONDbContext _context;

        public EditModel(HRONSystem.Data.HRONDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Employment Employment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employment =  await _context.Employment.FirstOrDefaultAsync(m => m.EmploymentID == id);
            if (employment == null)
            {
                return NotFound();
            }
            Employment = employment;
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

            _context.Attach(Employment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentExists(Employment.EmploymentID))
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

        private bool EmploymentExists(int id)
        {
            return _context.Employment.Any(e => e.EmploymentID == id);
        }
    }
}
