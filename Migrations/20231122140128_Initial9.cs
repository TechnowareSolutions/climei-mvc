using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimeiMvc.Migrations
{
    /// <inheritdoc />
    public partial class Initial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateAvaliacao",
                table: "LogAgua",
                newName: "DataAvaliacao");

            migrationBuilder.CreateTable(
                name: "LogBatimentoOxigenacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBatimentoOxigenacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogBatimentoOxigenacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NivelTemperatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faixa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelTemperatura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelUmidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faixa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelUmidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTemperatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NivelTemperaturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTemperatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogTemperatura_NivelTemperatura_NivelTemperaturaId",
                        column: x => x.NivelTemperaturaId,
                        principalTable: "NivelTemperatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogTemperatura_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogUmidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Umidade = table.Column<double>(type: "float", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NivelUmidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogUmidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogUmidade_NivelUmidade_NivelUmidadeId",
                        column: x => x.NivelUmidadeId,
                        principalTable: "NivelUmidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogUmidade_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogBatimentoOxigenacao_UsuarioId",
                table: "LogBatimentoOxigenacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LogTemperatura_NivelTemperaturaId",
                table: "LogTemperatura",
                column: "NivelTemperaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_LogTemperatura_UsuarioId",
                table: "LogTemperatura",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LogUmidade_NivelUmidadeId",
                table: "LogUmidade",
                column: "NivelUmidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_LogUmidade_UsuarioId",
                table: "LogUmidade",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogBatimentoOxigenacao");

            migrationBuilder.DropTable(
                name: "LogTemperatura");

            migrationBuilder.DropTable(
                name: "LogUmidade");

            migrationBuilder.DropTable(
                name: "NivelTemperatura");

            migrationBuilder.DropTable(
                name: "NivelUmidade");

            migrationBuilder.RenameColumn(
                name: "DataAvaliacao",
                table: "LogAgua",
                newName: "dateAvaliacao");
        }
    }
}
