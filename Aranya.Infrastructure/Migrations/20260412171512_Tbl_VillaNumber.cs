using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aranya.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tbl_VillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tbl_Villas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Tbl_Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tbl_Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_VillaNumber",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_VillaNumber", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_Tbl_VillaNumber_Tbl_Villas_VillaID",
                        column: x => x.VillaID,
                        principalTable: "Tbl_Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tbl_VillaNumber",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaID" },
                values: new object[,]
                {
                    { 103, null, 1 },
                    { 104, null, 2 },
                    { 105, null, 2 },
                    { 108, null, 1 },
                    { 203, null, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3588), new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3599) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3604), new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3605) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3608), new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3612), new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3613) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3616), new DateTime(2026, 4, 12, 22, 45, 11, 774, DateTimeKind.Local).AddTicks(3617) });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_VillaNumber_VillaID",
                table: "Tbl_VillaNumber",
                column: "VillaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_VillaNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tbl_Villas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Tbl_Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tbl_Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9057), new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9079), new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9084) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9088), new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9089) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9093), new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9095) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9099), new DateTime(2026, 4, 8, 23, 43, 19, 223, DateTimeKind.Local).AddTicks(9101) });
        }
    }
}
