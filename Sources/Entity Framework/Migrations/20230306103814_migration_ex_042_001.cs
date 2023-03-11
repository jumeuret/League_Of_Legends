using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class migrationex042001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    ChampionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Class = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.ChampionId);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    niveau = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.nom);
                });

            migrationBuilder.CreateTable(
                name: "RunePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    ChampionEntityChampionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ChampionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skins_Champions_ChampionEntityChampionId",
                        column: x => x.ChampionEntityChampionId,
                        principalTable: "Champions",
                        principalColumn: "ChampionId");
                });

            migrationBuilder.CreateTable(
                name: "Runes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Categorie = table.Column<string>(type: "TEXT", nullable: false),
                    RunePageEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runes_RunePages_RunePageEntityId",
                        column: x => x.RunePageEntityId,
                        principalTable: "RunePages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "ChampionId", "Bio", "Class", "Icon", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "gg", null, "ff", null, "Akali" },
                    { 2, "gg", null, "ff", null, "Bard" },
                    { 3, "gg", null, "gg", null, "Aatrox" },
                    { 4, "gg", null, "ff", null, "Ahri" },
                    { 5, "gg", null, "ff", null, "Akshan" },
                    { 6, "gg", null, "ff", null, "Alistar" }
                });

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Id", "ChampionEntityChampionId", "ChampionId", "Description", "Icon", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, 2, "truc", null, null, "gg", 11.5f },
                    { 2, null, 2, "truc", null, null, "hh", 11.5f },
                    { 3, null, 2, "truc", null, null, "ii", 11.5f },
                    { 4, null, 1, "truc", null, null, "jj", 11.5f },
                    { 5, null, 1, "truc", null, null, "ll", 11.5f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Runes_RunePageEntityId",
                table: "Runes",
                column: "RunePageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Skins_ChampionEntityChampionId",
                table: "Skins",
                column: "ChampionEntityChampionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Runes");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropTable(
                name: "RunePages");

            migrationBuilder.DropTable(
                name: "Champions");
        }
    }
}
