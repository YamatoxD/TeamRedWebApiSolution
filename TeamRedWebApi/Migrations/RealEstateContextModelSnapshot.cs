﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamRedProject.DbContexts;

namespace TeamRedWebApi.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    partial class RealEstateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeamRedProject.Enitites.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("RealEstateId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("RealEstateId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is a lovely home.",
                            CreatedOn = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 98, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 2, 0, 0, 0)),
                            RealEstateId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CommentId = 1,
                            Content = "How much is this home?",
                            CreatedOn = new DateTimeOffset(new DateTime(2003, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            RealEstateId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "The premises is $100000",
                            CreatedOn = new DateTimeOffset(new DateTime(2003, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            RealEstateId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Content = "Test1",
                            CreatedOn = new DateTimeOffset(new DateTime(2005, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            RealEstateId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            Content = "Test2",
                            CreatedOn = new DateTimeOffset(new DateTime(2005, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            RealEstateId = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            Content = "Test3",
                            CreatedOn = new DateTimeOffset(new DateTime(2006, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            RealEstateId = 4,
                            UserId = 5
                        },
                        new
                        {
                            Id = 7,
                            Content = "Test4",
                            CreatedOn = new DateTimeOffset(new DateTime(2007, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            RealEstateId = 5,
                            UserId = 6
                        });
                });

            modelBuilder.Entity("TeamRedProject.Enitites.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ratings")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("TeamRedProject.Enitites.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("AdCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AverageRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CanBePurchased")
                        .HasColumnType("bit");

                    b.Property<bool>("CanBeRented")
                        .HasColumnType("bit");

                    b.Property<string>("ConstructionYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<int>("PurchasePrice")
                        .HasColumnType("int");

                    b.Property<string>("Ratings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentingPrice")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RealEstates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdCreated = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 83, DateTimeKind.Unspecified).AddTicks(8717), new TimeSpan(0, 2, 0, 0, 0)),
                            Address = "Ostindiegatan 14B",
                            CanBePurchased = true,
                            CanBeRented = true,
                            ConstructionYear = "1935",
                            Contact = "0703357725",
                            Description = "A lovely home for a lovely family",
                            PurchasePrice = 100000,
                            RentingPrice = 1000,
                            Title = "My lovely home",
                            Type = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AdCreated = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 98, DateTimeKind.Unspecified).AddTicks(4814), new TimeSpan(0, 2, 0, 0, 0)),
                            Address = "aspelundgatan 9",
                            CanBePurchased = true,
                            CanBeRented = true,
                            ConstructionYear = "1956",
                            Contact = "0709765456",
                            Description = "A lovely home for a lovely family",
                            PurchasePrice = 100000,
                            RentingPrice = 1000,
                            Title = "My cool home",
                            Type = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            AdCreated = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 98, DateTimeKind.Unspecified).AddTicks(5083), new TimeSpan(0, 2, 0, 0, 0)),
                            Address = "Falsbogatan 18",
                            CanBePurchased = true,
                            CanBeRented = true,
                            ConstructionYear = "1999",
                            Contact = "0709987656",
                            Description = "A lovely home for a lovely family",
                            PurchasePrice = 100000,
                            RentingPrice = 1000,
                            Title = "My nice home",
                            Type = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            AdCreated = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 98, DateTimeKind.Unspecified).AddTicks(5105), new TimeSpan(0, 2, 0, 0, 0)),
                            Address = "Höglundsgatan 15",
                            CanBePurchased = true,
                            CanBeRented = true,
                            ConstructionYear = "1934",
                            Contact = "0705647356",
                            Description = "A lovely home for a lovely family",
                            PurchasePrice = 100000,
                            RentingPrice = 1000,
                            Title = "My nice home",
                            Type = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            AdCreated = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 98, DateTimeKind.Unspecified).AddTicks(5117), new TimeSpan(0, 2, 0, 0, 0)),
                            Address = "Mariaplan 5",
                            CanBePurchased = true,
                            CanBeRented = true,
                            ConstructionYear = "1987",
                            Contact = "0705647356",
                            Description = "A lovely home for a lovely family",
                            PurchasePrice = 100000,
                            RentingPrice = 1000,
                            Title = "My nice bungalow",
                            Type = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            AdCreated = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 98, DateTimeKind.Unspecified).AddTicks(5130), new TimeSpan(0, 2, 0, 0, 0)),
                            Address = "Svanebäcksgatan 5",
                            CanBePurchased = true,
                            CanBeRented = true,
                            ConstructionYear = "1876",
                            Contact = "0705647356",
                            Description = "A lovely home for a lovely family",
                            PurchasePrice = 100000,
                            RentingPrice = 1000,
                            Title = "My nice bungalow",
                            Type = 1,
                            UserId = 5
                        },
                        new
                        {
                            Id = 7,
                            AdCreated = new DateTimeOffset(new DateTime(2020, 9, 30, 13, 35, 24, 98, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 2, 0, 0, 0)),
                            Address = "Fastmansvägen 89",
                            CanBePurchased = true,
                            CanBeRented = true,
                            ConstructionYear = "1657",
                            Contact = "0705647356",
                            Description = "A lovely home for a lovely family",
                            PurchasePrice = 100000,
                            RentingPrice = 1000,
                            Title = "My nice bungalow",
                            Type = 2,
                            UserId = 6
                        });
                });

            modelBuilder.Entity("TeamRedProject.Enitites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("AverageRating")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Jesperceriksson@outlook.com",
                            Password = "uYEBjhai938/¤(#&",
                            UserName = "Yamato"
                        },
                        new
                        {
                            Id = 2,
                            Email = "JohanKarlsson@outlook.com",
                            Password = "sfsdifhdsofdsh/¤(#&",
                            UserName = "Majken"
                        },
                        new
                        {
                            Id = 3,
                            Email = "FelixAlexandersson@outlook.com",
                            Password = "dsadasdasfg/¤(#&",
                            UserName = "Falex"
                        },
                        new
                        {
                            Id = 4,
                            Email = "ErikOlofsson@gmail.com",
                            Password = "sfisdfiub(T(/¤(#&",
                            UserName = "Eriko"
                        },
                        new
                        {
                            Id = 5,
                            Email = "NicklasAndreasson@protonmail.com",
                            Password = "dasdnsafba//¤(#&",
                            UserName = "Nickare"
                        },
                        new
                        {
                            Id = 6,
                            Email = "YngveOpendal@outlook.com",
                            Password = "daskdjbasdkasb/¤(#&",
                            UserName = "Yngvisen"
                        },
                        new
                        {
                            Id = 7,
                            Email = "AndreasSvensson@swipnet.se",
                            Password = "dsfsjfdsf8/¤(#&",
                            UserName = "mafakka"
                        });
                });

            modelBuilder.Entity("TeamRedProject.Enitites.Comment", b =>
                {
                    b.HasOne("TeamRedProject.Enitites.Comment", "Commented")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("TeamRedProject.Enitites.RealEstate", "RealEstate")
                        .WithMany("Comments")
                        .HasForeignKey("RealEstateId");

                    b.HasOne("TeamRedProject.Enitites.User", "Creator")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TeamRedProject.Enitites.Rating", b =>
                {
                    b.HasOne("TeamRedProject.Enitites.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TeamRedProject.Enitites.RealEstate", b =>
                {
                    b.HasOne("TeamRedProject.Enitites.User", "Creator")
                        .WithMany("RealEstates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
