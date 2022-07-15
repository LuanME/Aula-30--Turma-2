using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula_30_dia_15_07.Migrations
{
    public partial class MIGRACAO_MODELAGEM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Instituicaoid",
                table: "alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_alunos_Instituicaoid",
                table: "alunos",
                column: "Instituicaoid");

            migrationBuilder.AddForeignKey(
                name: "FK_alunos_instituicoes_Instituicaoid",
                table: "alunos",
                column: "Instituicaoid",
                principalTable: "instituicoes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alunos_instituicoes_Instituicaoid",
                table: "alunos");

            migrationBuilder.DropIndex(
                name: "IX_alunos_Instituicaoid",
                table: "alunos");

            migrationBuilder.DropColumn(
                name: "Instituicaoid",
                table: "alunos");
        }
    }
}
