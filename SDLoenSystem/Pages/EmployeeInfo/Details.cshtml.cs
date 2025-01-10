using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace SDLoenSystem.Pages.EmployeeInfo
{
    public class DetailsModel : PageModel
    {
        private readonly SDLoenSystem.Data.SDLOENDbContext _context;

        public DetailsModel(SDLoenSystem.Data.SDLOENDbContext context)
        {
            _context = context;
        }

        public Models.EmployeeInfo EmployeeInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeinfo = await _context.EmployeeInfos.FirstOrDefaultAsync(m => m.Id == id);

            if (employeeinfo is not null)
            {
                EmployeeInfo = employeeinfo;

                return Page();
            }

            return NotFound();
        }
    }
}
