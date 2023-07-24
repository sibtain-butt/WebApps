using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppEShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyOfCategoryIdInProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductTableName",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "CategoriesTableName",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1016, 1, "Action" },
                    { 1017, 2, "Sci-fi" },
                    { 1018, 3, "History" },
                    { 1019, 4, "Horror" },
                    { 1020, 5, "Mystery" },
                    { 1021, 6, "Comedy" }
                });

            migrationBuilder.UpdateData(
                table: "ProductTableName",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1016);

            migrationBuilder.UpdateData(
                table: "ProductTableName",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1017);

            migrationBuilder.UpdateData(
                table: "ProductTableName",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1018);

            migrationBuilder.UpdateData(
                table: "ProductTableName",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 1019);

            migrationBuilder.UpdateData(
                table: "ProductTableName",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 1020);

            migrationBuilder.UpdateData(
                table: "ProductTableName",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 1021);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTableName_CategoryId",
                table: "ProductTableName",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTableName_CategoriesTableName_CategoryId",
                table: "ProductTableName",
                column: "CategoryId",
                principalTable: "CategoriesTableName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTableName_CategoriesTableName_CategoryId",
                table: "ProductTableName");

            migrationBuilder.DropIndex(
                name: "IX_ProductTableName_CategoryId",
                table: "ProductTableName");

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "CategoriesTableName",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductTableName");

            migrationBuilder.InsertData(
                table: "CategoriesTableName",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Sci-fi" },
                    { 3, 3, "History" }
                });
        }
    }
}
