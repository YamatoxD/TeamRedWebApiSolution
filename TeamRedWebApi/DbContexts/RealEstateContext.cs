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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User user1 = new User()
            {
                Id = 1,
                Name = "Test name",
                Email = "testemail@email.com",
                Password = "Password12345.",
            };
            
            modelBuilder.Entity<User>().HasData(user1);

            //List<RealEstate> _realEstates = new List<RealEstate>()
            //{
            //    new RealEstate()
            //    {
            //        Id = 1,
            //        Title = "Real estate Title",
            //        Address = "some address",
            //        Description = "this is a description of the real estate",
            //        Type = 1,
            //        ConstructionYear = "1990",
            //        adCreated = DateTime.Now,
            //        UserId = user1.Id
            //    }
            //};

            //user1.realEstates = _realEstates;


        }
    }
}
