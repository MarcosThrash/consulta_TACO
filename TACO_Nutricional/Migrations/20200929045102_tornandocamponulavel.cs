using Microsoft.EntityFrameworkCore.Migrations;

namespace TACO_Nutricional.Migrations
{
    public partial class tornandocamponulavel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CadastradoPorUsuario",
                table: "Alimentos",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CadastradoPorUsuario",
                table: "Alimentos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
