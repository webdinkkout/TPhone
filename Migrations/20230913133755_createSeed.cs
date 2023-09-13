using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CellPhoneS.Migrations
{
    /// <inheritdoc />
    public partial class createSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Alias", "CreatedAt", "Description", "Position", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "trang-chu", null, "trang chủ", 1, "Trang chủ", null },
                    { 2, "danh-muc-san-pham", null, "danh mục sản phẩm", 2, "Danh mục sản phẩm", null },
                    { 3, "gioi-thieu", null, "giới thiệu", 4, "Giới thiệu", null },
                    { 4, "san-pham", null, "san phẩm", 3, "Sản phẩm", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarFileName", "AvatarFilePath", "CreatedAt", "FirstName", "LastName", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[] { 1, null, null, null, "Ad", "Min", "$2a$10$1DRU3kyBUjOnbmxoUATMNe/mMWNlREnE2IE72cFEOGHw7TAI7OC4C", "ADMIN", null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
