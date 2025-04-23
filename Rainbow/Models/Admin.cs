using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Rainbow.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
