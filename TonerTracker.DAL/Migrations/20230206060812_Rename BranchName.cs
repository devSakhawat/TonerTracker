using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerTracker.DAL.Migrations
{
    public partial class RenameBranchName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrachName",
                table: "Branches",
                newName: "BranchName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "Branches",
                newName: "BrachName");
        }
    }
}
