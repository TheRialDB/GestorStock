using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionObraEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EstadoId",
                table: "Obras",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Estados_EstadoId",
                table: "Obras",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Estados_EstadoId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_EstadoId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Obras");
        }
    }
}
