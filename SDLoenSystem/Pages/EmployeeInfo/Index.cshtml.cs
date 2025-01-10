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
    public class IndexModel : PageModel
    {
        private readonly SDLoenSystem.Data.SDLOENDbContext _context;

        public IndexModel(SDLoenSystem.Data.SDLOENDbContext context)
        {
            _context = context;
        }

        public IList<Models.EmployeeInfo> EmployeeInfo { get; set; } = default!;

        public async Task OnGetAsync()
        {
            EmployeeInfo = await _context.EmployeeInfos.ToListAsync();
        }
    }
}
