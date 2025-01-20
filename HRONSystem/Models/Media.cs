using System.ComponentModel.DataAnnotations;

namespace HRONSystem.Models
{
    public class Media
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } // Medietyper (f.eks. "LinkedIn", "JobIndex")

        public ICollection<JobAdvert> JobAdverts { get; set; } // Et medie kan bruges til flere jobannoncer
    }
}
