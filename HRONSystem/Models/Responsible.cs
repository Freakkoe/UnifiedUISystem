using System.ComponentModel.DataAnnotations;

namespace HRONSystem.Models
{
    public class Responsible
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } // Navn på den ansvarlige person

        public ICollection<JobAdvert> JobAdverts { get; set; } // En ansvarlig kan være tilknyttet flere jobannoncer
    }
}
