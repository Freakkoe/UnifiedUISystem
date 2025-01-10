using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SofdCoreSystem.Models
{
    // Class representing an employee's account creation data.
    public class AccountCreation
    {
        // Primary key for the AccountCreation entity.
        public int Id { get; set; }

        // FirstName property with validation attributes.
        [Required(ErrorMessage = "FirstName is required")] // Ensure this field is filled in.
        [Display(Name = "Navn")] // Display name for the field in UI.
        [StringLength(50)] // Limit the length to 50 characters.
        public string FirstName { get; set; } // Fornavn (First name)

        // LastName property with validation attributes.
        [Required(ErrorMessage = "LastName is required")] // Ensure this field is filled in.
        [Display(Name = "Efternavn")] // Display name for the field in UI.
        [StringLength(50)] // Limit the length to 50 characters.
        public string LastName { get; set; } // Efternavn (Last name)

        // Position property with validation attributes.
        [Required(ErrorMessage = "Position is required")] // Ensure this field is filled in.
        [Display(Name = "Stilling")] // Display name for the field in UI.
        public string Position { get; set; } // Stilling (Position)

        // JobType property with validation attributes.
        [Required(ErrorMessage = "JobType is required")] // Ensure this field is filled in.
        [Display(Name = "Job Type")] // Display name for the field in UI.
        public string JobType { get; set; } // Jobtype (Job type)

        // StartDate property, marked with the DataType attribute to indicate a Date.
        [DataType(DataType.Date)] // Specifies that this is a date.
        public DateTime StartDate { get; set; } // Startdato (Start date)

        // EndDate property, nullable to allow for an ongoing job.
        [DataType(DataType.Date)] // Specifies that this is a date.
        public DateTime? EndDate { get; set; } // Slutdato (End date)

        // EmployeeNumber property with validation attributes.
        [Required(ErrorMessage = "EmployeeNumber is required")] // Ensure this field is filled in.
        [Display(Name = "Medarbejder Nummer")] // Display name for the field in UI.
        public string EmployeeNumber { get; set; } // Medarbejdernummer (Employee number)

        // WorkHours property with validation attributes.
        [Required(ErrorMessage = "WorkHours is required")] // Ensure this field is filled in.
        [Display(Name = "Arbejdstimer")] // Display name for the field in UI.
        public decimal WorkHours { get; set; } // Arbejdstimer (Work hours)

        // CreationDate property with default value set to current time.
        public DateTime CreationDate { get; set; } = DateTime.Now; // Oprettelsesdato (Creation date)

        // LastUpdated property, nullable to allow for an undefined last update.
        public DateTime? LastUpdated { get; set; } // Sidst opdateret (Last updated)

        // Navigation property to represent the relation to the 'Relation' entity.
        public ICollection<Relation> Relations { get; set; } = new List<Relation>();

        // Default constructor.
        public AccountCreation()
        {

        }

        // Overloaded constructor to initialize all properties.
        public AccountCreation(int id, string firstName, string lastName, string position, string jobType, DateTime startDate, DateTime? endDate, string employeeNumber, decimal workHours, DateTime creationDate, DateTime? lastUpdated)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            JobType = jobType;
            StartDate = startDate;
            EndDate = endDate;
            EmployeeNumber = employeeNumber;
            WorkHours = workHours;
            CreationDate = creationDate;
            LastUpdated = lastUpdated;
        }

        // Override the ToString method to provide a string representation of the object.
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(FirstName)}={FirstName}, {nameof(LastName)}={LastName}, {nameof(Position)}={Position}, {nameof(JobType)}={JobType}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(EndDate)}={EndDate.ToString()}, {nameof(EmployeeNumber)}={EmployeeNumber}, {nameof(WorkHours)}={WorkHours.ToString()}, {nameof(CreationDate)}={CreationDate.ToString()}, {nameof(LastUpdated)}={LastUpdated.ToString()}}}";
        }
    }
}
