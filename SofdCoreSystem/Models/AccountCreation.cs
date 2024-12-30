using System;
using System.ComponentModel.DataAnnotations;

namespace SofdCoreSystem.Models
{
    public class AccountCreation
    {
        public int Id { get; set; } // Primær nøgle

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } // Fornavn

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } // Efternavn

        public string Position { get; set; } // Stilling

        public string JobType { get; set; } // Jobtype

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } // Startdato

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } // Slutdato

        [Required]
        public string EmployeeNumber { get; set; } // Medarbejdernummer

        public decimal WorkHours { get; set; } // Arbejdstimer

        public DateTime CreationDate { get; set; } = DateTime.Now; // Oprettelsesdato

        public DateTime? LastUpdated { get; set; } // Sidst opdateret


        public ICollection<Relation> Relations { get; set; }

        public AccountCreation()
        {
            
        }

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

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(FirstName)}={FirstName}, {nameof(LastName)}={LastName}, {nameof(Position)}={Position}, {nameof(JobType)}={JobType}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(EndDate)}={EndDate.ToString()}, {nameof(EmployeeNumber)}={EmployeeNumber}, {nameof(WorkHours)}={WorkHours.ToString()}, {nameof(CreationDate)}={CreationDate.ToString()}, {nameof(LastUpdated)}={LastUpdated.ToString()}}}";
        }
    }
}
