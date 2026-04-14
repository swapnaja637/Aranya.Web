using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aranya.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTblVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "Tbl_Villas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsActive", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3636), "Y", new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsActive", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3657), "Y", new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3658) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "IsActive", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3662), "Y", new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3663) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "IsActive", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3667), "Y", new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3668) });

            migrationBuilder.UpdateData(
                table: "Tbl_Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "IsActive", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3672), "Y", new DateTime(2026, 4, 14, 20, 41, 35, 813, DateTimeKind.Local).AddTicks(3673) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tbl_Villas");

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
        }
    }
}
