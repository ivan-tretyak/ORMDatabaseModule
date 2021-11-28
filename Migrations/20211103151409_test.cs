using Microsoft.EntityFrameworkCore.Migrations;

namespace ORMDatabaseModule.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "MetaDatas",
                columns: table => new
                {
                    MetadataId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Orientation = table.Column<int>(type: "INTEGER", nullable: false),
                    FocusLength = table.Column<int>(type: "INTEGER", nullable: false),
                    Longitude = table.Column<float>(type: "REAL", nullable: false),
                    Latitude = table.Column<float>(type: "REAL", nullable: false),
                    Flash = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDatas", x => x.MetadataId);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    Exist = table.Column<int>(type: "INTEGER", nullable: false),
                    MetaDataId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_MetaDatas_MetaDataId",
                        column: x => x.MetaDataId,
                        principalTable: "MetaDatas",
                        principalColumn: "MetadataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumContexts",
                columns: table => new
                {
                    AlbumContextId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumContexts", x => x.AlbumContextId);
                    //table.ForeignKey(
                    //    name: "FK_AlbumContexts_Albums_AlbumId",
                    //    column: x => x.AlbumId,
                    //    principalTable: "Albums",
                    //    principalColumn: "AlbumId",
                    //    onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_AlbumContexts_Photos_PhotoId",
                    //    column: x => x.PhotoId,
                    //    principalTable: "Photos",
                    //    principalColumn: "PhotoId",
                    //    onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumContexts_AlbumId",
                table: "AlbumContexts",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumContexts_PhotoId",
                table: "AlbumContexts",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Name",
                table: "Albums",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MetaDataId",
                table: "Photos",
                column: "MetaDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumContexts");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "MetaDatas");
        }
    }
}
