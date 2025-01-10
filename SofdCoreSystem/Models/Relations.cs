using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofdCoreSystem.Models
{
    // Class representing a relationship between an account and a position.
    public class Relation
    {
        // Primary key for the Relation entity.
        [Key]
        public int Id { get; set; }

        // Position property, indicating the role or job title in this relation.
        [Required] // This field is required.
        public string Position { get; set; }

        // Unit property, indicating the department or unit associated with the position.
        [Required] // This field is required.
        public string Unit { get; set; }

        // InheritsRights property, indicating if the rights from the associated account are inherited.
        public bool InheritsRights { get; set; }

        // Status property, indicating the current status of the position (e.g., active, inactive).
        [Required] // This field is required.
        public string Status { get; set; }

        // EmploymentType property, indicating the type of employment (e.g., full-time, part-time).
        [Required] // This field is required.
        public string EmploymentType { get; set; }

        // Foreign key to the AccountCreation entity. This represents the relationship between the position and the employee.
        [ForeignKey("AccountCreation")]
        public int AccountId { get; set; }

        // Navigation property to the associated AccountCreation entity. 
        public AccountCreation Account { get; set; }

        // Default constructor.
        public Relation()
        {

        }

        // Overloaded constructor to initialize all properties.
        public Relation(int id, string position, string unit, bool inheritsRights, string status, string employmentType, int accountId, AccountCreation account)
        {
            Id = id;
            Position = position;
            Unit = unit;
            InheritsRights = inheritsRights;
            Status = status;
            EmploymentType = employmentType;
            AccountId = accountId;
            Account = account;
        }

        // Override the ToString method to provide a string representation of the object.
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Position)}={Position}, {nameof(Unit)}={Unit}, {nameof(InheritsRights)}={InheritsRights.ToString()}, {nameof(Status)}={Status}, {nameof(EmploymentType)}={EmploymentType}, {nameof(AccountId)}={AccountId.ToString()}, {nameof(Account)}={Account}}}";
        }
    }
}
