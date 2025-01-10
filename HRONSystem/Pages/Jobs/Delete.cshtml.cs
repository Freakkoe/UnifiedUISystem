using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using HRONSystem.Models;

namespace HRONSystem.Pages.Jobs
{
    public class DeleteModel : PageModel
    {
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        public DeleteModel(HRONSystem.Data.HRONNewDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobAdvert JobAdvert { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobadvert = await _context.JobAdverts.FirstOrDefaultAsync(m => m.Id == id);

            if (jobadvert is not null)
            {
                JobAdvert = jobadvert;

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

            var jobadvert = await _context.JobAdverts.FindAsync(id);
            if (jobadvert != null)
            {
                JobAdvert = jobadvert;
                _context.JobAdverts.Remove(JobAdvert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
