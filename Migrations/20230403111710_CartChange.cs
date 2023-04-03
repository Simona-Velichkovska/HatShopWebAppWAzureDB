using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HatShopWebAppWAzureDB.Migrations
{
    /// <inheritdoc />
    public partial class CartChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_CartItemsId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "CartItemsId",
                table: "shoppingCarts");

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItems");

            migrationBuilder.AddColumn<Guid>(
                name: "CartItemsId",
                table: "shoppingCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_CartItemsId",
                table: "shoppingCarts",
                column: "CartItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_CartItems_CartItemsId",
                table: "shoppingCarts",
                column: "CartItemsId",
                principalTable: "CartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
