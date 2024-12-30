using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using HRONSystem.Models;

namespace HRONSystem.Pages.Employment
{
    public class IndexModel : PageModel
    {
        private readonly HRONDbContext _context;

        public IndexModel(HRONDbContext context)
        {
            _context = context;
        }

        public IList<Models.Employment> Employment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employment = await _context.Employment.ToListAsync();
        }
    }
}
