using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace SofdCoreSystem.Pages.AccountCreation
{
    public class DetailsModel : PageModel
    {
        private readonly SofdCoreDbContext _context;

        public DetailsModel(SofdCoreDbContext context)
        {
            _context = context;
        }

        public Models.AccountCreation Account { get; set; }
        public List<Relation> Relations { get; set; }

        public IActionResult OnGet(int id)
        {
            Account = _context.AccountCreation
                .Include(a => a.Relations) // Hent relationer
                .FirstOrDefault(a => a.Id == id);

            if (Account == null)
            {
                return NotFound();
            }

            Relations = Account.Relations.ToList();
            return Page();
        }
    }
}
