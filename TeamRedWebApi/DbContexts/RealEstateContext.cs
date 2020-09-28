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
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User user = new User()
            {
                Id = 1,
                //Name = "Jesper Eriksson",
                UserName = "Yamato",
                Email = "Jesperceriksson@outlook.com",
                Password = "uYEBjhai938/¤(#&",
                Ratings = null,
                RealEstates = null,
                AverageRating = null
            };
            User user2 = new User()
            {
                Id = 2,
                //Name = "Johan Karlsson",
                UserName = "Majken",
                Email = "JohanKarlsson@outlook.com",
                Password = "sfsdifhdsofdsh/¤(#&",
                Ratings = null,
                RealEstates = null,
                AverageRating = null
            };
            User user3 = new User()
            {
                Id = 3,
                //Name = "Felix Alexandersson",
                UserName = "Falex",
                Email = "FelixAlexandersson@outlook.com",
                Password = "dsadasdasfg/¤(#&",
                Ratings = null,
                RealEstates = null,
                AverageRating = null
            };
            User user4 = new User()
            {
                Id = 4,
                //Name = "Erik Olofsson",
                UserName = "Eriko",
                Email = "ErikOlofsson@gmail.com",
                Password = "sfisdfiub(T(/¤(#&",
                Ratings = null,
                RealEstates = null,
                AverageRating = null
            };
            User user5 = new User()
            {
                Id = 5,
                //Name = "Nicklas Andreasson",
                UserName = "Nickare",
                Email = "NicklasAndreasson@protonmail.com",
                Password = "dasdnsafba//¤(#&",
                Ratings = null,
                RealEstates = null,
                AverageRating = null
            };
            User user6 = new User()
            {
                Id = 6,
                //Name = "Yngve Opendal",
                UserName = "Yngvisen",
                Email = "YngveOpendal@outlook.com",
                Password = "daskdjbasdkasb/¤(#&",
                Ratings = null,
                RealEstates = null,
                AverageRating = null
            };
            User user7 = new User()
            {
                Id = 7,
               // Name = "Andreas Svensson",
                UserName = "mafakka",
                Email = "AndreasSvensson@swipnet.se",
                Password = "dsfsjfdsf8/¤(#&",
                Ratings = null,
                RealEstates = null,
                AverageRating = null
            };

            RealEstate RealEstate1 = new RealEstate()
            {
                Id = 1,
                Title = "My lovely home",
                Address = "Ostindiegatan 14B",
                AdCreated = DateTime.Now,
                CanBePurchased = true,
                CanBeRented = true,
                RentingPrice = 1000,
                PurchasePrice = 100000,
                Contact = "0703357725",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user.Id,
                ConstructionYear = "1935"

            };
            RealEstate RealEstate2 = new RealEstate()
            {
                Id = 2,
                Title = "My cool home",
                Address = "aspelundgatan 9",
                AdCreated = DateTime.Now,
                CanBePurchased = true,
                CanBeRented = true,
                RentingPrice = 1000,
                PurchasePrice = 100000,
                Contact = "0709765456",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user2.Id,
                ConstructionYear = "1956"

            };
            RealEstate RealEstate3 = new RealEstate()
            {
                Id = 3,
                Title = "My nice home",
                Address = "Falsbogatan 18",
                AdCreated = DateTime.Now,
                CanBePurchased = true,
                CanBeRented = true,
                RentingPrice = 1000,
                PurchasePrice = 100000,
                Contact = "0709987656",
                Description = "A lovely home for a lovely family",
                Type = 1,
                UserId = user3.Id,
                ConstructionYear = "1999"

            };
            RealEstate RealEstate4 = new RealEstate()
            {
                Id = 4,
                Title = "My nice home",
                Address = "Höglundsgatan 15",
                AdCreated = DateTime.Now,
                CanBePurchased = true,
                CanBeRented = true,
                RentingPrice = 1000,
                PurchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user3.Id,
                ConstructionYear = "1934"
            };
            RealEstate RealEstate5 = new RealEstate()
            {
                Id = 5,
                Title = "My nice bungalow",
                Address = "Mariaplan 5",
                AdCreated = DateTime.Now,
                CanBePurchased = true,
                CanBeRented = true,
                RentingPrice = 1000,
                PurchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user4.Id,
                ConstructionYear = "1987"
            };
            RealEstate RealEstate6 = new RealEstate()
            {
                Id = 6,
                Title = "My nice bungalow",
                Address = "Svanebäcksgatan 5",
                AdCreated = DateTime.Now,
                CanBePurchased = true,
                CanBeRented = true,
                RentingPrice = 1000,
                PurchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 1,
                UserId = user5.Id,
                ConstructionYear = "1876"
            };

            RealEstate RealEstate7 = new RealEstate()
            {
                Id = 7,
                Title = "My nice bungalow",
                Address = "Fastmansvägen 89",
                AdCreated = DateTime.Now,
                CanBePurchased = true,
                CanBeRented = true,
                RentingPrice = 1000,
                PurchasePrice = 100000,
                Contact = "0705647356",
                Description = "A lovely home for a lovely family",
                Type = 2,
                UserId = user6.Id,
                ConstructionYear = "1657"
            };
            Comment comment1 = new Comment()
            {
                Id = 1,
                RealEstateId = RealEstate1.Id,
                UserId = user.Id,
                CreatedOn = DateTime.Now,
                Content = "This is a lovely home."
            };

            Comment comment2 = new Comment()
            {
                Id = 2,
                RealEstateId = RealEstate2.Id,
                UserId = user2.Id,
                CreatedOn = new DateTime(2003, 3, 5),
                Content = "How much is this home?"
            };
            Comment comment3 = new Comment()
            {
                Id = 3,
                RealEstateId = RealEstate2.Id,
                UserId = user3.Id,
                CreatedOn = new DateTime(2003, 3, 6),
                Content = "The premises is $100000"
            };
            Comment comment4 = new Comment()
            {
                Id = 4,
                RealEstateId = RealEstate3.Id,
                UserId = user3.Id,
                CreatedOn = new DateTime(2005, 06, 02),
                Content = "Test1"
            };
            Comment comment5 = new Comment()
            {
                Id = 5,
                RealEstateId = RealEstate3.Id,
                UserId = user4.Id,
                CreatedOn = new DateTime(2005, 06, 02),
                Content = "Test2"
            };
            Comment comment6 = new Comment()
            {
                Id = 6,
                RealEstateId = RealEstate4.Id,
                UserId = user5.Id,
                CreatedOn = new DateTime(2006, 05, 12),
                Content = "Test3"
            };
            Comment comment7 = new Comment()
            {
                Id = 7,
                RealEstateId = RealEstate5.Id,
                UserId = user6.Id,
                CreatedOn = new DateTime(2007, 10, 19),
                Content = "Test4"
            };


            modelBuilder.Entity<User>().HasData(
                user,
                user2,
                user3,
                user4,
                user5,
                user6,
                user7
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
