using System;
using System.ComponentModel.DataAnnotations;

namespace HRONSystem.Models
{
    public class Employment
    {
        [Key]
        public int EmploymentID { get; set; } //Primary Key

        [Required]
        public string JobTitle { get; set; } //Title of job

        [Required]
        public string EmployeeName { get; set; } //Name of Employee

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } //Date of Start

        public string Status { get; set; } // Status Ex. Active og Inactive
        public string Department { get; set; } // Job placement/Department
        public string Notes { get; set; } // Notes if any

        public Employment()
        {
            
        }

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

        public override string ToString()
        {
            return $"{{{nameof(EmploymentID)}={EmploymentID.ToString()}, {nameof(JobTitle)}={JobTitle}, {nameof(EmployeeName)}={EmployeeName}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(Status)}={Status}, {nameof(Department)}={Department}, {nameof(Notes)}={Notes}}}";
        }
    }
}
