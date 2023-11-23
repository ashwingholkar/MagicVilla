using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "SqFt", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Wifi, Pool, AC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The path is simply the set of properties used to traverse the object's structure, separated by dots. Here's a live example:", "", "Royal Villa", 5, 600.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Wifi, Pool, AC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The path is simply the set of properties used to traverse the object's structure, separated by dots. Here's a live example:", "", "Hilton Conclave Villa", 10, 600.0, 1500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Wifi, Pool, AC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The path is simply the set of properties used to traverse the object's structure, separated by dots. Here's a live example:", "", "Taj Villa", 4, 600.0, 9000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
