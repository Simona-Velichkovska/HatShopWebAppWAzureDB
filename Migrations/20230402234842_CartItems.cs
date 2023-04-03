using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HatShopWebAppWAzureDB.Migrations
{
    /// <inheritdoc />
    public partial class CartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<Guid>(
                name: "CartItemsId",
                table: "shoppingCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Hats_HatId",
                        column: x => x.HatId,
                        principalTable: "Hats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_CartItemsId",
                table: "shoppingCarts",
                column: "CartItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_HatId",
                table: "CartItems",
                column: "HatId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_CartItems_CartItemsId",
                table: "shoppingCarts");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_CartItemsId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "CartItemsId",
                table: "shoppingCarts");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId",
                table: "Hats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hats_ShoppingCartId",
                table: "Hats",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hats_shoppingCarts_ShoppingCartId",
                table: "Hats",
                column: "ShoppingCartId",
                principalTable: "shoppingCarts",
                principalColumn: "Id");
        }
    }
}
