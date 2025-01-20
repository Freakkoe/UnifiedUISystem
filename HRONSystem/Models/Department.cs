using System.ComponentModel.DataAnnotations;

namespace HRONSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } // Afdelingens navn

        public ICollection<JobAdvert> JobAdverts { get; set; } // En afdeling kan have flere jobannoncer
    }
}
