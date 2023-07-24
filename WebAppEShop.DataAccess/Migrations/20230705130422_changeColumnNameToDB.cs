using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppEShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOder",
                table: "CategoriesTableName",
                newName: "DisplayOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "CategoriesTableName",
                newName: "DisplayOder");
        }
    }
}
