using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_projekt_s22580.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inittt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Seller_EmployeeID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Seller_EmployeeID",
                table: "Orders",
                column: "EmployeeID",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Seller_EmployeeID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmploymentDate",
                value: new DateTime(2024, 6, 6, 19, 28, 58, 521, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmploymentDate",
                value: new DateTime(2023, 2, 16, 19, 28, 58, 521, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmploymentDate",
                value: new DateTime(2023, 2, 2, 19, 28, 58, 521, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Seller_EmployeeID",
                table: "Orders",
                column: "EmployeeID",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
