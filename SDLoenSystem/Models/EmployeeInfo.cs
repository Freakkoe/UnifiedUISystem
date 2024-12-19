using System.ComponentModel.DataAnnotations;

namespace SDLoenSystem.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; } // Primær nøgle
        public string EmploymentDate { get; set; }
        public string CPRNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int WorkHours { get; set; }
        public string Institution { get; set; }
        public string JobType { get; set; }
        public string Department { get; set; }
        public string AuthorizationRequirement { get; set; }
        public string PhoneWork { get; set; }
        public string PhonePrivate { get; set; }
        public string EmailWork { get; set; }
        public string EmailPrivate { get; set; }
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
