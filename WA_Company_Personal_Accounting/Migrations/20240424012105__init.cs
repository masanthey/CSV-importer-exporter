using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WA_Company_Personal_Accounting.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    JuridicalArdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasportSeries = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    PasportNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "ActualAddress", "INN", "JuridicalArdress", "Name" },
                values: new object[] { new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"), "Попов Сергей Дмитриевич город Рязань, Рязанская область. Советский район, улица Горького 34, квартира 16 Россия 390027.", "0000000000", "Попов Сергей Дмитриевич город Рязань, Рязанская область. Советский район, улица Горького 34, квартира 16 Россия 390027.", "OOO Default" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
