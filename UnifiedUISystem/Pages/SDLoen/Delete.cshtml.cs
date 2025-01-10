using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Pages.SDLoen
{
    public class DeleteModel : PageModel
    {
        private readonly SDLOENDbContext _context;

        public DeleteModel(SDLOENDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeInfo EmployeeInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeInfo = await _context.EmployeeInfos.FindAsync(id);

            if (EmployeeInfo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.EmployeeInfos.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.EmployeeInfos.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index", new { activeTab = "sdloen" });
        }
    }
}
