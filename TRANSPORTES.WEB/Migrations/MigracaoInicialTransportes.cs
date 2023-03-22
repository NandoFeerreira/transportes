using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRANSPORTES.WEB.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicialTransportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EntidadeClientes",
                columns: table => new
                {
                    ClienteId = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    ClienteNome = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadeClientes", x => x.ClienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conteiners",
                columns: table => new
                {
                    ConteinerId = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EntidadeClienteClienteId = table.Column<decimal>(type: "decimal(13,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiners", x => x.ConteinerId);
                    table.ForeignKey(
                        name: "FK_Conteiners_EntidadeClientes_EntidadeClienteClienteId",
                        column: x => x.EntidadeClienteClienteId,
                        principalTable: "EntidadeClientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    MovimentacaoId = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConteinerId = table.Column<decimal>(type: "decimal(13,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.MovimentacaoId);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Conteiners_ConteinerId",
                        column: x => x.ConteinerId,
                        principalTable: "Conteiners",
                        principalColumn: "ConteinerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conteiners_EntidadeClienteClienteId",
                table: "Conteiners",
                column: "EntidadeClienteClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ConteinerId",
                table: "Movimentacoes",
                column: "ConteinerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Conteiners");

            migrationBuilder.DropTable(
                name: "EntidadeClientes");
        }
    }
}
