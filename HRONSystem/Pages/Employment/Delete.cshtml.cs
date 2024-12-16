using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using HRONSystem.Models;

namespace HRONSystem.Pages.Employment
{
    public class DeleteModel : PageModel
    {
        private readonly HRONSystem.Data.HRONDbContext _context;

        public DeleteModel(HRONSystem.Data.HRONDbContext context)
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

            var employment = await _context.Employment.FirstOrDefaultAsync(m => m.EmploymentID == id);

            if (employment is not null)
            {
                Employment = employment;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employment = await _context.Employment.FindAsync(id);
            if (employment != null)
            {
                Employment = employment;
                _context.Employment.Remove(Employment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
