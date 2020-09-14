using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedProject.Enitites
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public double averageRating { get; set; }
        public List<RealEstate> realEstates { get; set; }
        public List<Rating> ratings { get; set; }
    }
}
