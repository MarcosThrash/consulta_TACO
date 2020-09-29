using Microsoft.EntityFrameworkCore.Migrations;

namespace TACO_Nutricional.Migrations
{
    public partial class cadastroPorUusario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "Calorias",
                table: "Alimentos");

            migrationBuilder.AlterColumn<int>(
                name: "GrupoAlimentarId",
                table: "Alimentos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CadastradoPorUsuario",
                table: "Alimentos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Caloria",
                table: "Alimentos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimentos",
                column: "GrupoAlimentarId",
                principalTable: "GruposAlimentares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "CadastradoPorUsuario",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "Caloria",
                table: "Alimentos");

            migrationBuilder.AlterColumn<int>(
                name: "GrupoAlimentarId",
                table: "Alimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "Calorias",
                table: "Alimentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimentos",
                column: "GrupoAlimentarId",
                principalTable: "GruposAlimentares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
