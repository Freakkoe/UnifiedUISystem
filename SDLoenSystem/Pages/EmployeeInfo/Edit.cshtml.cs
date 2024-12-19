//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using SDLoenSystem.Data;
//using SDLoenSystem.Models;

//namespace SDLoenSystem.Pages.EmployeeInfo
//{
//    public class EditModel : PageModel
//    {
//        private readonly SDLoenSystem.Data.SDLOENDbContext _context;

//        public EditModel(SDLoenSystem.Data.SDLOENDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public Models.EmployeeInfo EmployeeInfo { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var employeeinfo =  await _context.EmployeeInfos.FirstOrDefaultAsync(m => m.Id == id);
//            if (employeeinfo == null)
//            {
//                return NotFound();
//            }
//            EmployeeInfo = employeeinfo;
//            return Page();
//        }

//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more information, see https://aka.ms/RazorPagesCRUD.
//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Attach(EmployeeInfo).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EmployeeInfoExists(EmployeeInfo.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return RedirectToPage("./Index");
//        }

//        private bool EmployeeInfoExists(int id)
//        {
//            return _context.EmployeeInfos.Any(e => e.Id == id);
//        }
//    }
//}
