using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedProject.Enitites
{
#pragma warning disable CS1591
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int Ratings { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? UserId { get; set; }
    }
#pragma warning restore CS1591
}
