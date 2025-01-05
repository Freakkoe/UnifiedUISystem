using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUISystem.Pages.HRON
{
    public class EditModel : PageModel
    {
        private readonly HRONNewDbContext _context;

        public EditModel(HRONNewDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobAdvert JobAdvert { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            JobAdvert = await _context.JobAdverts.FirstOrDefaultAsync(j => j.Id == id);

            if (JobAdvert == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Modelstate is invalid");
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Field: {key}, Error: {error.ErrorMessage}");
                    } 
                }
                return Page();
            }

            var jobFromDb = await _context.JobAdverts.FirstOrDefaultAsync(j => j.Id == JobAdvert.Id);
            if (jobFromDb == null)
            {
                return NotFound();
            }

            // Update fields
            jobFromDb.JobTitle = JobAdvert.JobTitle;
            jobFromDb.PublishingDate = JobAdvert.PublishingDate;
            jobFromDb.ApplicationDeadline = JobAdvert.ApplicationDeadline;
            jobFromDb.Media = JobAdvert.Media;
            jobFromDb.Status = JobAdvert.Status;
            jobFromDb.IsArchived = JobAdvert.IsArchived;
            jobFromDb.Responsible = JobAdvert.Responsible;
            jobFromDb.Department = JobAdvert.Department;
            jobFromDb.Comments = JobAdvert.Comments;

            await _context.SaveChangesAsync();

            return RedirectToPage("../Index", new { activeTab = "hron" });
        }
    }
}
