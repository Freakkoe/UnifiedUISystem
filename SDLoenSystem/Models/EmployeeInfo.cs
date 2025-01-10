using System.ComponentModel.DataAnnotations;

namespace SDLoenSystem.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; } // Primær nøgle

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Ansættelses Dato")]
        public string EmploymentDate { get; set; }

        [Required(ErrorMessage = "CPR-Number is required")]
        [Display(Name = "CPR-Nummer")]
        public string CPRNumber { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Navn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Stilling")]
        public string Position { get; set; }

        [Required(ErrorMessage = "WorkHours is required")]
        [Display(Name = "Arbejdstimer")]
        public int WorkHours { get; set; }

        [Required(ErrorMessage = "Institution is required")]
        [Display(Name = "Institution")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "JobType is required")]
        [Display(Name = "Job Type")]
        public string JobType { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Afdeling")]
        public string Department { get; set; }

        [Required(ErrorMessage = "AuthorizationRequirement is required")]
        [Display(Name = "Autorisation")]
        public string AuthorizationRequirement { get; set; }

        [Required(ErrorMessage = "PhoneWork is required")]
        [Display(Name = "Arbejdstelefon")]
        public string PhoneWork { get; set; }

        [Required(ErrorMessage = "PhonePrivate is required")]
        [Display(Name = "Privat telefon")]
        public string PhonePrivate { get; set; }

        [Required(ErrorMessage = "EmailWork is required")]
        [Display(Name = "Arbejdsmail")]
        public string EmailWork { get; set; }

        [Required(ErrorMessage = "EmailPrivate is required")]
        [Display(Name = "Privat Email")]
        public string EmailPrivate { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        [Display(Name = "Start Dato")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime CreationDate { get; set; }

        public EmployeeInfo()
        {
            
        }

        public EmployeeInfo(int id, string employmentDate, string cPRNumber, string firstName, string lastName, string address, string position, int workHours, string institution, string jobType, string department, string authorizationRequirement, string phoneWork, string phonePrivate, string emailWork, string emailPrivate, DateTime? startDate, DateTime? endDate, DateTime? lastUpdated, DateTime creationDate)
        {
            Id = id;
            EmploymentDate = employmentDate;
            CPRNumber = cPRNumber;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Position = position;
            WorkHours = workHours;
            Institution = institution;
            JobType = jobType;
            Department = department;
            AuthorizationRequirement = authorizationRequirement;
            PhoneWork = phoneWork;
            PhonePrivate = phonePrivate;
            EmailWork = emailWork;
            EmailPrivate = emailPrivate;
            StartDate = startDate;
            EndDate = endDate;
            LastUpdated = lastUpdated;
            CreationDate = creationDate;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(EmploymentDate)}={EmploymentDate}, {nameof(CPRNumber)}={CPRNumber}, {nameof(FirstName)}={FirstName}, {nameof(LastName)}={LastName}, {nameof(Address)}={Address}, {nameof(Position)}={Position}, {nameof(WorkHours)}={WorkHours.ToString()}, {nameof(Institution)}={Institution}, {nameof(JobType)}={JobType}, {nameof(Department)}={Department}, {nameof(AuthorizationRequirement)}={AuthorizationRequirement}, {nameof(PhoneWork)}={PhoneWork}, {nameof(PhonePrivate)}={PhonePrivate}, {nameof(EmailWork)}={EmailWork}, {nameof(EmailPrivate)}={EmailPrivate}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(EndDate)}={EndDate.ToString()}, {nameof(LastUpdated)}={LastUpdated.ToString()}, {nameof(CreationDate)}={CreationDate.ToString()}}}";
        }
    }
}
