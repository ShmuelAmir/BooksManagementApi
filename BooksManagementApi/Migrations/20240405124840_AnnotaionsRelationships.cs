using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class AnnotaionsRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Books_BookISBN",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "BookImaggaTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImaggaTag",
                table: "ImaggaTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_BookISBN",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "BookISBN",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "ImaggaTag",
                newName: "ImaggaTags");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "ImaggaTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "ImaggaTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImaggaTags",
                table: "ImaggaTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ImaggaTags_BookId",
                table: "ImaggaTags",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImaggaTags_Books_BookId",
                table: "ImaggaTags",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ImaggaTags_Books_BookId",
                table: "ImaggaTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImaggaTags",
                table: "ImaggaTags");

            migrationBuilder.DropIndex(
                name: "IX_ImaggaTags_BookId",
                table: "ImaggaTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BookId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ImaggaTags");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "ImaggaTags",
                newName: "ImaggaTag");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Comment",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "ImaggaTag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookISBN",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImaggaTag",
                table: "ImaggaTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookImaggaTag",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookImaggaTag", x => new { x.BookId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BookImaggaTag_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookImaggaTag_ImaggaTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ImaggaTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BookISBN",
                table: "Comment",
                column: "BookISBN");

            migrationBuilder.CreateIndex(
                name: "IX_BookImaggaTag_TagsId",
                table: "BookImaggaTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Books_BookISBN",
                table: "Comment",
                column: "BookISBN",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
