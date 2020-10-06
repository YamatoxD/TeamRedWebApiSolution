using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.RealEstateModel
{
#pragma warning disable CS1591
    public class RealEstateDetailsDto
    {

        public DateTimeOffset AdCreated { get; set; }

        public string ConstructionYear { get; set; }

        public string Address { get; set; }

        public int Type { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public int PurchasePrice { get; set; }

        public int RentingPrice { get; set; }

        public bool CanBePurchased { get; set; }

        public bool CanBeRented { get; set; }
    }
#pragma warning restore CS1591
}

