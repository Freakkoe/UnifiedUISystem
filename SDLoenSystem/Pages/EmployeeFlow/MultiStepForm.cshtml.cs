using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDLoenSystem.Data;
using SDLoenSystem.Models;

namespace SDLoenSystem.Pages.EmployeeFlow
{
    public class MultiStepFormModel : PageModel
    {
        private readonly SDLOENDbContext _context;

        public MultiStepFormModel(SDLOENDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.EmployeeInfo EmployeeInfo { get; set; } = new Models.EmployeeInfo();

        public void OnGet()
        {
            // Initialisering om nødvendigt
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Gemmer data i databasen
            _context.EmployeeInfos.Add(EmployeeInfo);
            _context.SaveChanges();

            return RedirectToPage("/EmployeeInfo/Index");
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using SDLoenSystem.Data;
//using SDLoenSystem.Models;

//namespace SDLoenSystem.Pages.EmployeeFlow
//{
//    public class MultiStepFormModel : PageModel
//    {
//        private readonly SDLOENDbContext _context;

//        public MultiStepFormModel(SDLOENDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public Models.EmployeeInfo EmployeeInfo { get; set; } = new Models.EmployeeInfo();

//        [BindProperty]
//        public int CurrentStep { get; set; } = 1;

//        public IActionResult OnGet()
//        {
//            if (EmployeeInfo == null)
//            {
//                EmployeeInfo = new Models.EmployeeInfo();
//            }

//            if (CurrentStep == 0)
//            {
//                CurrentStep = 1;
//            } 
//            // Sørger for, at EmployeeInfo aldrig er null

//            //EmployeeInfo ??= new Models.EmployeeInfo();
//            //CurrentStep = 1;
//            return Page();
//        }

//        public IActionResult OnPost(int CurrentStep)
//        {
//            Console.WriteLine($"Current Step: {CurrentStep}"); //TROUBLESHOOTING/Debug
//            Console.WriteLine($"EmploymentDate: {EmployeeInfo?.EmploymentDate}"); //TROUBLESHOOTING/Debug
//            Console.WriteLine($"CPRNumber: {EmployeeInfo?.CPRNumber}"); //TROUBLESHOOTING/Debug

//            this.CurrentStep = CurrentStep;

//            //if (CurrentStep == 1)
//            //{
//            //    if (string.IsNullOrEmpty(EmployeeInfo.CPRNumber) || EmployeeInfo.EmploymentDate == DateTime.MinValue)
//            //    {
//            //        ModelState.AddModelError("", "Ansættelsedato og CPR-Nummer skal udfyldes.");
//            //        return Page();
//            //    }
//            //}
//            //else if (CurrentStep == 2)
//            //{
//            //    if (string.IsNullOrEmpty(EmployeeInfo.FirstName) || string.IsNullOrEmpty(EmployeeInfo.LastName))
//            //    {
//            //        ModelState.AddModelError("", "fornavn og efternavn skal udfyldes");
//            //        return Page();
//            //    }
//            //}
//            //else if (CurrentStep == 3)
//            //{
//            //    if (string.IsNullOrEmpty(EmployeeInfo.Position) || EmployeeInfo.WorkHours <= 0)
//            //    {
//            //        ModelState.AddModelError("", "Stilling og arbejdstid skal udfyldes");
//            //        return Page();
//            //    }
//            //}

//            if (!ModelState.IsValid)
//            {
//                Console.WriteLine("ModelState is invalid");
//                return Page();
//            }

//            // Avancerer trin
//            Console.WriteLine($"current step before update: {CurrentStep}");
//            CurrentStep++;
//            Console.WriteLine($"current step after update: {CurrentStep}");


//            // Hvis trin 4 er færdigt, gem data i databasen
//            if (CurrentStep > 4)
//            {
//                Console.WriteLine("Saving EmployeeInfo to database");
//                _context.EmployeeInfos.Add(EmployeeInfo);
//                _context.SaveChanges();
//                return RedirectToPage("Index");
//            }

//            Console.WriteLine($"Next step set to: {CurrentStep}");
//            return Page();
//        }
//    }
//}

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using SDLoenSystem.Data;
//using SDLoenSystem.Models;

//namespace SDLoenSystem.Pages.EmployeeFlow
//{
//    public class MultiStepFormModel : PageModel
//    {
//        private readonly SDLOENDbContext _context;

//        public MultiStepFormModel(SDLOENDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public Models.EmployeeInfo EmployeeInfo { get; set; }

//        [BindProperty]
//        public int CurrentStep { get; set; } = 1;

//        public IActionResult OnGet()
//        {
//            EmployeeInfo ??= new Models.EmployeeInfo();
//            CurrentStep = 1;
//            return Page();
//        }

//        public IActionResult OnPost(int step)
//        {
//            Console.WriteLine($"Current Step: {step}");
//            Console.WriteLine($"EmploymentDate: {EmployeeInfo?.EmploymentDate}");
//            Console.WriteLine($"CPRNumber: {EmployeeInfo?.CPRNumber}");
//            if (!ModelState.IsValid)
//            {
//                Console.WriteLine("ModelState is invalid");
//                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
//                {
//                    Console.WriteLine(error.ErrorMessage);
//                }
//                CurrentStep = step;
//                return Page();
//            }

//            // Gem data midlertidigt i TempData
//            switch (step)
//            {
//                case 1:
//                    TempData["EmploymentDate"] = EmployeeInfo.EmploymentDate;
//                    TempData["CPRNumber"] = EmployeeInfo.CPRNumber;
//                    break;
//                case 2:
//                    TempData["FirstName"] = EmployeeInfo.FirstName;
//                    TempData["LastName"] = EmployeeInfo.LastName;
//                    TempData["Address"] = EmployeeInfo.Address;
//                    break;
//                case 3:
//                    TempData["Position"] = EmployeeInfo.Position;
//                    TempData["WorkHours"] = EmployeeInfo.WorkHours;
//                    TempData["Institution"] = EmployeeInfo.Institution;
//                    break;
//            }

//            // Opdatér trin
//            ModelState.Clear();
//            CurrentStep = step + 1;

//            // Gem data i trin 4
//            if (CurrentStep > 4)
//            {
//                _context.EmployeeInfos.Add(EmployeeInfo);
//                _context.SaveChanges();
//                return RedirectToPage("Index"); // Redirect til oversigt
//            }

//            return Page();
//        }
//    }
//}
