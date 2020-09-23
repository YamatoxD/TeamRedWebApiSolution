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
            User user = new User()
            {
                Id = 1,
                Name = "Jesper Eriksson",
                Email = "Jesperceriksson@outlook.com",
                Password = "uYEBjhai938/¤(#&",
                ratings = null,
                realEstates = null,
                averageRating = null
            };
            User user2 = new User()
            {
                Id = 2,
                Name = "Johan Karlsson",
                Email = "JohanKarlsson@outlook.com",
                Password = "sfsdifhdsofdsh/¤(#&",
                ratings = null,
                realEstates = null,
                averageRating = null
            };
            User user3 = new User()
            {
                Id = 3,
                Name = "Felix Alexandersson",
                Email = "FelixAlexandersson@outlook.com",
                Password = "dsadasdasfg/¤(#&",
                ratings = null,
                realEstates = null,
                averageRating = null
            };
            User user4 = new User()
            {
                Id = 4,
                Name = "Erik Olofsson",
                Email = "ErikOlofsson@gmail.com",
                Password = "sfisdfiub(T(/¤(#&",
                ratings = null,
                realEstates = null,
                averageRating = null
            };
            User user5 = new User()
            {
                Id = 5,
                Name = "Nicklas Andreasson",
                Email = "NicklasAndreasson@protonmail.com",
                Password = "dasdnsafba//¤(#&",
                ratings = null,
                realEstates = null,
                averageRating = null
            };
            User user6 = new User()
            {
                Id = 6,
                Name = "Yngve Opendal",
                Email = "YngveOpendal@outlook.com",
                Password = "daskdjbasdkasb/¤(#&",
                ratings = null,
                realEstates = null,
                averageRating = null
            };
            User user7 = new User()
            {
                Id = 7,
                Name = "Andreas Svensson",
                Email = "AndreasSvensson@swipnet.se",
                Password = "dsfsjfdsf8/¤(#&",
                ratings = null,
                realEstates = null,
                averageRating = null
            };

            RealEstate RealEstate1 = new RealEstate()
            {
                Id = 1,
                Name = "My lovely home",
                Address = "Ostindiegatan 14B",
                adCreated = DateTime.Now,
                canBePurchased = true,
                canBeRented = true,
                rentingPrice = 1000,
                purchasePrice = 100000,
                Contact = "0703357725",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user.Id,
                yearOfConstruction = "1935"

            };
            RealEstate RealEstate2 = new RealEstate()
            {
                Id = 2,
                Name = "My cool home",
                Address = "aspelundgatan 9",
                adCreated = DateTime.Now,
                canBePurchased = true,
                canBeRented = true,
                rentingPrice = 1000,
                purchasePrice = 100000,
                Contact = "0709765456",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user2.Id,
                yearOfConstruction = "1956"

            };
            RealEstate RealEstate3 = new RealEstate()
            {
                Id = 3,
                Name = "My nice home",
                Address = "Falsbogatan 18",
                adCreated = DateTime.Now,
                canBePurchased = true,
                canBeRented = true,
                rentingPrice = 1000,
                purchasePrice = 100000,
                Contact = "0709987656",
                Description = "A lovely home for a lovely family",
                Type = 1,
                UserId = user3.Id,
                yearOfConstruction = "1999"

            };
            RealEstate RealEstate4 = new RealEstate()
            {
                Id = 4,
                Name = "My nice home",
                Address = "Höglundsgatan 15",
                adCreated = DateTime.Now,
                canBePurchased = true,
                canBeRented = true,
                rentingPrice = 1000,
                purchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user3.Id,
                yearOfConstruction = "1934"
            };
            RealEstate RealEstate5 = new RealEstate()
            {
                Id = 5,
                Name = "My nice bungalow",
                Address = "Mariaplan 5",
                adCreated = DateTime.Now,
                canBePurchased = true,
                canBeRented = true,
                rentingPrice = 1000,
                purchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user4.Id,
                yearOfConstruction = "1987"
            };
            RealEstate RealEstate6 = new RealEstate()
            {
                Id = 6,
                Name = "My nice bungalow",
                Address = "Svanebäcksgatan 5",
                adCreated = DateTime.Now,
                canBePurchased = true,
                canBeRented = true,
                rentingPrice = 1000,
                purchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 1,
                UserId = user5.Id,
                yearOfConstruction = "1876"
            };

            RealEstate RealEstate7 = new RealEstate()
            {
                Id = 7,
                Name = "My nice bungalow",
                Address = "Fastmansvägen 89",
                adCreated = DateTime.Now,
                canBePurchased = true,
                canBeRented = true,
                rentingPrice = 1000,
                purchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user6.Id,
                yearOfConstruction = "1657"
            };
            Comment comment1 = new Comment()
            {
                Id = 1,
                RealEstate = RealEstate1,
                RealEstateId = RealEstate1.Id,
                Creator = user,
                UserId = user.Id,
                CommentMade = DateTime.Now,
                Content = "This is a lovely home."
            };

            Comment comment2 = new Comment()
            {
                Id = 2,
                RealEstate = RealEstate2,
                RealEstateId = RealEstate2.Id,
                Creator = user2,
                UserId = user2.Id,
                CommentMade = new DateTime(2003, 3, 5),
                Content = "How much is this home?"
            };
            Comment comment3 = new Comment()
            {
                Id = 3,
                RealEstate = RealEstate2,
                RealEstateId = RealEstate2.Id,
                Creator = user3,
                UserId = user3.Id,
                Commented = comment2,
                CommentId = comment2.Id,
                CommentMade = new DateTime(2003, 3, 6),
                Content = "The premises is $100000"
            };
            Comment comment4 = new Comment()
            {
                Id = 4,
                RealEstate = RealEstate3,
                RealEstateId = RealEstate3.Id,
                Creator = user3,
                UserId = user3.Id,
                CommentMade = new DateTime(2005, 06, 02)
            };
            Comment comment5 = new Comment()
            {
                Id = 5,
                RealEstate = RealEstate3,
                RealEstateId = RealEstate3.Id,
                Creator = user4,
                UserId = user4.Id,
                CommentMade = new DateTime(2005, 06, 02)
            };
            Comment comment6 = new Comment()
            {
                Id = 6,
                RealEstate = RealEstate4,
                RealEstateId = RealEstate4.Id,
                Creator = user5,
                UserId = user5.Id,
                CommentMade = new DateTime(2006, 05, 12)
            };
            Comment comment7 = new Comment()
            {
                Id = 7,
                RealEstate = RealEstate5,
                RealEstateId = RealEstate5.Id,
                Creator = user6,
                UserId = user6.Id,
                CommentMade = new DateTime(2007, 10, 19)
            };


            modelBuilder.Entity<User>().HasData(
                user,
                user2,
                user3
                );
            modelBuilder.Entity<RealEstate>().HasData(
                RealEstate1,
                RealEstate2,
                RealEstate3,
                RealEstate4,
                RealEstate5,
                RealEstate6,
                RealEstate7
                );

            modelBuilder.Entity<Comment>().HasData(
                comment1,
                comment2,
                comment3,
                comment4,
                comment5,
                comment6,
                comment7
                );

        }
    }
}
