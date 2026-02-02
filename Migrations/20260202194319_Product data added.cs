using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVP_scope_e_shop_API.Migrations
{
    /// <inheritdoc />
    public partial class Productdataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Color", "Description", "Gender", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Love Mountains", "Red", "100% wool", "uni", "T-shirt", 250.0, 2 },
                    { 2, "Love Mountains", "Blue", "", "male", "Pants", 590.0, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
