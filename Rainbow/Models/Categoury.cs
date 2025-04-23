using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rainbow.Models
{
    [Table("categoury")]
    public class Categoury
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Cake>cake { get; set; }
    }
}
