using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Cargo.DataAccessLayer.Migrations
{
    public partial class docker3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargoCompanies",
                columns: table => new
                {
                    CargoCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargoCompanies", x => x.CargoCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "cargoCostumers",
                columns: table => new
                {
                    CargoCustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disctrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargoCostumers", x => x.CargoCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "cargoOperations",
                columns: table => new
                {
                    CargoOperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargoOperations", x => x.CargoOperationId);
                });

            migrationBuilder.CreateTable(
                name: "cargoDetails",
                columns: table => new
                {
                    CargoDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    CargoCompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargoDetails", x => x.CargoDetailId);
                    table.ForeignKey(
                        name: "FK_cargoDetails_cargoCompanies_CargoCompanyID",
                        column: x => x.CargoCompanyID,
                        principalTable: "cargoCompanies",
                        principalColumn: "CargoCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cargoDetails_CargoCompanyID",
                table: "cargoDetails",
                column: "CargoCompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargoCostumers");

            migrationBuilder.DropTable(
                name: "cargoDetails");

            migrationBuilder.DropTable(
                name: "cargoOperations");

            migrationBuilder.DropTable(
                name: "cargoCompanies");
        }
    }
}
