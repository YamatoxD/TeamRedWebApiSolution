﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using TeamRedWebApi.Enitites;
//using static System.Net.Mime.MediaTypeNames;

namespace TeamRedProject.Enitites
{
#pragma warning disable CS1591
    public class RealEstate
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [StringLength(1000, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        public int Type { get; set; }
        public int RentingPrice { get; set; }
        public int PurchasePrice { get; set; }
        public bool CanBeRented { get; set; }
        public bool CanBePurchased { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string ConstructionYear { get; set; }

        [Required]
        public DateTimeOffset AdCreated { get; set; }

        [ForeignKey("UserId")]
        public User Creator { get; set; }

        [Required]
        public int UserId { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Image> Images { get; set; } = new List<Image>();
    }
#pragma warning restore CS1591
}
