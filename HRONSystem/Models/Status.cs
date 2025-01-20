using System.ComponentModel.DataAnnotations;

namespace HRONSystem.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } // Status navn (f.eks. "Åben", "Lukket")

        public ICollection<JobAdvert> JobAdverts { get; set; } // En status kan være relateret til flere jobannoncer
    }
}
