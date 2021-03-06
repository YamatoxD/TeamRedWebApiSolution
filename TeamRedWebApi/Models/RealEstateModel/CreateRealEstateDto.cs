﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.RealEstateModel
{
#pragma warning disable CS1591
    public class CreateRealEstateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int RentingPrice { get; set; }

        [Required]
        public int PurchasePrice { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public int ConstructionYear { get; set; }

        [Required]
        public int Type { get; set; }
        public string ImagUrl { get; set; }
    }
#pragma warning restore CS1591
}
