using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.UserModel
{
#pragma warning disable CS1591
    public class UserDto
    {
        public string UserName { get; set; }

        public double? AverageRating { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }
    }
#pragma warning restore CS1591
}
