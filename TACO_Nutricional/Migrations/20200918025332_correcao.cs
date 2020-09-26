using Microsoft.EntityFrameworkCore.Migrations;

namespace TACO_Nutricional.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimetos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alimetos",
                table: "Alimetos");

            migrationBuilder.RenameTable(
                name: "Alimetos",
                newName: "Alimentos");

            migrationBuilder.RenameIndex(
                name: "IX_Alimetos_GrupoAlimentarId",
                table: "Alimentos",
                newName: "IX_Alimentos_GrupoAlimentarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alimentos",
                table: "Alimentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimentos",
                column: "GrupoAlimentarId",
                principalTable: "GruposAlimentares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alimentos",
                table: "Alimentos");

            migrationBuilder.RenameTable(
                name: "Alimentos",
                newName: "Alimetos");

            migrationBuilder.RenameIndex(
                name: "IX_Alimentos_GrupoAlimentarId",
                table: "Alimetos",
                newName: "IX_Alimetos_GrupoAlimentarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alimetos",
                table: "Alimetos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimetos_GruposAlimentares_GrupoAlimentarId",
                table: "Alimetos",
                column: "GrupoAlimentarId",
                principalTable: "GruposAlimentares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
