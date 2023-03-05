using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonerTracker.DAL.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrachName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    MachineModelNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MachineSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ColourType = table.Column<int>(type: "int", nullable: false),
                    BWSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CyanSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MagentaSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YellowSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BlackSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Machines_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaperCounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineID = table.Column<int>(type: "int", nullable: false),
                    PreviousCount = table.Column<int>(type: "int", nullable: false),
                    CurrentCount = table.Column<int>(type: "int", nullable: false),
                    TotalPaper = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperCounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaperCounts_Machines_MachineID",
                        column: x => x.MachineID,
                        principalTable: "Machines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TonerDeliveries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineID = table.Column<int>(type: "int", nullable: false),
                    InHouseBW = table.Column<int>(type: "int", nullable: true),
                    InHouseCyan = table.Column<int>(type: "int", nullable: true),
                    InHouseMagenta = table.Column<int>(type: "int", nullable: true),
                    InHouseYellow = table.Column<int>(type: "int", nullable: true),
                    InHouseBlack = table.Column<int>(type: "int", nullable: true),
                    MachineBW = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MachineCyan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MachineMagenta = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MachineYellow = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MachineBlack = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryBW = table.Column<int>(type: "int", nullable: true),
                    DeliveryCyan = table.Column<int>(type: "int", nullable: true),
                    DeliveryMagenta = table.Column<int>(type: "int", nullable: true),
                    DeliveryYellow = table.Column<int>(type: "int", nullable: true),
                    DeliveryBlack = table.Column<int>(type: "int", nullable: true),
                    StockBW = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockCyan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockMagenta = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockYellow = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockBlack = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonerDeliveries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TonerDeliveries_Machines_MachineID",
                        column: x => x.MachineID,
                        principalTable: "Machines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillGenerates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaperCountID = table.Column<int>(type: "int", nullable: false),
                    PerPaperRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillGenerates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillGenerates_PaperCounts_PaperCountID",
                        column: x => x.PaperCountID,
                        principalTable: "PaperCounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillGenerates_PaperCountID",
                table: "BillGenerates",
                column: "PaperCountID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyID",
                table: "Branches",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_BranchID",
                table: "Machines",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_PaperCounts_MachineID",
                table: "PaperCounts",
                column: "MachineID");

            migrationBuilder.CreateIndex(
                name: "IX_TonerDeliveries_MachineID",
                table: "TonerDeliveries",
                column: "MachineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillGenerates");

            migrationBuilder.DropTable(
                name: "TonerDeliveries");

            migrationBuilder.DropTable(
                name: "PaperCounts");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
