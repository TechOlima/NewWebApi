using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addsupplies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    SupplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReceived = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.SupplyID);
                });

            migrationBuilder.CreateTable(
                name: "SupplyProduct",
                columns: table => new
                {
                    Supply_ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SupplyID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyProduct", x => x.Supply_ProductID);
                    table.ForeignKey(
                        name: "FK_SupplyProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_SupplyProduct_Supply_SupplyID",
                        column: x => x.SupplyID,
                        principalTable: "Supply",
                        principalColumn: "SupplyID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplyProduct_ProductID",
                table: "SupplyProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyProduct_SupplyID",
                table: "SupplyProduct",
                column: "SupplyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplyProduct");

            migrationBuilder.DropTable(
                name: "Supply");
        }
    }
}
