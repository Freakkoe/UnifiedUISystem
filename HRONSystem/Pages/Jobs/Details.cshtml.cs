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
    public class DetailsModel : PageModel
    {
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        public DetailsModel(HRONSystem.Data.HRONNewDbContext context)
        {
            _context = context;
        }

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
    }
}
