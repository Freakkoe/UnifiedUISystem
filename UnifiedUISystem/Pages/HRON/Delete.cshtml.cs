using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    public class DeleteModel : PageModel
    {
        private readonly HRONNewDbContext _context;

        public DeleteModel(HRONNewDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobAdvert JobAdvert { get; set; }

        public IActionResult OnGet(int id)
        {
            JobAdvert = _context.JobAdverts.FirstOrDefault(j => j.Id == id);

            if (JobAdvert == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var jobAdvert = _context.JobAdverts.FirstOrDefault(j => j.Id == id);

            if (jobAdvert == null)
            {
                return NotFound();
            }

            _context.JobAdverts.Remove(jobAdvert);
            _context.SaveChanges();

            return RedirectToPage("../Index", new { activeTab = "hron" });
        }
    }
}
