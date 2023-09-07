using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CellPhoneS.Migrations
{
    /// <inheritdoc />
    public partial class updateTabble3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuItems_MenuItemId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuItemId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MenuItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "MenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "MenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuItemId",
                table: "MenuItems",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuItems_MenuItemId",
                table: "MenuItems",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id");
        }
    }
}
