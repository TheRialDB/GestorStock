using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionProductoUnidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UnidadId",
                table: "Productos",
                column: "UnidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Unidades_UnidadId",
                table: "Productos",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Unidades_UnidadId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_UnidadId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "Productos");
        }
    }
}
