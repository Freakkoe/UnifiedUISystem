using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofdCoreSystem.Pages.AccountCreation
{
    public class IndexModel : PageModel
    {
        private readonly SofdCoreDbContext _context;

        public IndexModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        public IList<Models.AccountCreation> Accounts { get; set; } = new List<Models.AccountCreation>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.AccountCreation.AsQueryable();

            // Filtrering baseret på søgeterm
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(a =>
                    a.FirstName.Contains(SearchTerm) ||
                    a.LastName.Contains(SearchTerm) ||
                    a.Position.Contains(SearchTerm) ||
                    a.JobType.Contains(SearchTerm));
            }

            Accounts = await query.ToListAsync();
        }
    }
}
