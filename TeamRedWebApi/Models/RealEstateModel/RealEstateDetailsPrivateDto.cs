using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedWebApi.Models.CommentModel;

namespace TeamRedWebApi.Models.RealEstateModel
{
#pragma warning disable CS1591
    public class RealEstateDetailsPrivateDto
    {
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public string Contact { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public int RentingPrice { get; set; }

        public int PurchasePrice { get; set; }

        public bool CanBeRented { get; set; }

        public bool CanBePurchased { get; set; }

        public string ConstructionYear { get; set; }

        public DateTimeOffset AdCreated { get; set; }

        public int Type { get; set; }
    }
#pragma warning restore CS1591
}
