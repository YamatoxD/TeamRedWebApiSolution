using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamRedWebApi.Migrations
{
    public partial class TestCommentIdForComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 15, 2, 11, 466, DateTimeKind.Unspecified).AddTicks(4488), new TimeSpan(0, 2, 0, 0, 0)));

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(7277), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 389, DateTimeKind.Unspecified).AddTicks(9892), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 4,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5436), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 5,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5444), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 6,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RealEstates",
                keyColumn: "Id",
                keyValue: 7,
                column: "AdCreated",
                value: new DateTimeOffset(new DateTime(2020, 9, 28, 13, 7, 21, 392, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
