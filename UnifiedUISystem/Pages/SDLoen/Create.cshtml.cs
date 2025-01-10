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

        public IActionResult OnGetAsync()
        {
            // Sæt standardværdier for ikke-obligatoriske felter
            EmployeeInfo = new EmployeeInfo
            {
                //EmploymentDate = DateTime.Now, // FIX THIS - SHOULD BE STRING TO DATETIME OR DATETIME TO STRING......
                CreationDate = DateTime.Now,
                //StartDate = DateTime.Now, // Leave this for now!!!
            };
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmployeeInfos.Add(EmployeeInfo);
            _context.SaveChanges();

            return RedirectToPage("../Index", new { activeTab = "sdloen" });
        }
    }
}
