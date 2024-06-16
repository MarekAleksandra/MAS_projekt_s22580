using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_projekt_s22580.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmploymentDate",
                value: new DateTime(2024, 6, 6, 19, 39, 47, 826, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmploymentDate",
                value: new DateTime(2023, 2, 16, 19, 39, 47, 826, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmploymentDate",
                value: new DateTime(2023, 2, 2, 19, 39, 47, 826, DateTimeKind.Local).AddTicks(4629));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmploymentDate",
                value: new DateTime(2024, 6, 6, 19, 32, 14, 240, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmploymentDate",
                value: new DateTime(2023, 2, 16, 19, 32, 14, 240, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmploymentDate",
                value: new DateTime(2023, 2, 2, 19, 32, 14, 240, DateTimeKind.Local).AddTicks(8430));
        }
    }
}
