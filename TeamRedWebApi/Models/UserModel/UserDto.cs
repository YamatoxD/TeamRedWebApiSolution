using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.UserModel
{
    public class UserDto
    {
        public string Name { get; set; }
        public double? AverageRating { get; set; }
        public int RealEstates { get; set; }
        public int Comments { get; set; }
    }
}
