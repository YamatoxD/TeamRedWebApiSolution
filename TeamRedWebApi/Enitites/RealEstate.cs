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
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        [Required]
        public int Type { get; set; }
        public int RentingPrice { get; set; }
        public int PurchasePrice { get; set; }
        public bool CanBeRented { get; set; }
        public bool CanBePurchased { get; set; }
        public string Contact { get; set; }

        [Required]
        public string ConstructionYear { get; set; }

        [Required]
        public DateTimeOffset AdCreated { get; set; }

        [ForeignKey("UserId")]
        public User Creator { get; set; }

        [Required]
        public int UserId { get; set; }
        public string AverageRating { get; set; }
        public string Ratings { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
