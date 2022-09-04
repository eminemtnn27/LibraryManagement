using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilgiKutuphanesiWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    BookTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.BookTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    LibraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.LibraryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LendId = table.Column<int>(type: "int", nullable: false),
                    BookTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_BookType_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookType",
                        principalColumn: "BookTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "LibraryId");
                });

            migrationBuilder.CreateTable(
                name: "Dvds",
                columns: table => new
                {
                    DvdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DvdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dvds", x => x.DvdId);
                    table.ForeignKey(
                        name: "FK_Dvds_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "LibraryId");
                });

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    MagazineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MagazineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.MagazineId);
                    table.ForeignKey(
                        name: "FK_Magazines_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "LibraryId");
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BookUser_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookType",
                columns: new[] { "BookTypeId", "BookTypeName" },
                values: new object[,]
                {
                    { 1, "Lesson Book" },
                    { 2, "Novel" }
                });

            migrationBuilder.InsertData(
                table: "Dvds",
                columns: new[] { "DvdId", "DvdName", "LibraryId" },
                values: new object[] { 1, "Bilgi Felsefesi", null });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "LibraryId", "LibraryName" },
                values: new object[] { 1, "Bilgi Kütüphanesi" });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "LibraryId", "MagazineName" },
                values: new object[,]
                {
                    { 1, null, "John" },
                    { 2, null, "Mukesh" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Job", "LendId", "UserName" },
                values: new object[,]
                {
                    { 4, "Student", 0, "Seda" },
                    { 6, "Consultant", 0, "Pınar" },
                    { 8, "Lecturer", 0, "Haluk" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookId", "BookName", "BookTypeId", "LendId", "LendTime", "LibraryId", "UserId", "time" },
                values: new object[,]
                {
                    { 1, "Fizik", 1, 4, new DateTime(2022, 9, 4, 19, 25, 39, 744, DateTimeKind.Local).AddTicks(128), null, 0, "2" },
                    { 2, "Tutunamayanlar", 2, 6, new DateTime(2022, 9, 4, 19, 25, 39, 744, DateTimeKind.Local).AddTicks(141), null, 0, "2" },
                    { 3, "Suç ve Ceza", 2, 4, new DateTime(2022, 9, 4, 19, 25, 39, 744, DateTimeKind.Local).AddTicks(139), null, 0, "3" },
                    { 4, "Matematik", 1, 8, new DateTime(2022, 9, 4, 19, 25, 39, 744, DateTimeKind.Local).AddTicks(142), null, 0, "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookTypeId",
                table: "Book",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LibraryId",
                table: "Book",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UserId",
                table: "BookUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dvds_LibraryId",
                table: "Dvds",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Magazines_LibraryId",
                table: "Magazines",
                column: "LibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "Dvds");

            migrationBuilder.DropTable(
                name: "Magazines");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "Library");
        }
    }
}
