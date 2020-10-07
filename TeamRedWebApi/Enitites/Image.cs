using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;

namespace TeamRedWebApi.Enitites
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [ForeignKey("RealEstateId")]
        public RealEstate RealEstate { get; set; }
        public int RealEstateId { get; set; }
    }
}
