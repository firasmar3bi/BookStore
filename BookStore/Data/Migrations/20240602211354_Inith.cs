using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inith : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookName",
                table: "BookCategory");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "BookCategory");

            migrationBuilder.AddColumn<int>(
                name: "categorysId",
                table: "BookCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_categorysId",
                table: "BookCategory",
                column: "categorysId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Categorys_categorysId",
                table: "BookCategory",
                column: "categorysId",
                principalTable: "Categorys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categorys_categorysId",
                table: "BookCategory");

            migrationBuilder.DropIndex(
                name: "IX_BookCategory_categorysId",
                table: "BookCategory");

            migrationBuilder.DropColumn(
                name: "categorysId",
                table: "BookCategory");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "BookCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "BookCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
