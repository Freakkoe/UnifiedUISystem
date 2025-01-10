using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofdCoreSystem.Models
{
    public class Relation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Unit { get; set; }

        public bool InheritsRights { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string EmploymentType { get; set; }

        // Fremmed nøgle til AccountCreation
        [ForeignKey("AccountCreation")]
        public int AccountId { get; set; }
        public AccountCreation Account { get; set; }

        public Relation()
        {
            
        }

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

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Position)}={Position}, {nameof(Unit)}={Unit}, {nameof(InheritsRights)}={InheritsRights.ToString()}, {nameof(Status)}={Status}, {nameof(EmploymentType)}={EmploymentType}, {nameof(AccountId)}={AccountId.ToString()}, {nameof(Account)}={Account}}}";
        }
    }
}
