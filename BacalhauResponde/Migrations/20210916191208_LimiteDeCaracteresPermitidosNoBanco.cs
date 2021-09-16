using Microsoft.EntityFrameworkCore.Migrations;

namespace BacalhauResponde.Migrations
{
    public partial class LimiteDeCaracteresPermitidosNoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "BacalhauResponde",
                table: "Respostas",
                type: "varchar(1500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                schema: "BacalhauResponde",
                table: "Perguntas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "BacalhauResponde",
                table: "Perguntas",
                type: "varchar(1500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "BacalhauResponde",
                table: "Respostas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1500)");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                schema: "BacalhauResponde",
                table: "Perguntas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "BacalhauResponde",
                table: "Perguntas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1500)");
        }
    }
}
