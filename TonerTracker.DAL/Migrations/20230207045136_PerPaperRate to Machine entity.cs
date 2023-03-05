using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerTracker.DAL.Migrations
{
    public partial class PerPaperRatetoMachineentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerPaperRate",
                table: "BillGenerates");

            migrationBuilder.AddColumn<decimal>(
                name: "PerPaperRate",
                table: "Machines",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerPaperRate",
                table: "Machines");

            migrationBuilder.AddColumn<decimal>(
                name: "PerPaperRate",
                table: "BillGenerates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
