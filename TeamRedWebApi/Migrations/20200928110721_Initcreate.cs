using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamRedWebApi.Migrations
{
    public partial class Initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    AverageRating = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratings = table.Column<int>(nullable: false),
                    RaterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_RaterId",
                        column: x => x.RaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    RentingPrice = table.Column<int>(nullable: false),
                    PurchasePrice = table.Column<int>(nullable: false),
                    CanBeRented = table.Column<bool>(nullable: false),
                    CanBePurchased = table.Column<bool>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    ConstructionYear = table.Column<string>(nullable: false),
                    AdCreated = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AverageRating = table.Column<string>(nullable: true),
                    Ratings = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    RealEstateId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AverageRating", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, null, "Jesperceriksson@outlook.com", "uYEBjhai938/¤(#&", "Yamato" },
                    { 2, null, "JohanKarlsson@outlook.com", "sfsdifhdsofdsh/¤(#&", "Majken" },
                    { 3, null, "FelixAlexandersson@outlook.com", "dsadasdasfg/¤(#&", "Falex" },
                    { 4, null, "ErikOlofsson@gmail.com", "sfisdfiub(T(/¤(#&", "Eriko" },
                    { 5, null, "NicklasAndreasson@protonmail.com", "dasdnsafba//¤(#&", "Nickare" },
                    { 6, null, "YngveOpendal@outlook.com", "daskdjbasdkasb/¤(#&", "Yngvisen" },
                    { 7, null, "AndreasSvensson@swipnet.se", "dsfsjfdsf8/¤(#&", "mafakka" }
                });

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Id", "AdCreated", "Address", "AverageRating", "CanBePurchased", "CanBeRented", "ConstructionYear", "Contact", "Description", "PurchasePrice", "Ratings", "RentingPrice", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 389, DateTimeKind.Unspecified).AddTicks(9892), new TimeSpan(0, 2, 0, 0, 0)), "Ostindiegatan 14B", null, true, true, "1935", "0703357725", "A lovely home for a lovely family", 100000, null, 1000, "My lovely home", 2, 1 },
                    { 2, new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, 2, 0, 0, 0)), "aspelundgatan 9", null, true, true, "1956", "0709765456", "A lovely home for a lovely family", 100000, null, 1000, "My cool home", 2, 2 },
                    { 3, new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, 2, 0, 0, 0)), "Falsbogatan 18", null, true, true, "1999", "0709987656", "A lovely home for a lovely family", 100000, null, 1000, "My nice home", 1, 3 },
                    { 4, new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5436), new TimeSpan(0, 2, 0, 0, 0)), "Höglundsgatan 15", null, true, true, "1934", "0705647356", "A lovely home for a lovely family", 100000, null, 1000, "My nice home", 2, 3 },
                    { 5, new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5444), new TimeSpan(0, 2, 0, 0, 0)), "Mariaplan 5", null, true, true, "1987", "0705647356", "A lovely home for a lovely family", 100000, null, 1000, "My nice bungalow", 2, 4 },
                    { 6, new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 2, 0, 0, 0)), "Svanebäcksgatan 5", null, true, true, "1876", "0705647356", "A lovely home for a lovely family", 100000, null, 1000, "My nice bungalow", 1, 5 },
                    { 7, new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 2, 0, 0, 0)), "Fastmansvägen 89", null, true, true, "1657", "0705647356", "A lovely home for a lovely family", 100000, null, 1000, "My nice bungalow", 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "RealEstateId", "UserId" },
                values: new object[,]
                {
                    { 1, "This is a lovely home.", new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(7277), new TimeSpan(0, 2, 0, 0, 0)), 1, 1 },
                    { 2, "How much is this home?", new DateTimeOffset(new DateTime(2003, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 2, 2 },
                    { 3, "The premises is $100000", new DateTimeOffset(new DateTime(2003, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 2, 3 },
                    { 4, "Test1", new DateTimeOffset(new DateTime(2005, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 3, 3 },
                    { 5, "Test2", new DateTimeOffset(new DateTime(2005, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 3, 4 },
                    { 6, "Test3", new DateTimeOffset(new DateTime(2006, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 4, 5 },
                    { 7, "Test4", new DateTimeOffset(new DateTime(2007, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 5, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RealEstateId",
                table: "Comments",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RaterId",
                table: "Ratings",
                column: "RaterId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_UserId",
                table: "RealEstates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
