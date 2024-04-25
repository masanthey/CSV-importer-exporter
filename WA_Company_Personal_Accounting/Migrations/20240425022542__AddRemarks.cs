using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WA_Company_Personal_Accounting.Migrations
{
    /// <inheritdoc />
    public partial class _AddRemarks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JuridicalArdress",
                table: "Companies",
                newName: "JuridicalAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JuridicalAddress",
                table: "Companies",
                newName: "JuridicalArdress");
        }
    }
}
