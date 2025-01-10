using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRONSystem.Data;
using HRONSystem.Models;

namespace HRONSystem.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly HRONSystem.Data.HRONNewDbContext _context;

        public CreateModel(HRONSystem.Data.HRONNewDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobAdvert JobAdvert { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobAdverts.Add(JobAdvert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
