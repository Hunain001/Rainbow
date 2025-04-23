using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rainbow.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cake
    {
        [Key]
        public int CId { get; set; }  

        public string CakeName { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string? image { get; set; }

        public int id { get; set; }  

        [ForeignKey("id")]
        public Categoury Categoury { get; set; }

        public string isspecial { get; set; }

     
    }

}
