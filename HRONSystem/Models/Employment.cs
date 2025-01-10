using System; // Provides base class definitions and fundamental types.
using System.ComponentModel.DataAnnotations; // Provides attributes for data validation.

namespace HRONSystem.Models
{
    // Represents an Employment record in the system.
    public class Employment
    {
        [Key] // Specifies that this property is the primary key of the table.
        public int EmploymentID { get; set; } // Primary key for the Employment entity.

        [Required] // Ensures this property is mandatory.
        public string JobTitle { get; set; } // Title of the job position.

        [Required] // Ensures this property is mandatory.
        public string EmployeeName { get; set; } // Name of the employee.

        [Required] // Ensures this property is mandatory.
        [DataType(DataType.Date)] // Specifies that this property is of date type.
        public DateTime StartDate { get; set; } // The start date of the employment.

        public string Status { get; set; } // Employment status, e.g., Active or Inactive.
        public string Department { get; set; } // Department or job placement.
        public string Notes { get; set; } // Additional notes related to the employment.

        // Default constructor.
        public Employment()
        {
        }

        // Parameterized constructor for initializing properties.
        public Employment(int employmentID, string jobTitle, string employeeName, DateTime startDate, string status, string department, string notes)
        {
            EmploymentID = employmentID;
            JobTitle = jobTitle;
            EmployeeName = employeeName;
            StartDate = startDate;
            Status = status;
            Department = department;
            Notes = notes;
        }

        // Overrides the default ToString method to provide a string representation of the object.
        public override string ToString()
        {
            return $"{{{nameof(EmploymentID)}={EmploymentID.ToString()}, {nameof(JobTitle)}={JobTitle}, {nameof(EmployeeName)}={EmployeeName}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(Status)}={Status}, {nameof(Department)}={Department}, {nameof(Notes)}={Notes}}}";
        }
    }
}
