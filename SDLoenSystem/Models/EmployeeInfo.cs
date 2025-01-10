using System; // Provides base class definitions and fundamental types.
using System.ComponentModel.DataAnnotations; // Provides attributes for data validation.

namespace SDLoenSystem.Models
{
    // Represents an employee's information in the system.
    public class EmployeeInfo
    {
        [Key] // Specifies that this property is the primary key of the table.
        public int Id { get; set; } // Primary key for the EmployeeInfo entity.

        [Required(ErrorMessage = "Date is required")] // Ensures this property is mandatory.
        [Display(Name = "Ansættelses Dato")] // Specifies the display name for this property.
        public string EmploymentDate { get; set; } // The employment date of the employee.

        [Required(ErrorMessage = "CPR-Number is required")] // Ensures this property is mandatory.
        [Display(Name = "CPR-Nummer")] // Specifies the display name for this property.
        public string CPRNumber { get; set; } // The CPR (Central Person Register) number of the employee.

        [Required(ErrorMessage = "Name is required")] // Ensures this property is mandatory.
        [Display(Name = "Navn")] // Specifies the display name for this property.
        public string FirstName { get; set; } // The first name of the employee.

        [Required(ErrorMessage = "Lastname is required")] // Ensures this property is mandatory.
        [Display(Name = "Efternavn")] // Specifies the display name for this property.
        public string LastName { get; set; } // The last name of the employee.

        [Required(ErrorMessage = "Address is required")] // Ensures this property is mandatory.
        [Display(Name = "Adresse")] // Specifies the display name for this property.
        public string Address { get; set; } // The address of the employee.

        [Required(ErrorMessage = "Position is required")] // Ensures this property is mandatory.
        [Display(Name = "Stilling")] // Specifies the display name for this property.
        public string Position { get; set; } // The position or job title of the employee.

        [Required(ErrorMessage = "WorkHours is required")] // Ensures this property is mandatory.
        [Display(Name = "Arbejdstimer")] // Specifies the display name for this property.
        public int WorkHours { get; set; } // The number of hours the employee works per week.

        [Required(ErrorMessage = "Institution is required")] // Ensures this property is mandatory.
        [Display(Name = "Institution")] // Specifies the display name for this property.
        public string Institution { get; set; } // The institution the employee works for (e.g., company or organization).

        [Required(ErrorMessage = "JobType is required")] // Ensures this property is mandatory.
        [Display(Name = "Job Type")] // Specifies the display name for this property.
        public string JobType { get; set; } // The type of job (e.g., full-time, part-time, contract).

        [Required(ErrorMessage = "Department is required")] // Ensures this property is mandatory.
        [Display(Name = "Afdeling")] // Specifies the display name for this property.
        public string Department { get; set; } // The department the employee works in.

        [Required(ErrorMessage = "AuthorizationRequirement is required")] // Ensures this property is mandatory.
        [Display(Name = "Autorisation")] // Specifies the display name for this property.
        public string AuthorizationRequirement { get; set; } // Any specific authorization required for the employee.

        [Required(ErrorMessage = "PhoneWork is required")] // Ensures this property is mandatory.
        [Display(Name = "Arbejdstelefon")] // Specifies the display name for this property.
        public string PhoneWork { get; set; } // The work phone number of the employee.

        [Required(ErrorMessage = "PhonePrivate is required")] // Ensures this property is mandatory.
        [Display(Name = "Privat telefon")] // Specifies the display name for this property.
        public string PhonePrivate { get; set; } // The private phone number of the employee.

        [Required(ErrorMessage = "EmailWork is required")] // Ensures this property is mandatory.
        [Display(Name = "Arbejdsmail")] // Specifies the display name for this property.
        public string EmailWork { get; set; } // The work email address of the employee.

        [Required(ErrorMessage = "EmailPrivate is required")] // Ensures this property is mandatory.
        [Display(Name = "Privat Email")] // Specifies the display name for this property.
        public string EmailPrivate { get; set; } // The personal email address of the employee.

        [Required(ErrorMessage = "StartDate is required")] // Ensures this property is mandatory.
        [Display(Name = "Start Dato")] // Specifies the display name for this property.
        public DateTime? StartDate { get; set; } // The start date of the employee's current position.

        public DateTime? EndDate { get; set; } // The end date of the employee's contract or tenure. Nullable for ongoing employees.

        public DateTime? LastUpdated { get; set; } // The date when the employee's information was last updated.

        public DateTime CreationDate { get; set; } // The creation date of the employee's record.

        // Default constructor. Initializes a new instance of the EmployeeInfo class.
        public EmployeeInfo()
        {
        }

        // Parameterized constructor for initializing all the properties.
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

        // Overrides the default ToString method to provide a string representation of the employee's information.
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(EmploymentDate)}={EmploymentDate}, {nameof(CPRNumber)}={CPRNumber}, {nameof(FirstName)}={FirstName}, {nameof(LastName)}={LastName}, {nameof(Address)}={Address}, {nameof(Position)}={Position}, {nameof(WorkHours)}={WorkHours.ToString()}, {nameof(Institution)}={Institution}, {nameof(JobType)}={JobType}, {nameof(Department)}={Department}, {nameof(AuthorizationRequirement)}={AuthorizationRequirement}, {nameof(PhoneWork)}={PhoneWork}, {nameof(PhonePrivate)}={PhonePrivate}, {nameof(EmailWork)}={EmailWork}, {nameof(EmailPrivate)}={EmailPrivate}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(EndDate)}={EndDate.ToString()}, {nameof(LastUpdated)}={LastUpdated.ToString()}, {nameof(CreationDate)}={CreationDate.ToString()}}}";
        }
    }
}
