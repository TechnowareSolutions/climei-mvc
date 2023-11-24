using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimeiMvc.Migrations
{
    /// <inheritdoc />
    public partial class Initial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DadosUsuario_UsuarioId",
                table: "DadosUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuario_UsuarioId",
                table: "DadosUsuario",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DadosUsuario_UsuarioId",
                table: "DadosUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuario_UsuarioId",
                table: "DadosUsuario",
                column: "UsuarioId");
        }
    }
}
