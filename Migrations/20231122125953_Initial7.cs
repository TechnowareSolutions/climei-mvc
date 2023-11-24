using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimeiMvc.Migrations
{
    /// <inheritdoc />
    public partial class Initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario");

            migrationBuilder.CreateTable(
                name: "LogAgua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    dateAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAgua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogAgua_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogAgua_UsuarioId",
                table: "LogAgua",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario");

            migrationBuilder.DropTable(
                name: "LogAgua");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
