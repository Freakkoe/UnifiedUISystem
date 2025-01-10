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

namespace HRONSystem.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        public EditModel(HRONSystem.Data.HRONNewDbContext context)
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

            var jobadvert =  await _context.JobAdverts.FirstOrDefaultAsync(m => m.Id == id);
            if (jobadvert == null)
            {
                return NotFound();
            }
            JobAdvert = jobadvert;
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

            _context.Attach(JobAdvert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobAdvertExists(JobAdvert.Id))
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

        private bool JobAdvertExists(int id)
        {
            return _context.JobAdverts.Any(e => e.Id == id);
        }
    }
}
