using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerTracker.DAL.Migrations
{
    public partial class TonerSerialAddtoTonerDeliveryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
