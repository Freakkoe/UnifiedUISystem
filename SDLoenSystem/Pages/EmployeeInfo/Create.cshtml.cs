using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace SDLoenSystem.Pages.EmployeeInfo
{
    public class CreateModel : PageModel
    {
        private readonly SDLoenSystem.Data.SDLOENDbContext _context;

        public CreateModel(SDLoenSystem.Data.SDLOENDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.EmployeeInfo EmployeeInfo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmployeeInfos.Add(EmployeeInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
