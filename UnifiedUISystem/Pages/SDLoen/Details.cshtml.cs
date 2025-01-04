using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Pages.SDLoen
{
    public class DetailsModel : PageModel
    {
        private readonly SDLOENDbContext _context;

        public DetailsModel(SDLOENDbContext context)
        {
            _context = context;
        }

        public EmployeeInfo EmployeeInfo { get; set; }

        public IActionResult OnGet(int id)
        {
            EmployeeInfo = _context.EmployeeInfos.FirstOrDefault(e => e.Id == id);

            if (EmployeeInfo == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
