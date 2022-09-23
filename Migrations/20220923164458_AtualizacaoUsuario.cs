using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace usuario.Migrations
{
    public partial class AtualizacaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tb_user");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_user",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "tb_user",
                newName: "data_nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user");

            migrationBuilder.RenameTable(
                name: "tb_user",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Users",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "Users",
                newName: "DataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");
        }
    }
}
