using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimeiMvc.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuario_Usuario_UsuarioId",
                table: "DadosUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
