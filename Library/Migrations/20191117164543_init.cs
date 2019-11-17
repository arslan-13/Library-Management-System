using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorTbl",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomersTbl",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookTbl",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    AuthorID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookTbl_AuthorTbl_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "AuthorTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTbl_CustomersTbl_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CustomersTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTbl_AuthorID",
                table: "BookTbl",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BookTbl_CustomerID",
                table: "BookTbl",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTbl");

            migrationBuilder.DropTable(
                name: "AuthorTbl");

            migrationBuilder.DropTable(
                name: "CustomersTbl");
        }
    }
}
