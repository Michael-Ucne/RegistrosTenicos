using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrosTenicos.Migrations
{
    /// <inheritdoc />
    public partial class Correciondetablaenclientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Clientes",
                newName: "ClienteName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteName",
                table: "Clientes",
                newName: "Nombre");
        }
    }
}
