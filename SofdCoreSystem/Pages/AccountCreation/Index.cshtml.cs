using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace SofdCoreSystem.Pages.AccountCreation
{
    public class IndexModel : PageModel
    {
        private readonly SofdCoreSystem.Data.SofdCoreDbContext _context;

        public IndexModel(SofdCoreSystem.Data.SofdCoreDbContext context)
        {
            _context = context;
        }

        public IList<Models.AccountCreation> AccountCreation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AccountCreation = await _context.AccountCreation.ToListAsync();
        }
    }
}
