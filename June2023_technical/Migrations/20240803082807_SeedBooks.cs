using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace June2023_technical.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "Price", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", "Fiction", 10.99m, 1960, "To Kill a Mockingbird" },
                    { 2, "George Orwell", "Dystopian", 9.99m, 1949, "1984" },
                    { 3, "Jane Austen", "Romance", 12.99m, 1813, "Pride and Prejudice" },
                    { 4, "F. Scott Fitzgerald", "Fiction", 14.99m, 1925, "The Great Gatsby" },
                    { 5, "Herman Melville", "Adventure", 15.99m, 1851, "Moby Dick" },
                    { 6, "Leo Tolstoy", "Historical Fiction", 20.99m, 1869, "War and Peace" },
                    { 7, "J.D. Salinger", "Fiction", 10.99m, 1951, "The Catcher in the Rye" },
                    { 8, "J.R.R. Tolkien", "Fantasy", 13.99m, 1937, "The Hobbit" },
                    { 9, "Fyodor Dostoevsky", "Philosophical Fiction", 16.99m, 1866, "Crime and Punishment" },
                    { 10, "Fyodor Dostoevsky", "Philosophical Fiction", 18.99m, 1880, "The Brothers Karamazov" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
