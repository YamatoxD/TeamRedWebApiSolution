using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.RealEstateModel
{
    public class RealEstateDetailsDto
    {
        public string CreatedOn { get; set; }
        public string ConstructionYear { get; set; }
        public string Adress { get; set; }
        public string RealEstateType { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int SellingPrice { get; set; }
        public int RentingPrice { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBeRented { get; set; }
    }
}

