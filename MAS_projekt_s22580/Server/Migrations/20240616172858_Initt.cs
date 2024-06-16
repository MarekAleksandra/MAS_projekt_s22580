using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAS_projekt_s22580.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuitarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfStrings = table.Column<int>(type: "int", nullable: false),
                    FretboardMaterial = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BodyMaterial = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfFrets = table.Column<int>(type: "int", nullable: true),
                    BridgeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupsType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: true),
                    VipMembershipLevel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SpecialistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesTarget = table.Column<int>(type: "int", nullable: false),
                    KnowledgeLevel = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seller_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialist_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Seller_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuitarExemplars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdGuitarType = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarExemplars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuitarExemplars_GuitarTypes_IdGuitarType",
                        column: x => x.IdGuitarType,
                        principalTable: "GuitarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuitarExemplars_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GuitarTypes",
                columns: new[] { "Id", "BodyMaterial", "BodyType", "Brand", "Discriminator", "FretboardMaterial", "Model", "NumberOfStrings", "Price" },
                values: new object[,]
                {
                    { 1, "Spruce", "Dreadnought", "Yamaha", "AcousticGuitar", "Rosewood", "F310", 6, 150.0 },
                    { 2, "Cedar", "Grand Auditorium", "Taylor", "AcousticGuitar", "Ebony", "214ce", 6, 1000.0 }
                });

            migrationBuilder.InsertData(
                table: "GuitarTypes",
                columns: new[] { "Id", "BodyMaterial", "Brand", "BridgeType", "Discriminator", "FretboardMaterial", "Model", "NumberOfFrets", "NumberOfStrings", "Price" },
                values: new object[,]
                {
                    { 3, "Alder", "Fender", "Fixed", "BassGuitar", "Maple", "Jazz Bass", 20, 4, 1200.0 },
                    { 4, "Mahogany", "Ibanez", "Fixed", "BassGuitar", "Rosewood", "SR505", 24, 5, 900.0 }
                });

            migrationBuilder.InsertData(
                table: "GuitarTypes",
                columns: new[] { "Id", "BodyMaterial", "Brand", "Discriminator", "FretboardMaterial", "Model", "NumberOfStrings", "PickupsType", "Price" },
                values: new object[,]
                {
                    { 5, "Alder", "Fender", "ElectricGuitar", "Maple", "Stratocaster", 6, "Single Coil", 1500.0 },
                    { 6, "Mahogany", "Gibson", "ElectricGuitar", "Rosewood", "Les Paul", 6, "Humbucker", 2500.0 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthdate", "ClientId", "EmployeeId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "John", "Doe" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Jane", "Smith" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Michael", "Collins" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Monica", "Williams" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Discriminator", "Email", "PersonId", "VipMembershipLevel" },
                values: new object[,]
                {
                    { 1, "ClientVip", "john.doe@email.com", 1, 3 },
                    { 2, "ClientVip", "michael.collins@email.com", 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Discriminator", "Email", "LoyaltyPoints", "PersonId" },
                values: new object[,]
                {
                    { 3, "ClientStandard", "jane.smith@example.com", 150, 2 },
                    { 4, "ClientStandard", "monica.williams@example.com", 125, 4 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmploymentDate", "PersonId", "Salary", "SellerId", "SpecialistId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 6, 19, 28, 58, 521, DateTimeKind.Local).AddTicks(2138), 1, 4500.0, 0, 0 },
                    { 2, new DateTime(2023, 2, 16, 19, 28, 58, 521, DateTimeKind.Local).AddTicks(2196), 2, 5000.0, 0, 0 },
                    { 3, new DateTime(2023, 2, 2, 19, 28, 58, 521, DateTimeKind.Local).AddTicks(2202), 3, 5500.0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumber",
                columns: new[] { "Id", "ClientId", "Number" },
                values: new object[,]
                {
                    { 1, 1, "123-456-789" },
                    { 2, 1, "098-765-432" },
                    { 3, 2, "111-111-111" },
                    { 4, 3, "222-222-222" },
                    { 5, 4, "987-654-321" },
                    { 6, 4, "555-555-555" }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "EmployeeId", "KnowledgeLevel", "SalesTarget" },
                values: new object[,]
                {
                    { 1, 1, 3, 100 },
                    { 2, 3, 9, 200 }
                });

            migrationBuilder.InsertData(
                table: "Specialist",
                columns: new[] { "Id", "EmployeeId", "Specialization", "YearsOfExperience" },
                values: new object[,]
                {
                    { 3, 1, "Electric guitars", 6 },
                    { 4, 2, "Acoustic guitars", 6 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientID", "EmployeeID", "OrderNumber", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, "A1234", "Submitted" },
                    { 2, 2, 2, "B9876", "Confirmed" },
                    { 3, 3, 1, "C1928", "Completed" },
                    { 4, 2, 2, "D5678", "Received" },
                    { 5, 4, 1, "E9876", "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "GuitarExemplars",
                columns: new[] { "Id", "IdGuitarType", "IdOrder", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 1, 1, "SN1234" },
                    { 2, 2, 2, "SN6789" },
                    { 3, 3, 3, "SN9238" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PersonId",
                table: "Clients",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonId",
                table: "Employees",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuitarExemplars_IdGuitarType",
                table: "GuitarExemplars",
                column: "IdGuitarType");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarExemplars_IdOrder",
                table: "GuitarExemplars",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarExemplars_SerialNumber",
                table: "GuitarExemplars",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientID",
                table: "Orders",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_ClientId",
                table: "PhoneNumber",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_EmployeeId",
                table: "Seller",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialist_EmployeeId",
                table: "Specialist",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuitarExemplars");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Specialist");

            migrationBuilder.DropTable(
                name: "GuitarTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
