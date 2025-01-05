using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    public class CreateModel : PageModel
    {
        private readonly HRONNewDbContext _context;

        public CreateModel(HRONNewDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobAdvert JobAdvert { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobAdverts.Add(JobAdvert);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index", new {activeTab = "hron"});
        }
    }
}

