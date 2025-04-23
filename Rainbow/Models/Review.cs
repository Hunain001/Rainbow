using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rainbow.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Required]
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Cake")]
        public int CakeId { get; set; }

        public virtual Cake Cake { get; set; }
    }
}
