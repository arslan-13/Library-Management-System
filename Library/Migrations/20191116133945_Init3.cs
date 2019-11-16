using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTbl_AuthorTbl_AuthorID",
                table: "BookTbl");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BookTbl",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "BookTbl",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "BookTbl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookTbl_CustomerID",
                table: "BookTbl",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTbl_AuthorTbl_AuthorID",
                table: "BookTbl",
                column: "AuthorID",
                principalTable: "AuthorTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTbl_CustomersTbl_CustomerID",
                table: "BookTbl",
                column: "CustomerID",
                principalTable: "CustomersTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTbl_AuthorTbl_AuthorID",
                table: "BookTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTbl_CustomersTbl_CustomerID",
                table: "BookTbl");

            migrationBuilder.DropIndex(
                name: "IX_BookTbl_CustomerID",
                table: "BookTbl");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "BookTbl");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BookTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "BookTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookTbl_AuthorTbl_AuthorID",
                table: "BookTbl",
                column: "AuthorID",
                principalTable: "AuthorTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
