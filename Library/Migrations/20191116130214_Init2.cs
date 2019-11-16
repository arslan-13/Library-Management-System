using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "BookTbl",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuthorTbl",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AuthorTbl",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BookTbl_AuthorID",
                table: "BookTbl",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTbl_AuthorTbl_AuthorID",
                table: "BookTbl",
                column: "AuthorID",
                principalTable: "AuthorTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTbl_AuthorTbl_AuthorID",
                table: "BookTbl");

            migrationBuilder.DropIndex(
                name: "IX_BookTbl_AuthorID",
                table: "BookTbl");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "BookTbl");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AuthorTbl");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuthorTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
