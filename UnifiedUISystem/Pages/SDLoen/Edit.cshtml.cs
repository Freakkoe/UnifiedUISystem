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

        // Constructor to initialize the DbContext
        public EditModel(SDLOENDbContext context)
        {
            _context = context;
        }

        // Bind the EmployeeInfo object to the form fields
        [BindProperty]
        public EmployeeInfo EmployeeInfo { get; set; }

        // OnGet method to fetch and display the employee info based on the ID
        public IActionResult OnGet(int id)
        {
            // Retrieve the employee from the database by its ID
            EmployeeInfo = _context.EmployeeInfos.FirstOrDefault(e => e.Id == id);

            // If the employee is not found, return a NotFound response
            if (EmployeeInfo == null)
            {
                return NotFound();
            }

            // Return the page with the employee data
            return Page();
        }

        // OnPostAsync method to handle the form submission for updating employee info
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the form data is valid
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Modelstate is invalid");
                return Page();
            }

            // Logging the received employee ID (for debugging purposes)
            Console.WriteLine($"Received ID: {EmployeeInfo.Id}");

            // Retrieve the existing employee from the database using the ID
            var employeeInDb = await _context.EmployeeInfos.FirstOrDefaultAsync(e => e.Id == EmployeeInfo.Id);

            // If no matching employee is found in the database, return NotFound
            if (employeeInDb == null)
            {
                Console.WriteLine($"No employee found with ID: {EmployeeInfo.Id}");
                return NotFound();
            }

            // Update the existing employee information in the database
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
            employeeInDb.LastUpdated = DateTime.Now; // Update the LastUpdated field with the current date/time

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the Index page with a specified active tab
            Console.WriteLine("Redirecting to ../Index");
            return RedirectToPage("../Index", new { activeTab = "sdloen" });
        }
    }
}
