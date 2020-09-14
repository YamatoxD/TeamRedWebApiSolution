using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedProject.Enitites
{
    public class RealEstate
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        [Required]
        public int Type { get; set; }
        public double rentingPrice { get; set; }
        public double purchasePrice { get; set; }
        public bool canBeRented { get; set; }
        public bool canBePurchased { get; set; }
        public string Contact { get; set; }

        [Required]
        public string yearOfConstruction { get; set; }

        [Required]
        public DateTimeOffset adCreated { get; set; }

        [ForeignKey("UserId")]
        public User Creator { get; set; }

        public int UserId { get; set; }

    }
}
