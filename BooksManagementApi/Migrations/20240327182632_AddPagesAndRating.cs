using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPagesAndRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Books",
                newName: "PublishYear");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Books",
                newName: "Cover");

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublishYear",
                table: "Books",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Cover",
                table: "Books",
                newName: "Image");
        }
    }
}
