using Microsoft.EntityFrameworkCore.Migrations;

namespace ORMDatabaseModule.Migrations
{
    public partial class newMigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyWords",
                columns: table => new
                {
                    KeyWordsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KeyWord = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWords", x => x.KeyWordsId);
                });

            migrationBuilder.CreateTable(
                name: "keyWordsLists",
                columns: table => new
                {
                    KeyWordsListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false),
                    KeyWordsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keyWordsLists", x => x.KeyWordsListId);
                    table.ForeignKey(
                        name: "FK_keyWordsLists_KeyWords_KeyWordsId",
                        column: x => x.KeyWordsId,
                        principalTable: "KeyWords",
                        principalColumn: "KeyWordsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_keyWordsLists_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_keyWordsLists_KeyWordsId",
                table: "keyWordsLists",
                column: "KeyWordsId");

            migrationBuilder.CreateIndex(
                name: "IX_keyWordsLists_PhotoId",
                table: "keyWordsLists",
                column: "PhotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "keyWordsLists");

            migrationBuilder.DropTable(
                name: "KeyWords");
        }
    }
}
