using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatBack.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kafic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kafic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedniBroj = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KaficID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Porudzbina_Kafic_KaficID",
                        column: x => x.KaficID,
                        principalTable: "Kafic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N = table.Column<int>(type: "int", nullable: false),
                    M = table.Column<int>(type: "int", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    MaxKapacitet = table.Column<int>(type: "int", nullable: false),
                    KaficID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sto_Kafic_KaficID",
                        column: x => x.KaficID,
                        principalTable: "Kafic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbina_KaficID",
                table: "Porudzbina",
                column: "KaficID");

            migrationBuilder.CreateIndex(
                name: "IX_Sto_KaficID",
                table: "Sto",
                column: "KaficID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Porudzbina");

            migrationBuilder.DropTable(
                name: "Sto");

            migrationBuilder.DropTable(
                name: "Kafic");
        }
    }
}
