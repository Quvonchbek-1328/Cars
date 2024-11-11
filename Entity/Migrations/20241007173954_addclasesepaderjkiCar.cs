using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class addclasesepaderjkiCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FullCars");

            migrationBuilder.CreateTable(
                name: "CarCompanyNames",
                schema: "FullCars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCompanyNames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CarCondition",
                schema: "FullCars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    condition = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCondition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                schema: "FullCars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CarYears",
                schema: "FullCars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarYears", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCompanyNames",
                schema: "FullCars");

            migrationBuilder.DropTable(
                name: "CarCondition",
                schema: "FullCars");

            migrationBuilder.DropTable(
                name: "CarModel",
                schema: "FullCars");

            migrationBuilder.DropTable(
                name: "CarYears",
                schema: "FullCars");
        }
    }
}
