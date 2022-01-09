using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class CategorieAntrenament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AntrenorID",
                table: "Clienti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Antrenor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAntrenor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieAntrenament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieAntrenament", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieAntrenament_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieAntrenament_Clienti_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clienti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_AntrenorID",
                table: "Clienti",
                column: "AntrenorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieAntrenament_CategorieID",
                table: "CategorieAntrenament",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieAntrenament_ClientID",
                table: "CategorieAntrenament",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clienti_Antrenor_AntrenorID",
                table: "Clienti",
                column: "AntrenorID",
                principalTable: "Antrenor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clienti_Antrenor_AntrenorID",
                table: "Clienti");

            migrationBuilder.DropTable(
                name: "Antrenor");

            migrationBuilder.DropTable(
                name: "CategorieAntrenament");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Clienti_AntrenorID",
                table: "Clienti");

            migrationBuilder.DropColumn(
                name: "AntrenorID",
                table: "Clienti");
        }
    }
}
