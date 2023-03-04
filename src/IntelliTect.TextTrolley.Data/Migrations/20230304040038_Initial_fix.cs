using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelliTect.TextTrolley.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Requester_RequesterId",
                table: "ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_RequesterId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "RequesterId",
                table: "ShoppingList");

            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "ShoppingListItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RequesterNumber",
                table: "Requester",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RequesterName",
                table: "Requester",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ActiveShoppingListKey",
                table: "Requester",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requester_ActiveShoppingListKey",
                table: "Requester",
                column: "ActiveShoppingListKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requester_ShoppingList_ActiveShoppingListKey",
                table: "Requester",
                column: "ActiveShoppingListKey",
                principalTable: "ShoppingList",
                principalColumn: "ShoppingListId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requester_ShoppingList_ActiveShoppingListKey",
                table: "Requester");

            migrationBuilder.DropIndex(
                name: "IX_Requester_ActiveShoppingListKey",
                table: "Requester");

            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "ShoppingListItem");

            migrationBuilder.DropColumn(
                name: "ActiveShoppingListKey",
                table: "Requester");

            migrationBuilder.AddColumn<int>(
                name: "RequesterId",
                table: "ShoppingList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "RequesterNumber",
                table: "Requester",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "RequesterName",
                table: "Requester",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_RequesterId",
                table: "ShoppingList",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Requester_RequesterId",
                table: "ShoppingList",
                column: "RequesterId",
                principalTable: "Requester",
                principalColumn: "RequesterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
