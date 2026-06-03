using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mobiles" },
                    { 2, "Tablets" },
                    { 3, "Laptops" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Rate" },
                values: new object[,]
                {
                    { 1, 1, "Latest iPhone model", "iPhone 13", 999.99m, 4.5 },
                    { 2, 1, "Flagship Samsung phone", "Samsung Galaxy S21", 899.99m, 4.2999999999999998 },
                    { 3, 2, "Powerful tablet from Apple", "iPad Pro", 799.99m, 4.5999999999999996 },
                    { 4, 2, "Versatile tablet from Microsoft", "Microsoft Surface Pro", 899.99m, 4.4000000000000004 },
                    { 5, 3, "High-performance laptop from Apple", "MacBook Pro", 1299.99m, 4.7000000000000002 },
                    { 6, 3, "Compact and powerful laptop from Dell", "Dell XPS 13", 999.99m, 4.5 }
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
