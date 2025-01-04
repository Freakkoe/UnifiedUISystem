using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Pages.SDLoen
{
    public class CreateModel : PageModel
    {
        private readonly SDLOENDbContext _context;

        public CreateModel(SDLOENDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeInfo EmployeeInfo { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmployeeInfos.Add(EmployeeInfo);
            _context.SaveChanges();

            return RedirectToPage("../Index");
        }
    }
}
