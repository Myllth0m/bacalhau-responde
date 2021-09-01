using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BacalhauResponde.Migrations
{
    public partial class CriacaoDasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BacalhauResponde");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(200)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(200)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(200)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(200)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(200)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(200)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "varchar(200)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(200)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(200)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(200)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(200)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(200)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "varchar(200)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(200)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(200)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(200)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Value = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(200)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_AspNetUsers_Id",
                        column: x => x.Id,
                        principalSchema: "BacalhauResponde",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Foto = table.Column<string>(type: "varchar(200)", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataDeCriacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataDeAtualizacao = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                schema: "BacalhauResponde",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "varchar(200)", nullable: true),
                    PerguntaId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Foto = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataDeCriacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataDeAtualizacao = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "BacalhauResponde",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "BacalhauResponde",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "BacalhauResponde",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "BacalhauResponde",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "BacalhauResponde",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "BacalhauResponde",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "BacalhauResponde",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "BacalhauResponde",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_UsuarioId",
                schema: "BacalhauResponde",
                table: "Perguntas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaId",
                schema: "BacalhauResponde",
                table: "Respostas",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_UsuarioId",
                schema: "BacalhauResponde",
                table: "Respostas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "Respostas",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "Perguntas",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "BacalhauResponde");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "BacalhauResponde");
        }
    }
}
