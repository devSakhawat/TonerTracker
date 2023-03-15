using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerTracker.DAL.Migrations
{
    public partial class SerialNochangetoModelNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BWSerialNo",
                table: "TonerDeliveries");

            migrationBuilder.DropColumn(
                name: "BlackSerialNo",
                table: "TonerDeliveries");

            migrationBuilder.DropColumn(
                name: "CyanSerialNo",
                table: "TonerDeliveries");

            migrationBuilder.DropColumn(
                name: "MagentaSerialNo",
                table: "TonerDeliveries");

            migrationBuilder.DropColumn(
                name: "YellowSerialNo",
                table: "TonerDeliveries");

            migrationBuilder.RenameColumn(
                name: "YellowSerialNo",
                table: "Machines",
                newName: "YellowModelNo");

            migrationBuilder.RenameColumn(
                name: "MagentaSerialNo",
                table: "Machines",
                newName: "MagentaModelNo");

            migrationBuilder.RenameColumn(
                name: "CyanSerialNo",
                table: "Machines",
                newName: "CyanModelNo");

            migrationBuilder.RenameColumn(
                name: "BlackSerialNo",
                table: "Machines",
                newName: "BlackModelNo");

            migrationBuilder.RenameColumn(
                name: "BWSerialNo",
                table: "Machines",
                newName: "BWModelNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YellowModelNo",
                table: "Machines",
                newName: "YellowSerialNo");

            migrationBuilder.RenameColumn(
                name: "MagentaModelNo",
                table: "Machines",
                newName: "MagentaSerialNo");

            migrationBuilder.RenameColumn(
                name: "CyanModelNo",
                table: "Machines",
                newName: "CyanSerialNo");

            migrationBuilder.RenameColumn(
                name: "BlackModelNo",
                table: "Machines",
                newName: "BlackSerialNo");

            migrationBuilder.RenameColumn(
                name: "BWModelNo",
                table: "Machines",
                newName: "BWSerialNo");

            migrationBuilder.AddColumn<string>(
                name: "BWSerialNo",
                table: "TonerDeliveries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlackSerialNo",
                table: "TonerDeliveries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyanSerialNo",
                table: "TonerDeliveries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MagentaSerialNo",
                table: "TonerDeliveries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YellowSerialNo",
                table: "TonerDeliveries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
