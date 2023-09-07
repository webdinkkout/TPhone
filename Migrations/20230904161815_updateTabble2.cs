using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CellPhoneS.Migrations
{
    /// <inheritdoc />
    public partial class updateTabble2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MenuItems");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
