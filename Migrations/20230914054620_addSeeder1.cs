using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CellPhoneS.Migrations
{
    /// <inheritdoc />
    public partial class addSeeder1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "CreatedAt", "Detail", "UpdatedAt" },
                values: new object[] { 1, null, "<h1>Hello About</h1>", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
