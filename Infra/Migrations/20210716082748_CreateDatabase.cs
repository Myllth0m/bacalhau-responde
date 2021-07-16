using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BACALHAU");

            migrationBuilder.CreateTable(
                name: "PERGUNTAS",
                schema: "BACALHAU",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FOTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TITULO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATA_DE_CRIACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_DE_ATUALIZACAO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERGUNTAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESPOSTAS",
                schema: "BACALHAU",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERGUNTA_ID = table.Column<long>(type: "bigint", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FOTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_DE_CRIACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_DE_ATUALIZACAO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPOSTAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESPOSTAS_PERGUNTAS_PERGUNTA_ID",
                        column: x => x.PERGUNTA_ID,
                        principalSchema: "BACALHAU",
                        principalTable: "PERGUNTAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTAS_PERGUNTA_ID",
                schema: "BACALHAU",
                table: "RESPOSTAS",
                column: "PERGUNTA_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESPOSTAS",
                schema: "BACALHAU");

            migrationBuilder.DropTable(
                name: "PERGUNTAS",
                schema: "BACALHAU");
        }
    }
}
