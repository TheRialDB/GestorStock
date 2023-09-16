using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class ArregloControladores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "simbolo",
                table: "Unidades",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "simbolo",
                table: "Unidades");
        }
    }
}
