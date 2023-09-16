using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CellPhoneS.Migrations
{
    /// <inheritdoc />
    public partial class addSeeder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "SeoName", "Status", "ThumbnailFileName", "ThumbnailFilePath", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Điện thoại", "dien-thoai", true, null, null, null },
                    { 2, null, "Laptop", "laptop", true, null, null, null },
                    { 3, null, "Phụ kiện", "phu-kien", true, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
