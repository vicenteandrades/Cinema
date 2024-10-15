using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFilmeStudy.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Endereco",
                newName: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Endereco",
                newName: "CinemaId");
        }
    }
}
