using Microsoft.EntityFrameworkCore.Migrations;

namespace AreaGeografica.Migrations
{
    public partial class AreaGeograficaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameContinent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continentsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                    table.ForeignKey(
                        name: "FK_Country_Continents_Continentsid",
                        column: x => x.Continentsid,
                        principalTable: "Continents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroAbitanti = table.Column<int>(type: "int", nullable: false),
                    numeroPositivi = table.Column<int>(type: "int", nullable: false),
                    ColorStateCities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Countryid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cities_Country_Countryid",
                        column: x => x.Countryid,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Countryid",
                table: "Cities",
                column: "Countryid");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Continentsid",
                table: "Country",
                column: "Continentsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
