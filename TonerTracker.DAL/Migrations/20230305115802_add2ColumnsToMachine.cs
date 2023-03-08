using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerTracker.DAL.Migrations
{
    public partial class add2ColumnsToMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerPaperRate",
                table: "Machines",
                newName: "ColourPaperRate");

            migrationBuilder.AddColumn<decimal>(
                name: "BWPaperRate",
                table: "Machines",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BWPaperRate",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "ColourPaperRate",
                table: "Machines",
                newName: "PerPaperRate");
        }
    }
}
