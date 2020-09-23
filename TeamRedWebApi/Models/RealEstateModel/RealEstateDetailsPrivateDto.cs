using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedWebApi.Models.CommentModel;

namespace TeamRedWebApi.Models.RealEstateModel
{
    public class RealEstateDetailsPrivateDto
    {
        public string Contact { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
