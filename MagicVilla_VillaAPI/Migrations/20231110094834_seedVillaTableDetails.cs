using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaTableDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 10, 15, 18, 34, 556, DateTimeKind.Local).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 18, 34, 556, DateTimeKind.Local).AddTicks(3751), "This is the second villa" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 18, 34, 556, DateTimeKind.Local).AddTicks(3753), "This is the third villa" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 18, 34, 556, DateTimeKind.Local).AddTicks(3754), "This is the fourth villa" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 18, 34, 556, DateTimeKind.Local).AddTicks(3756), "This is the fifth villa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 10, 15, 16, 12, 695, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 16, 12, 695, DateTimeKind.Local).AddTicks(4946), "This is the first villa" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 16, 12, 695, DateTimeKind.Local).AddTicks(4948), "This is the first villa" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 16, 12, 695, DateTimeKind.Local).AddTicks(4949), "This is the first villa" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Details" },
                values: new object[] { new DateTime(2023, 11, 10, 15, 16, 12, 695, DateTimeKind.Local).AddTicks(4951), "This is the first villa" });
        }
    }
}
