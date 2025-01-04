using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace UnifiedUISystem.Pages.SDLoen
{
    public class EditModel : PageModel
    {
        private readonly SDLOENDbContext _context;

        public EditModel(SDLOENDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeInfo EmployeeInfo { get; set; }

        public IActionResult OnGet(int id)
        {
            EmployeeInfo = _context.EmployeeInfos.FirstOrDefault(e => e.Id == id);

            if (EmployeeInfo == null)
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
                return Page();
            }

            Console.WriteLine($"Recived ID: {EmployeeInfo.Id}");

            var employeeInDb = await _context.EmployeeInfos.FirstOrDefaultAsync(e => e.Id == EmployeeInfo.Id);

            if (employeeInDb == null)
            {
                Console.WriteLine($"No employee forund with ID: {EmployeeInfo.Id}");
                return NotFound();
            }

            // Opdater data
            employeeInDb.EmploymentDate = EmployeeInfo.EmploymentDate;
            employeeInDb.CPRNumber = EmployeeInfo.CPRNumber;
            employeeInDb.FirstName = EmployeeInfo.FirstName;
            employeeInDb.LastName = EmployeeInfo.LastName;
            employeeInDb.Address = EmployeeInfo.Address;
            employeeInDb.Position = EmployeeInfo.Position;
            employeeInDb.WorkHours = EmployeeInfo.WorkHours;
            employeeInDb.Institution = EmployeeInfo.Institution;
            employeeInDb.JobType = EmployeeInfo.JobType;
            employeeInDb.Department = EmployeeInfo.Department;
            employeeInDb.AuthorizationRequirement = EmployeeInfo.AuthorizationRequirement;
            employeeInDb.PhoneWork = EmployeeInfo.PhoneWork;
            employeeInDb.PhonePrivate = EmployeeInfo.PhonePrivate;
            employeeInDb.EmailWork = EmployeeInfo.EmailWork;
            employeeInDb.EmailPrivate = EmployeeInfo.EmailPrivate;
            employeeInDb.StartDate = EmployeeInfo.StartDate;
            employeeInDb.EndDate = EmployeeInfo.EndDate;
            employeeInDb.LastUpdated = DateTime.Now; // Opdater sidst opdateret dato

            await _context.SaveChangesAsync();

            Console.WriteLine("Redirecting to ../Index");
            return RedirectToPage("../Index");
        }
    }
}
