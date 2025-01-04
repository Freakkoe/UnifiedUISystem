using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    public class DetailsModel : PageModel
    {
        private readonly HRONNewDbContext _context;

        public DetailsModel(HRONNewDbContext context)
        {
            _context = context;
        }

        public JobAdvert JobAdvert { get; set; }

        public IActionResult OnGet(int id)
        {
            JobAdvert = _context.JobAdverts.FirstOrDefault(j => j.Id == id);

            if (JobAdvert == null)
            {
                return NotFound();
            }

            JobAdvert.Views++;
            _context.SaveChanges();

            return Page();
        }
    }
}
