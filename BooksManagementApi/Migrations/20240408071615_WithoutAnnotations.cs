using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class WithoutAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImaggaTags_Books_BookId",
                table: "ImaggaTags");

            migrationBuilder.DropIndex(
                name: "IX_ImaggaTags_BookId",
                table: "ImaggaTags");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ImaggaTags");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "BookImaggaTag",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookImaggaTag", x => new { x.BooksId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BookImaggaTag_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookImaggaTag_ImaggaTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ImaggaTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookImaggaTag_TagsId",
                table: "BookImaggaTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookImaggaTag");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "ImaggaTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.CreateIndex(
                name: "IX_ImaggaTags_BookId",
                table: "ImaggaTags",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImaggaTags_Books_BookId",
                table: "ImaggaTags",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
