using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTbl_CustomersTbl_CustID",
                table: "BookTbl");

            migrationBuilder.DropIndex(
                name: "IX_BookTbl_CustID",
                table: "BookTbl");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "BookTbl",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTbl_CustomerID",
                table: "BookTbl",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTbl_CustomersTbl_CustomerID",
                table: "BookTbl",
                column: "CustomerID",
                principalTable: "CustomersTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTbl_CustomersTbl_CustomerID",
                table: "BookTbl");

            migrationBuilder.DropIndex(
                name: "IX_BookTbl_CustomerID",
                table: "BookTbl");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "BookTbl");

            migrationBuilder.CreateIndex(
                name: "IX_BookTbl_CustID",
                table: "BookTbl",
                column: "CustID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTbl_CustomersTbl_CustID",
                table: "BookTbl",
                column: "CustID",
                principalTable: "CustomersTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
