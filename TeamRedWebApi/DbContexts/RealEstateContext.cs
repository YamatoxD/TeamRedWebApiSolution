using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;

namespace TeamRedProject.DbContexts
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) 
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
