using Microsoft.EntityFrameworkCore.Migrations;

namespace BacalhauResponde.Migrations
{
    public partial class AtualizacaoTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ocupacao",
                schema: "BacalhauResponde",
                table: "Usuarios",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocupacao",
                schema: "BacalhauResponde",
                table: "Usuarios");
        }
    }
}
