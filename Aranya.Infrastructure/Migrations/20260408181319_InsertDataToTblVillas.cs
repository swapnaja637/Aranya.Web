using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aranya.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertDataToTblVillas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tbl_Villas",
                columns: new[] { "Id", "Area", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "5000 sq ft", new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9057), "This is the description of the Royal Villa", "", "Royal Villa For Family", 4, 200.0, new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9072) },
                    { 2, "5000 sq ft", new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9079), "A special room for a special memories.", "", "Honeymoon sweet For Couple", 4, 200.0, new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9084) },
                    { 3, "5000 sq ft", new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9088), "This is the delux ville with AC.", "", "Delux villa for couple", 4, 200.0, new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9089) },
                    { 4, "5000 sq ft", new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9093), "This is the description of the Sea facing Villa", "", "Sea facing villa", 4, 200.0, new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9095) },
                    { 5, "5000 sq ft", new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9099), "This is the description of the Tree Villa with AC and 2 rooms.", "", "Tree Villa", 4, 200.0, new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9101) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
