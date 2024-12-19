using System.ComponentModel.DataAnnotations;

namespace SDLoenSystem.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; }

        [Required]
        public string CPRNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        [Required]
        public DateTime EmploymentDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal WorkHours { get; set; }

        public string Position { get; set; }
        public string Institution { get; set; }
        public string Department { get; set; }
        public string Comments { get; set; }

        public EmployeeInfo()
        {
            
        }

        public EmployeeInfo(int id, string cPRNumber, string firstName, string lastName, string address, string city, string postalCode, string country, string workPhone, string mobilePhone, string email, DateTime employmentDate, DateTime? endDate, decimal workHours, string position, string institution, string department, string comments)
        {
            Id = id;
            CPRNumber = cPRNumber;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            PostalCode = postalCode;
            Country = country;
            WorkPhone = workPhone;
            MobilePhone = mobilePhone;
            Email = email;
            EmploymentDate = employmentDate;
            EndDate = endDate;
            WorkHours = workHours;
            Position = position;
            Institution = institution;
            Department = department;
            Comments = comments;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(CPRNumber)}={CPRNumber}, {nameof(FirstName)}={FirstName}, {nameof(LastName)}={LastName}, {nameof(Address)}={Address}, {nameof(City)}={City}, {nameof(PostalCode)}={PostalCode}, {nameof(Country)}={Country}, {nameof(WorkPhone)}={WorkPhone}, {nameof(MobilePhone)}={MobilePhone}, {nameof(Email)}={Email}, {nameof(EmploymentDate)}={EmploymentDate.ToString()}, {nameof(EndDate)}={EndDate.ToString()}, {nameof(WorkHours)}={WorkHours.ToString()}, {nameof(Position)}={Position}, {nameof(Institution)}={Institution}, {nameof(Department)}={Department}, {nameof(Comments)}={Comments}}}";
        }
    }
}
