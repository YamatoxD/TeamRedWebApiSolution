using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamRedWebApi.Migrations
{
    public partial class TestCommentOnComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 428, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 425, DateTimeKind.Unspecified).AddTicks(6829), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 428, DateTimeKind.Unspecified).AddTicks(1345), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 428, DateTimeKind.Unspecified).AddTicks(1456), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 4,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 428, DateTimeKind.Unspecified).AddTicks(1466), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 5,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 428, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 6,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 428, DateTimeKind.Unspecified).AddTicks(1479), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 7,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 3, 28, 428, DateTimeKind.Unspecified).AddTicks(1486), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(4488), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 463, DateTimeKind.Unspecified).AddTicks(4847), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(2234), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 4,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(2245), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 5,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 6,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 7,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
