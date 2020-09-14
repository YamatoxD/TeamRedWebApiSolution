using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedProject.Enitites
{
    public class Rating
    {
        public int Id { get; set; }
        public int Ratings { get; set; }
        public User Rater { get; set; }
    }
}
