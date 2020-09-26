using Microsoft.EntityFrameworkCore.Migrations;

namespace TACO_Nutricional.Migrations
{
    public partial class tabelasIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GruposAlimentares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposAlimentares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Umidade = table.Column<double>(nullable: false),
                    Caloria = table.Column<double>(nullable: false),
                    Proteina = table.Column<double>(nullable: false),
                    Lipideos = table.Column<double>(nullable: false),
                    Colesterol = table.Column<double>(nullable: false),
                    Carboidrato = table.Column<double>(nullable: false),
                    FibraAlimentar = table.Column<double>(nullable: false),
                    Cinzas = table.Column<double>(nullable: false),
                    Calcio = table.Column<double>(nullable: false),
                    Magnesio = table.Column<double>(nullable: false),
                    Manganes = table.Column<double>(nullable: false),
                    Fosforo = table.Column<double>(nullable: false),
                    Ferro = table.Column<double>(nullable: false),
                    Sodio = table.Column<double>(nullable: false),
                    Potassio = table.Column<double>(nullable: false),
                    Cobre = table.Column<double>(nullable: false),
                    Zinco = table.Column<double>(nullable: false),
                    GrupoAlimentarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimetos_GruposAlimentares_GrupoAlimentarId",
                        column: x => x.GrupoAlimentarId,
                        principalTable: "GruposAlimentares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimetos_GrupoAlimentarId",
                table: "Alimetos",
                column: "GrupoAlimentarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimetos");

            migrationBuilder.DropTable(
                name: "GruposAlimentares");
        }
    }
}
