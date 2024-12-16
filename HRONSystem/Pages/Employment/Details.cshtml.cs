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
    public class DetailsModel : PageModel
    {
        private readonly HRONSystem.Data.HRONDbContext _context;

        public DetailsModel(HRONSystem.Data.HRONDbContext context)
        {
            _context = context;
        }

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
    }
}
